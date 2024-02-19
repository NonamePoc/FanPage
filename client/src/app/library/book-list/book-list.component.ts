import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookService } from '../book.service';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { ImageNormalizePipe } from '../../shared/image-normalize.pipe';

@Component({
  selector: 'app-book-list',
  standalone: true,
  imports: [CommonModule, RouterLink, ImageNormalizePipe],
  templateUrl: './book-list.component.html',
  styleUrl: './book-list.component.css',
})
export class BookListComponent implements OnInit {
  @Input() isReading: boolean = true;
  @Input() title: string = 'In Progress';
  books: any[] = [];

  constructor(public bookService: BookService, private router: Router) {}

  ngOnInit(): void {
    const username = JSON.parse(localStorage.getItem('userData')!)?.username;
    !this.isReading
      ? this.bookService.getBooksByUser(username).subscribe((books: any) => {
          this.bookService.setBooks(books);
          this.books = this.bookService.books.filter(
            (book: any) => book.stage === this.title
          );
        })
      : this.bookService.getBookmarks().subscribe((books: any) => {
          this.books = books;
        });
  }

  get isListLayout() {
    return this.bookService.isListLayout;
  }
}
