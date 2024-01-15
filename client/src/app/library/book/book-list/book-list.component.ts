import { Component, Input } from '@angular/core';
import { Book } from '../book';
import { CommonModule } from '@angular/common';
import { BookService } from '../../book.service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-book-list',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './book-list.component.html',
  styleUrl: './book-list.component.css',
})
export class BookListComponent {
  @Input() title: string = 'Book List';

  constructor(public bookService: BookService) {}

  get books() {
    return this.bookService.filteredBooks;
  }

  get isListLayout() {
    return this.bookService.isListLayout;
  }
}
