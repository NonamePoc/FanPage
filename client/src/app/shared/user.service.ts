import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '../../environments/environment.development';
import { AuthService } from '../auth/auth.service';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient, private authService: AuthService) {}

  getUser(username: string): Observable<any> {
    if (username === this.authService.user?.getValue()?.username)
      return this.authService.user;
    else
      return this.http
        .get<any>(
          environment.apiUrl + '/v1/account/getProfile?userName=' + username
        )
        .pipe(
          map((user: any) => {
            return {
              id: user.id,
              email: user.email,
              username: user.name,
              role: user.role,
              avatar: user.userAvatar,
              bannedBy: user.whoBan,
              isFollowing: user.isSubscribed,
              _token: user.token,
              _expirationDate: user.lifeTimeToken,
            };
          })
        );
  }

  changeUsername(username: string): Observable<any> {
    return this.http.put<any>(
      environment.apiUrl + '/v1/account/changeUserName?userName=' + username,
      {}
    );
  }

  changeEmail(email: string): Observable<any> {
    return this.http.put<any>(environment.apiUrl + '/v1/account/changeEmail', {
      newEmail: email,
    });
  }

  changePassword(data: any): Observable<any> {
    return this.http.put<any>(
      environment.apiUrl + '/v1/account/changePassword',
      {
        password: data.password,
        newPassword: data.newPassword,
        confirmPassword: data.newConfirmPassword,
      }
    );
  }

  changeAvatar(image: any): Observable<any> {
    const formData = new FormData();
    formData.append('avatar', image);
    return this.http.post<any>(
      environment.apiUrl + '/v1/account/changeAvatar',
      formData
    );
  }
}
