import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment.development';
import { Observable } from 'rxjs';

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

  getChapter(id: number): Observable<any> {
    return this.http.get(
      environment.apiUrl + '/v1/chapter/chapterById?id=' + id
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

  deleteChapter(id: number): Observable<any> {
    return this.http.delete(environment.apiUrl + '/v1/chapter/delete?id=' + id);
  }
}
