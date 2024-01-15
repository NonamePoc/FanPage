import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { ChaptersComponent } from './chapters/chapters.component';
import { ReviewsComponent } from './reviews/reviews.component';
import { DropdownDirective } from '../../shared/dropdown.directive';
import { ModalComponent } from '../../shared/modal/modal.component';
import { ModalService } from '../../shared/modal/modal.service';

@Component({
  selector: 'app-book',
  standalone: true,
  templateUrl: './book.component.html',
  styleUrl: './book.component.css',
  imports: [
    RouterLink,
    ChaptersComponent,
    ReviewsComponent,
    DropdownDirective,
    ModalComponent,
  ],
})
export class BookComponent {
  constructor(private router: Router, private modalService: ModalService) {}

  onDelete() {
    this.modalService.openModal('deleteBookModal');
  }

  onConfirmDelete() {
    this.modalService.closeModal('deleteBookModal');
    this.router.navigate(['/']);
  }

  onCancelDelete() {
    this.modalService.closeModal('deleteBookModal');
  }
}
