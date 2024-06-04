import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ActivatedRoute, Params } from '@angular/router';
import { ModalService } from '../../../shared/modal/modal.service';
import { StarRatingComponent } from './star-rating/star-rating.component';
import { RatingService } from './rating.service';
import { BookComponent } from '../book.component';

@Component({
  selector: 'app-reviews',
  standalone: true,
  templateUrl: './reviews.component.html',
  styleUrl: './reviews.component.css',
  imports: [CommonModule, StarRatingComponent],
})
export class ReviewsComponent implements OnInit {
  bookId!: number;
  rating!: number;
  reviews: any[] = [];

  private currentReviewSubject = new BehaviorSubject<any>(null);
  review = this.currentReviewSubject.asObservable();

  constructor(
    private modalService: ModalService,
    private route: ActivatedRoute,
    private bookComp: BookComponent,
    private ratingService: RatingService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.bookId = +params['id'];
      this.ratingService
        .getBookRating(this.bookId)
        .subscribe((data) => (this.rating = data));
      this.bookComp.currentBook.subscribe((book) => {
        this.reviews = book.reviews;
      });
    });
  }

  setReview(review: any): void {
    this.currentReviewSubject.next(review);
  }

  openReviewModal = (review?: any) => {
    this.setReview(review);
    this.modalService.openModal('reviewModal');
  };
}
