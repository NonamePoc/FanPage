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
  writtenBooks: Book[] = [];
  bookmarks: any[] = [];

  constructor(private http: HttpClient) {}

  setBooks(books: any) {
    this.writtenBooks = books;
  }

  addBook(data: any): Observable<any> {
    return this.http
      .post(environment.apiUrl + '/v1/fanfic/create', {
        title: data.title,
        description: data.description,
        language: data.language,
        imageFanfic: [{ image: data.cover }],
        categories: data.categories,
        tags: data.tags,
        originFandom: data.origin,
        stage: data.stage,
      })
      .pipe(
        tap((response: any) => {
          this.writtenBooks.push(response.book);
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
          const index = this.writtenBooks.findIndex((book) => book.id === id);
          if (index !== -1) {
            this.writtenBooks[index] = response.book;
          }
        })
      );
  }

  deleteBook(id: number): Observable<any> {
    return this.http
      .delete(environment.apiUrl + '/v1/fanfic/delete?id=' + id)
      .pipe(
        tap(() => {
          const index = this.writtenBooks.findIndex((book) => book.id === id);
          if (index !== -1) {
            this.writtenBooks.splice(index, 1);
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
}
