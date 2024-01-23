import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, RouterLink } from '@angular/router';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { LanguageSelectorComponent } from './language-selector/language-selector.component';
import { CategorySelectorComponent } from './category-selector/category-selector.component';
import { TagInputComponent } from './tag-input/tag-input.component';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-edit-book',
  standalone: true,
  templateUrl: './edit-book.component.html',
  styleUrl: './edit-book.component.css',
  imports: [
    CommonModule,
    RouterLink,
    ReactiveFormsModule,
    LanguageSelectorComponent,
    CategorySelectorComponent,
    TagInputComponent,
  ],
})
export class EditBookComponent implements OnInit {
  editMode = false;
  bookForm!: FormGroup;
  stages = ['In Progress', 'Done', 'Dropped'];
  preview = '';
  id!: number;

  constructor(private route: ActivatedRoute, private sanitizer: DomSanitizer) {}

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.id = +params['id'];
      this.editMode = params['id'] != null;
    });

    this.bookForm = new FormGroup({
      title: new FormControl(null, [
        Validators.required,
        Validators.minLength(1),
        Validators.maxLength(20),
      ]),
      description: new FormControl(null, [
        Validators.required,
        Validators.minLength(1),
        Validators.maxLength(100),
      ]),
      language: new FormControl(null, [Validators.required]),
      cover: new FormControl(null),
      categories: new FormControl(
        [
          {
            id: 1,
            name: 'Romance',
          },
        ],
        [Validators.required]
      ),
      tags: new FormControl(),
      origin: new FormControl(false),
      stage: new FormControl(
        { value: this.stages[0], disabled: !this.editMode },
        [Validators.required]
      ),
    });
  }

  onSubmit(): void {
    console.log(this.bookForm);
  }

  selectImage(event: any): void {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.preview = URL.createObjectURL(file);
    }
  }
}
