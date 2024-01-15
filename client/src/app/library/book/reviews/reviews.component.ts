import { Component } from '@angular/core';
import { ModalService } from '../../../shared/modal/modal.service';
import { StarRatingComponent } from './star-rating/star-rating.component';

@Component({
  selector: 'app-reviews',
  standalone: true,
  templateUrl: './reviews.component.html',
  styleUrl: './reviews.component.css',
  imports: [StarRatingComponent],
})
export class ReviewsComponent {
  constructor(private modalService: ModalService) {}

  openModal = () => {
    this.modalService.openModal('reviewModal');
  };
}
