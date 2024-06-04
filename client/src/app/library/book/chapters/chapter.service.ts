import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from '../../../../environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class ChapterService {
  constructor(private http: HttpClient) {}

  getChapters(id: number): Observable<any> {
    return this.http.get(
      environment.apiUrl + '/v1/chapter/fanficChapter?fanficId=' + id
    );
  }

  getChapter(id: number, bookId: number): Observable<any> {
    return this.http.get(
      environment.apiUrl +
        '/v1/chapter/chapterById?id=' +
        id +
        '&fanficId=' +
        bookId
    );
  }

  addChapter(id: number, data: any): Observable<any> {
    return this.http.post(environment.apiUrl + '/v1/chapter/create', {
      title: data.title,
      content: data.content,
      fanficId: id,
    });
  }

  updateChapter(id: number, bookId: number, data: any): Observable<any> {
    return this.http.put(
      environment.apiUrl + '/v1/chapter/update?chapterId=' + id,
      {
        title: data.title,
        content: data.content,
        fanficId: bookId,
      }
    );
  }

  deleteChapter(id: number, bookId: number): Observable<any> {
    return this.http.delete(
      environment.apiUrl + '/v1/chapter/delete?id=' + id + '&fanficId=' + bookId
    );
  }
}
