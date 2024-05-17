import { Injectable } from '@angular/core';
import {
  HttpTransportType,
  HubConnection,
  HubConnectionBuilder,
  HubConnectionState,
} from '@microsoft/signalr';
import { environment } from '../../environments/environment.development';
import { AuthService } from '../auth/auth.service';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class FollowersService {
  hubConnection!: HubConnection;
  private followersSubject = new BehaviorSubject<any[]>([]);
  followers = this.followersSubject.asObservable();

  constructor(private authService: AuthService) {}

  connect() {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(`${environment.apiUrl}/followers`, {
        accessTokenFactory: () => {
          return this.authService.user.value?.token!;
        },
        transport: HttpTransportType.LongPolling,
      })
      .withAutomaticReconnect()
      .build();

    this.hubConnection.onclose = (err) => {
      console.error('Followers hub connection FAILED', err);
    };

    this.hubConnection.start().then(() => {
      this.hubConnection.invoke('FollowerList', 1);
      this.hubConnection.on('FollowerList', (data) => {
        console.log('Followers: ', data);
        this.followersSubject.next(data);
      });
    });
  }

  disconnect() {
    if (this.hubConnection.state === HubConnectionState.Connected) {
      this.hubConnection.stop();
    }
  }
}
