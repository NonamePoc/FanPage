import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class RatingService {
  constructor(private http: HttpClient) {}

  getBookRating(id: number): Observable<any> {
    return this.http.get(
      environment.apiUrl + '/v1/detail/ratingFanfic?fanficId=' + id
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
}
