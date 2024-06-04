import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { Subject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';
import { BookService } from '../../library/book.service';
import { ImageNormalizePipe } from '../../shared/image-normalize.pipe';

@Component({
  selector: 'app-search',
  standalone: true,
  templateUrl: './search.component.html',
  styleUrl: './search.component.css',
  imports: [CommonModule, RouterLink, ImageNormalizePipe, FormsModule],
})
export class SearchComponent implements OnInit, OnDestroy {
  searchInput: string = '';
  books: any = [];

  constructor(private bookService: BookService) {}

  ngOnInit() {
    this.searchSubject.pipe(debounceTime(500)).subscribe((value) => {
      this.performSearch(value);
    });
  }

  ngOnDestroy() {
    this.searchSubject.complete();
  }

  onSearch() {
    this.searchSubject.next(this.searchInput);
  }

  private performSearch(searchValue: string) {
    !searchValue
      ? (this.books = [])
      : this.bookService.search(searchValue).subscribe((books) => {
          this.books = books;
        });
  }

  private searchSubject = new Subject<string>();
}
