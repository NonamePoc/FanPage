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

@Component({
  selector: 'app-star-rating',
  standalone: true,
  templateUrl: './star-rating.component.html',
  styleUrl: './star-rating.component.css',
  imports: [CommonModule, ReactiveFormsModule, ModalComponent],
})
export class StarRatingComponent implements OnInit {
  @Input() rating: number = 1;
  @Output() ratingChange: EventEmitter<number> = new EventEmitter<number>();

  reviewForm!: FormGroup;

  constructor(
    private toastr: ToastrService,
    private modalService: ModalService
  ) {}

  ngOnInit(): void {
    this.reviewForm = new FormGroup({
      rating: new FormControl(this.rating, [Validators.required]),
      text: new FormControl(null, [Validators.maxLength(500)]),
    });
  }

  setRating(value: number): void {
    this.rating = value;
    this.reviewForm.controls['rating'].setValue(value);
    this.ratingChange.emit(value);
  }

  onSubmit(): void {
    if (this.reviewForm.controls['text'].value.length > 500) {
      this.toastr.error('Max 500 chars for review text');
      return;
    }
    console.log(this.reviewForm);
    this.toastr.success('Review submitted');
    this.modalService.closeModal('reviewModal');
    /*     this.reviewForm.reset(); */
  }
}
