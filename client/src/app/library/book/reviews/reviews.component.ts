import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { ModalService } from '../../../shared/modal/modal.service';
import { StarRatingComponent } from './star-rating/star-rating.component';
import { BookService } from '../../book.service';
import { BehaviorSubject, Observable } from 'rxjs';

@Component({
  selector: 'app-reviews',
  standalone: true,
  templateUrl: './reviews.component.html',
  styleUrl: './reviews.component.css',
  imports: [CommonModule, StarRatingComponent],
})
export class ReviewsComponent implements OnInit {
  bookId!: number;
  reviews: any[] = [];

  private currentReviewSubject = new BehaviorSubject<any>(null);
  review = this.currentReviewSubject.asObservable();

  constructor(
    private modalService: ModalService,
    private route: ActivatedRoute,
    private bookService: BookService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.bookId = +params['id'];
      this.bookService.getBookRating(this.bookId).subscribe((data) => {
        console.log(data);
      });
      this.bookService.getBookReviews(this.bookId).subscribe((data) => {
        this.reviews = data;
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
