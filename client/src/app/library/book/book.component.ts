import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router, RouterLink, ActivatedRoute, Params } from '@angular/router';
import { ChaptersComponent } from './chapters/chapters.component';
import { ReviewsComponent } from './reviews/reviews.component';
import { DropdownDirective } from '../../shared/dropdown.directive';
import { ModalComponent } from '../../shared/modal/modal.component';
import { ModalService } from '../../shared/modal/modal.service';
import { BookService } from '../book.service';
import { response } from 'express';
import { ImageNormalizePipe } from '../../shared/image-normalize.pipe';

@Component({
  selector: 'app-book',
  standalone: true,
  templateUrl: './book.component.html',
  styleUrl: './book.component.css',
  imports: [
    CommonModule,
    RouterLink,
    ChaptersComponent,
    ReviewsComponent,
    DropdownDirective,
    ModalComponent,
    ImageNormalizePipe,
  ],
})
export class BookComponent implements OnInit {
  book: any;
  id!: number;
  isLoading = true;
  isBookmarked = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private modalService: ModalService,
    private bookService: BookService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.id = +params['id'];
      this.bookService.getBook(this.id).subscribe((book) => {
        this.book = book;
        this.isBookmarked = this.bookService.checkBookmark(this.id);
        this.isLoading = false;
      });
    });
  }

  onBookmark() {
    this.isBookmarked
      ? this.bookService
          .removeBookmark(this.id)
          .subscribe(() => (this.isBookmarked = !this.isBookmarked))
      : this.bookService
          .addBookmark(this.id)
          .subscribe(() => (this.isBookmarked = !this.isBookmarked));
  }

  onOpenDeleteModal() {
    this.modalService.openModal('deleteBookModal');
  }

  onConfirmDelete() {
    this.bookService.deleteBook(this.id).subscribe(() => {
      this.router.navigate(['/books']);
      this.modalService.closeModal('deleteBookModal');
    });
  }

  onCancelDelete() {
    this.modalService.closeModal('deleteBookModal');
  }
}
