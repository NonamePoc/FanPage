import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Params, RouterLink } from '@angular/router';
import { ImageNormalizePipe } from '../../shared/image-normalize.pipe';
import { FilterComponent } from './filter/filter.component';
import { BookFilter } from '../models/book.model';
import { BookService } from '../book.service';

@Component({
  selector: 'app-book-list',
  standalone: true,
  templateUrl: './book-list.component.html',
  styleUrl: './book-list.component.css',
  imports: [CommonModule, RouterLink, ImageNormalizePipe, FilterComponent],
})
export class BookListComponent implements OnInit {
  @Input() isReading: boolean = true;
  isLoading: boolean = true;
  books: any[] = [];
  filteredBooks: any[] = [];
  filters: BookFilter = {};
  isListLayout: boolean = true;

  constructor(
    private route: ActivatedRoute,
    private bookService: BookService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      var username = '';
      params['username']
        ? (username = params['username'])
        : (username = JSON.parse(localStorage.getItem('userData')!)?.username);
      !this.isReading
        ? this.bookService.getBooksByUser(username).subscribe((books: any) => {
            this.books = books;
            this.filteredBooks = books;
            this.isLoading = false;
          })
        : this.bookService.getBookmarks().subscribe((books: any) => {
            this.books = books;
            this.filteredBooks = books;
            this.isLoading = false;
          });
    });
  }

  filterBooks() {
    this.filteredBooks = this.books.filter((book) => {
      return (
        (!this.filters.status || book.stage === this.filters.status) &&
        (!this.filters.categories ||
          this.filters.categories.length === 0 ||
          book.categories?.some((category: any) =>
            this.filters.categories?.some(
              (filterCategory) => category.categoryId === filterCategory.id
            )
          )) &&
        (!this.filters.dateCreated ||
          book.creationDate === this.filters.dateCreated)
      );
    });
  }

  changeLayout(value: boolean) {
    this.isListLayout = value;
  }
}
