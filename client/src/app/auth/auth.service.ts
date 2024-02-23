import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable, tap } from 'rxjs';

import { User } from './user.model';
import { environment } from '../../environments/environment.development';

export interface AuthResponseData {
  id: string;
  email: string;
  username: string;
  role: string;
  avatar: string;
  bannedBy: string;
  token: string;
  expirationDate: Date;
}

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  user = new BehaviorSubject<User | null>(null);
  private tokenExpirationTimer: any;

  constructor(private http: HttpClient, private router: Router) {}

  signup(
    email: string,
    username: string,
    password: string,
    confirmPassword: string
  ) {
    return this.http.post(environment.apiUrl + '/v1/account/registration', {
      Email: email,
      UserName: username,
      Password: password,
      ConfirmPassword: confirmPassword,
    });
  }

  login(email: string, password: string) {
    return this.http
      .post<AuthResponseData>(environment.apiUrl + '/v1/auth/login', {
        email: email,
        password: password,
      })
      .pipe(
        tap((resData: any) => {
          this.handleAuthentication(
            resData.id,
            resData.name,
            resData.email,
            resData.role,
            resData.userAvatar,
            resData.whoBan,
            resData.token,
            resData.lifeTimeToken
          );
        })
      );
  }

  logout() {
    this.user.next(null);
    localStorage.removeItem('userData');
    this.tokenExpirationTimer && clearTimeout(this.tokenExpirationTimer);
    this.tokenExpirationTimer = null;
    this.router.navigate(['/']);
  }

  autoLogin() {
    if (typeof window !== 'undefined' && window.localStorage) {
      const userData: {
        role: string;
        avatar: string;
        bannedBy: string;
        id: string;
        username: string;
        email: string;
        _token: string;
        _tokenExpirationDate: string;
      } = JSON.parse(localStorage.getItem('userData')!);
      if (!userData) {
        return;
      }

      const loadedUser = new User(
        userData.id,
        userData.username,
        userData.email,
        userData.role,
        userData.avatar,
        userData.bannedBy,
        userData._token,
        new Date(userData._tokenExpirationDate)
      );

      if (loadedUser.token) {
        this.user.next(loadedUser);
        const expirationDuration =
          new Date(userData._tokenExpirationDate).getTime() -
          new Date().getTime();
        this.autoLogout(expirationDuration);
      }
    }
  }

  autoLogout(expirationDuration: number) {
    this.tokenExpirationTimer = setTimeout(() => {
      console.log('auto logout', expirationDuration);
      this.logout();
    }, expirationDuration);
  }

  googleSignup(googleToken: string) {
    return this.http.post(
      environment.apiUrl +
        '/v1/account/google-registration?googleToken=' +
        googleToken,
      {}
    );
  }

  googleLogin(googleToken: string) {
    return this.http
      .post<AuthResponseData>(
        environment.apiUrl + '/v1/auth/google-login?googleToken=' + googleToken,
        {}
      )
      .pipe(
        tap((resData: any) => {
          this.handleAuthentication(
            resData.id,
            resData.name,
            resData.email,
            resData.role,
            resData.userAvatar,
            resData.whoBan,
            resData.token,
            resData.lifeTimeToken
          );
        })
      );
  }

  restorePassword(email: string): Observable<any> {
    return this.http.put(environment.apiUrl + '/v1/account/restorePassword', {
      email: email,
    });
  }

  private handleAuthentication(
    id: string,
    username: string,
    email: string,
    role: string,
    avatar: string,
    bannedBy: string,
    token: string,
    expirationDate: number
  ) {
    const user = new User(
      id,
      username,
      email,
      role,
      avatar,
      bannedBy,
      token,
      new Date(expirationDate)
    );
    this.user.next(user);
    localStorage.setItem('userData', JSON.stringify(user));
  }
}
