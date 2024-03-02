import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../auth/auth.service';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class AdminService {
  constructor(private http: HttpClient) {}

  getTags(): Observable<any> {
    return this.http.get<any>(environment.apiUrl + '/v1/admin/notapproved');
  }

  approveTag(tagId: string): Observable<any> {
    return this.http.put<any>(environment.apiUrl + '/v1/admin/approve', {
      tagId,
    });
  }

  rejectTag(tagId: string): Observable<any> {
    return this.http.delete<any>(
      environment.apiUrl + '/v1/tag/delete?tagId=' + tagId
    );
  }

  banUser(userId: string, days: number): Observable<any> {
    return this.http.put<any>(environment.apiUrl + '/v1/admin/ban', {
      id: userId,
      days: days,
    });
  }

  unbanUser(userId: string): Observable<any> {
    return this.http.put<any>(environment.apiUrl + '/v1/admin/unban', {
      userId,
    });
  }

  changeRole(userId: string, role: string): Observable<any> {
    return this.http.put<any>(environment.apiUrl + '/v1/admin/role', {
      id: userId,
      newRole: role,
    });
  }

  deleteUser(userId: string): Observable<any> {
    return this.http.delete<any>(
      environment.apiUrl + '/v1/admin/user?id=' + userId
    );
  }
}
