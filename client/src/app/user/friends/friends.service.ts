import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { environment } from '../../../environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class FriendsService {
  private typeSubject = new BehaviorSubject<string>('mutuals');
  currentType = this.typeSubject.asObservable();
  followers: any[] = [];
  following: any[] = [];
  mutuals: any[] = [];

  constructor(private http: HttpClient) {}

  changeType(type: string) {
    this.typeSubject.next(type);
  }

  checkFriendTies(username: string): string {
    return this.isFollowing(username)
      ? 'following'
      : this.isFollower(username)
      ? 'follower'
      : this.isMutual(username)
      ? 'mutual'
      : 'none';
  }

  changeFriendTies(username: string): string {
    let result = 'ERROR: something went wrong with the friend ties change!';
    switch (true) {
      case this.isFollowing(username):
        this.stopFollowing(username).subscribe(() => {
          this.following = this.following.filter(
            (user) => user.username !== username
          );
          result = 'none';
        });
        return result;
      case this.isMutual(username):
        this.removeFriend(username).subscribe(() => {
          this.mutuals = this.mutuals.filter(
            (user) => user.username !== username
          );
          result = 'follower';
        });
        return result;
      case this.isFollower(username):
        this.acceptFollower(username).subscribe((data) => {
          this.followers = this.followers.filter(
            (user) => user.username !== username
          );
          this.mutuals.push({ data });
          result = 'mutual';
        });
        return result;
      default:
        this.startFollowing(username).subscribe((data) => {
          this.following.push({ data });
          result = 'following';
        });
        return result;
    }
  }

  fetchUserTies() {
    this.getMutuals().subscribe((data) => (this.mutuals = data));
    this.getFollowers().subscribe((data) => (this.followers = data));
    this.getFollowing().subscribe((data) => (this.following = data));
  }

  private isFollowing(username: string): boolean {
    return this.following.some((user) => user.username === username);
  }

  private isFollower(username: string): boolean {
    return this.followers.some((user) => user.username === username);
  }

  private isMutual(username: string): boolean {
    return this.mutuals.some((user) => user.username === username);
  }

  private getMutuals(): Observable<any> {
    return this.http.get(environment.apiUrl + '/v1/friend/List');
  }

  private getFollowers(): Observable<any> {
    return this.http.get(environment.apiUrl + '/v1/follower/List');
  }

  private getFollowing(): Observable<any> {
    return this.http.get(environment.apiUrl + '/v1/friend/UserSend');
  }

  private startFollowing(username: string): Observable<any> {
    return this.http.post(
      environment.apiUrl + '/v1/friend/Add?friendName=' + username,
      {}
    );
  }

  private acceptFollower(username: string): Observable<any> {
    return this.http.put(
      environment.apiUrl + '/v1/follower/Accept?friendName=' + username,
      {}
    );
  }

  private stopFollowing(username: string): Observable<any> {
    return this.http.delete(
      environment.apiUrl + '/v1/friend/Cancel?friendName=' + username
    );
  }

  private removeFriend(username: string): Observable<any> {
    return this.http.delete(
      environment.apiUrl + '/v1/friend/Remove?friendName=' + username
    );
  }
}
