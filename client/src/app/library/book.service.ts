import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Book } from './models/book.model';
import { environment } from '../../environments/environment.development';

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
    const formData = new FormData();
    formData.append('Title', data.title);
    formData.append('Description', data.description);
    formData.append('File', data.cover);
    formData.append('OriginFandom', data.origin);
    formData.append('Stage', data.stage);
    formData.append('Language', data.language);
    for (var category of data.categories) {
      formData.append('Categories', category);
    }
    for (var tag of data.tags) {
      formData.append('Tags', tag);
    }
    return this.http
      .post(environment.apiUrl + '/v1/fanfic/create', formData)
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

  updateCover(bookId: number, image: any): Observable<any> {
    const formData = new FormData();
    formData.append('imageFanfic', image);
    return this.http.post(
      environment.apiUrl + '/v1/detail/updateAvatar?fanficId=' + bookId,
      formData
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

  search(value: string): Observable<any> {
    return this.http.get(
      environment.apiUrl +
        '/v1/detail/search?searchString=' +
        value +
        '&originalFandom=true'
    );
  }

  // Bookmarks

  checkBookmark(id: number): boolean {
    return this.bookmarks.some((bookmark) => bookmark.id === id);
  }

  getBookmarks(): Observable<any> {
    return this.http.get(environment.apiUrl + '/v1/bookmark/List').pipe(
      tap((response: any) => {
        this.bookmarks = response;
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

  removeBookmark(bookId: number): Observable<any> {
    return this.http
      .delete(environment.apiUrl + '/v1/bookmark/Delete?fanficId=' + bookId)
      .pipe(
        tap(() => {
          const index = this.bookmarks.findIndex(
            (bookmark) => bookmark.id === bookId
          );
          if (index !== -1) {
            this.bookmarks.splice(index, 1);
          }
        })
      );
  }
}
