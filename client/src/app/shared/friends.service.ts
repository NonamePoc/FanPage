import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';

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
    const currentTies = this.checkFriendTies(username);
    console.log('currentTies: ', currentTies);
    switch (currentTies) {
      case 'following':
        this.stopFollowing(username).subscribe(() => {
          result = 'none';
          this.following = this.following.filter(
            (user) => user.friendName !== username
          );
        });
        break;
      case 'follower':
        this.acceptFollower(username).subscribe(() => {
          result = 'mutual';
          this.followers = this.followers.filter(
            (user) => user.friendName !== username
          );
        });
        break;
      case 'mutual':
        this.removeFriend(username).subscribe(() => {
          result = 'none';
          this.mutuals = this.mutuals.filter(
            (user) => user.friendName !== username
          );
        });
        break;
      case 'none':
        this.startFollowing(username).subscribe(() => {
          result = 'following';
          this.following.push({ friendName: username });
        });
        break;
    }
    return result;
  }

  fetchUserTies() {
    this.getMutuals().subscribe((data) => (this.mutuals = data));
    this.getFollowers().subscribe((data) => (this.followers = data));
    this.getFollowing().subscribe((data) => (this.following = data));
  }

  private isFollowing(username: string): boolean {
    return this.following.some((user) => user.friendName === username);
  }

  private isFollower(username: string): boolean {
    return this.followers.some((user) => user.friendName === username);
  }

  private isMutual(username: string): boolean {
    return this.mutuals.some((user) => user.friendName === username);
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
