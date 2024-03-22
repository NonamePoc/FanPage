import { CommonModule } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { EditorComponent, EditorModule } from '@tinymce/tinymce-angular';
import { ToastrService } from 'ngx-toastr';

import { environment } from '../../../../../../environments/environment.development';
import { ChapterService } from '../../chapter.service';

@Component({
  selector: 'app-edit-chapter',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, EditorModule],
  templateUrl: './edit-chapter.component.html',
  styleUrl: './edit-chapter.component.css',
})
export class EditChapterComponent implements OnInit {
  @ViewChild('editor') editor!: EditorComponent;
  chapterForm!: FormGroup;
  editMode = false;
  id!: number;
  bookId!: number;
  API_KEY = environment.editorApiKey;

  constructor(
    private toastr: ToastrService,
    private chapterService: ChapterService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.id = +params['chapterId'];
      this.bookId = +params['id'];
      this.editMode = params['chapterId'] != null;
      this.initForm();
    });
  }

  onSubmit(): void {
    if (this.chapterForm.invalid) {
      this.toastr.error('Please fill in all fields');
      return;
    }

    this.editMode
      ? this.chapterService
          .updateChapter(this.id, this.bookId, this.chapterForm.value)
          .subscribe(() => {
            this.toastr.success('Chapter updated');
            this.router.navigate(['../../'], { relativeTo: this.route });
          })
      : this.chapterService
          .addChapter(this.bookId, this.chapterForm.value)
          .subscribe((response: any) => {
            this.toastr.success('Chapter saved');
            this.router.navigate(['../', response.chapterId], {
              relativeTo: this.route,
            });
          });
  }

  onDelete(): void {
    this.chapterService.deleteChapter(this.id).subscribe(() => {
      this.toastr.success('Chapter deleted');
      this.router.navigate(['../../'], { relativeTo: this.route });
    });
  }

  private initForm(): void {
    this.chapterForm = new FormGroup({
      title: new FormControl(null, [Validators.required]),
      content: new FormControl(null, [Validators.required]),
    });

    if (this.editMode) {
      this.chapterService
        .getChapter(this.id, this.bookId)
        .subscribe((chapter: any) => {
          this.chapterForm.setValue({
            title: chapter.title,
            content: chapter.content,
          });
        });
    }
  }
}
