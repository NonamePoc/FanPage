import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router, RouterLink } from '@angular/router';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { LanguageSelectorComponent } from './language-selector/language-selector.component';
import { CategorySelectorComponent } from './category-selector/category-selector.component';
import { TagInputComponent } from './tag-input/tag-input.component';
import { BookService } from '../../book.service';
import { ToastrService } from 'ngx-toastr';

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

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService,
    private bookService: BookService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.id = +params['id'];
      this.editMode = params['id'] != null;
      this.initForm();
    });
  }

  onSubmit(): void {
    this.editMode ? this.updateBook() : this.addBook();
  }

  selectImage(event: any): void {
    if (event.target.files && event.target.files[0]) {
      const file = event.target.files[0];
      this.bookForm.patchValue({
        cover: file,
      });

      const reader = new FileReader();
      reader.onload = (e: any) => {
        this.preview = e.target.result;
      };
      reader.readAsDataURL(file);
    }
  }

  private initForm(): void {
    let title = null;
    let description = null;
    let language = 'ab';
    let cover = null;
    let categories = ['Romance'];
    let tags = null;
    let origin = false;
    let stage = this.stages[0];

    this.editMode &&
      this.bookService.getBook(this.id).subscribe((data) => {
        title = data.title;
        description = data.description;
        language = data.language;
        categories = data.categories.map((category: any) => category.name);
        tags = data.tags.map((tag: any) => tag.name);
        origin = data.originFandom;
        stage = data.stage;
        cover = data.image;
        this.preview = `data:image/png;base64,${data.image}`;
      });

    this.bookForm = new FormGroup({
      title: new FormControl(title, [
        Validators.required,
        Validators.minLength(2),
        Validators.maxLength(20),
      ]),
      description: new FormControl(description, [
        Validators.required,
        Validators.minLength(2),
        Validators.maxLength(300),
      ]),
      language: new FormControl(language, [Validators.required]),
      cover: new FormControl(cover),
      categories: new FormControl(categories),
      tags: new FormControl(tags),
      origin: new FormControl(origin),
      stage: new FormControl({ value: stage, disabled: !this.editMode }, [
        Validators.required,
      ]),
    });
  }

  private addBook(): void {
    if (this.bookForm.valid) {
      const data = this.bookForm.getRawValue();

      this.bookService.addBook(data).subscribe({
        next: (response: any) => {
          this.router.navigate(['/books/', response.id, 'chapters', 'new']);
          this.bookService.getBooksByUser(
            JSON.parse(localStorage.getItem('userData')!)?.username
          );
        },
        error: (error) => {
          this.toastr.error(
            'An error occurred while adding the book: ' + error.message
          );
        },
      });
    } else {
      this.toastr.error('Please fill in all required fields');
    }
  }

  private updateBook(): void {
    if (this.bookForm.valid) {
      const data = this.bookForm.getRawValue();
      this.bookService.updateBook(data, this.id).subscribe({
        next: () => {
          if (data.cover) {
            this.bookService.updateCover(this.id, data.cover).subscribe({
              next: () => {
                this.router.navigate(['/books/', this.id]);
              },
              error: (error) => {
                this.toastr.error(
                  'An error occurred while updating the cover: ' + error.message
                );
              },
            });
          } else {
            this.router.navigate(['/books/', this.id]);
          }
        },
        error: (error) => {
          this.toastr.error(
            'An error occurred while updating the book: ' + error.message
          );
        },
      });
    } else {
      this.toastr.error('Please fill in all required fields');
    }
  }
}
