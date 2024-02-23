import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ModalComponent } from '../../../../shared/modal/modal.component';
import { ToastrService } from 'ngx-toastr';
import { ModalService } from '../../../../shared/modal/modal.service';
import { BookService } from '../../../book.service';
import { ReviewsComponent } from '../reviews.component';
import { Observable, catchError } from 'rxjs';

@Component({
  selector: 'app-star-rating',
  standalone: true,
  templateUrl: './star-rating.component.html',
  styleUrl: './star-rating.component.css',
  imports: [CommonModule, ReactiveFormsModule, ModalComponent],
})
export class StarRatingComponent implements OnInit {
  @Input() bookId!: number;

  editMode: boolean = false;
  reviewForm!: FormGroup;

  constructor(
    private toastr: ToastrService,
    private modalService: ModalService,
    private bookService: BookService,
    private reviewsComp: ReviewsComponent
  ) {}

  ngOnInit(): void {
    this.reviewForm = new FormGroup({
      rating: new FormControl(1, [Validators.required]),
      text: new FormControl(null, [Validators.maxLength(500)]),
    });

    this.reviewsComp.review.subscribe((review) => {
      if (review) {
        this.editMode = true;
        this.reviewForm.patchValue(review);
      }
    });
  }

  setRating(value: number): void {
    this.reviewForm.controls['rating'].setValue(value);
  }

  onSubmit(): void {
    if (this.reviewForm.controls['text'].value.length > 500) {
      this.toastr.error('Max 500 chars for review text');
      return;
    }
    this.editMode
      ? this.bookService
          .updateRating(
            this.bookId,
            this.reviewForm.controls['rating'].value,
            this.reviewForm.controls['text'].value
          )
          .subscribe(() => {
            this.resetForm('Review updated');
            this.reviewsComp.setReview(null);
          })
      : this.bookService
          .addRating(
            this.bookId,
            this.reviewForm.controls['rating'].value,
            this.reviewForm.controls['text'].value
          )
          .pipe(
            catchError((err) => {
              this.toastr.error(
                'Error adding review',
                'Maybe you already added a review?'
              );
              return err;
            })
          )
          .subscribe(() => {
            this.resetForm('Review added');
          });
  }

  deleteReview(): void {
    this.bookService.deleteRating(this.bookId).subscribe(() => {
      this.resetForm('Review deleted');
      this.reviewsComp.setReview(null);
    });
  }

  private resetForm(message: string): void {
    this.toastr.success(message);
    this.modalService.closeModal('reviewModal');
    this.reviewForm.reset();
  }
}
