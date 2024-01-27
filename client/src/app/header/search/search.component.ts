import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { BookService } from '../../library/book.service';

@Component({
  selector: 'app-search',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './search.component.html',
  styleUrl: './search.component.css',
})
export class SearchComponent {
  results: any[] = [];
  constructor(private bookService: BookService) {}

  search(value: string) {
    if (value.length > 0) {
      this.results = this.bookService.searchBooks(value);
    } else {
      this.clearResults();
    }
  }

  clearResults() {
    this.results = [];
  }
}
