import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { BookService } from '../../library/book.service';
import { Book } from '../../library/models/book.model';

@Component({
  selector: 'app-search',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './search.component.html',
  styleUrl: './search.component.css',
})
export class SearchComponent {
  filteredBooks: Book[] = [];
  constructor(private bookService: BookService) {}

  search(value: string) {
    if (value.length != 0) {
      this.filteredBooks = this.bookService.searchBooks(value);
    } else {
      this.clearResults();
    }
  }

  clearResults() {
    this.filteredBooks = [];
  }
}
