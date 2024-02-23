import { Injectable } from '@angular/core';
import { Book, BookFilter } from './models/book.model';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment.development';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class BookService {
  isListLayout: boolean = false;
  books: Book[] = [];
  bookmarks: any[] = [];
  filters: BookFilter = {};
  filteredBooks: Book[] = [...this.books];

  constructor(private http: HttpClient) {}

  setBooks(books: any) {
    this.books = books;
  }

  addBook(data: any): Observable<any> {
    return this.http
      .post(environment.apiUrl + '/v1/fanfic/create', {
        title: data.title,
        description: data.description,
        language: data.language,
        image: data.cover,
        categories: data.categories,
        tags: data.tags,
        originFandom: data.origin,
        stage: data.stage,
      })
      .pipe(
        tap((response: any) => {
          this.books.push(response.book);
        })
      );
  }

  updateBook(data: any, id: number): Observable<any> {
    return this.http
      .put(environment.apiUrl + '/v1/fanfic/update?id=' + id, {
        title: data.title,
        description: data.description,
        image: data.cover,
        categories: data.categories,
        tags: data.tags,
        originFandom: data.origin,
        stage: data.stage,
        language: data.language,
      })
      .pipe(
        tap((response: any) => {
          const index = this.books.findIndex((book) => book.id === id);
          if (index !== -1) {
            this.books[index] = response.book;
          }
        })
      );
  }

  deleteBook(id: number): Observable<any> {
    return this.http
      .delete(environment.apiUrl + '/v1/fanfic/delete?id=' + id)
      .pipe(
        tap(() => {
          const index = this.books.findIndex((book) => book.id === id);
          if (index !== -1) {
            this.books.splice(index, 1);
          }
        })
      );
  }

  getBook(id: number): Observable<any> {
    return this.http
      .get(environment.apiUrl + '/v1/detail/getById?id=' + id)
      .pipe(
        catchError((error) => {
          console.error(error);
          return of(error);
        })
      );
  }

  getBooksByUser(username: string): Observable<any> {
    return this.http.get(
      environment.apiUrl +
        '/v1/detail/byAuthorName?authorName=' +
        username +
        '&offset=500'
    );
  }

  getPopularBooks(): Observable<any> {
    return this.http.get(
      environment.apiUrl + '/v1/detail/topRatingFanfics?count=9'
    );
  }

  getLatestBooks(): Observable<any> {
    return this.http.get(
      environment.apiUrl + '/v1/detail/lastCreationDateFanfics?count=9'
    );
  }

  // Bookmarks

  checkBookmark(id: number): boolean {
    return this.bookmarks.some((bookmark) => bookmark.id === id);
  }

  getBookmarks(): Observable<any> {
    return this.http.get(environment.apiUrl + '/v1/bookmark/List').pipe(
      map((data: any) => {
        this.bookmarks = data;
      })
    );
  }

  addBookmark(book: any): Observable<any> {
    return this.http
      .post(environment.apiUrl + '/v1/bookmark/Add?fanficId=' + book.id, {})
      .pipe(
        tap(() => {
          this.bookmarks.push(book);
        })
      );
  }

  removeBookmark(book: any): Observable<any> {
    return this.http
      .delete(environment.apiUrl + '/v1/bookmark/Delete?fanficId=' + book.id)
      .pipe(
        tap(() => {
          const index = this.bookmarks.findIndex(
            (bookmark) => bookmark.id === book.id
          );
          if (index !== -1) {
            this.bookmarks.splice(index, 1);
          }
        })
      );
  }

  // Ratings and reviews

  getBookRating(id: number): Observable<any> {
    return this.http.get(
      environment.apiUrl + '/v1/detail/ratingFanfic?id=' + id
    );
  }

  getBookReviews(id: number): Observable<any> {
    return this.http.get(
      environment.apiUrl + '/v1/review/allFanficReview?fanficId=' + id
    );
  }

  addRating(id: number, rating: number, text: string): Observable<any> {
    return this.http.post(
      environment.apiUrl + '/v1/review/create?fanficId=' + id,
      {
        rating: rating,
        text: text,
      }
    );
  }

  updateRating(id: number, rating: number, text: string): Observable<any> {
    return this.http.put(
      environment.apiUrl + '/v1/review/update?fanficId=' + id,
      {
        rating: rating,
        text: text,
      }
    );
  }

  deleteRating(id: number): Observable<any> {
    return this.http.delete(
      environment.apiUrl + '/v1/review/delete?fanficId=' + id
    );
  }

  applyFilter() {
    console.log('Applying filter');
    /* this.filteredBooks = this.books.filter((book) => {
      if (this.filters.status && book.status !== this.filters.status) {
        return false;
      }

      if (this.filters.categories && this.filters.categories.length > 0) {
        const bookCategories = book.categories?.map((category) => category.id);
        if (
          !this.filters.categories.every((category) =>
            bookCategories?.includes(category.id)
          )
        ) {
          return false;
        }
      }

      if (this.filters.dateCreated && book.date !== this.filters.dateCreated) {
        return false;
      }

      return true;
    }); */
  }
}
