import { Injectable } from '@angular/core';
import {
  HttpTransportType,
  HubConnection,
  HubConnectionBuilder,
  HubConnectionState,
} from '@microsoft/signalr';
import { BehaviorSubject } from 'rxjs';
import { AuthService } from '../../../../../auth/auth.service';
import { environment } from '../../../../../../environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class CommentService {
  hubConnection!: HubConnection;

  private connectionStateSubject = new BehaviorSubject<HubConnectionState>(
    HubConnectionState.Disconnected
  );
  connectionState = this.connectionStateSubject.asObservable();

  constructor(private authService: AuthService) {}

  connect() {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(`${environment.apiUrl}/comment`, {
        accessTokenFactory: () => {
          return this.authService.user.value?.token!;
        },
        transport: HttpTransportType.LongPolling,
      })
      .withAutomaticReconnect()
      .build();

    this.hubConnection.onclose = (err) => {
      console.error('Chat hub connection FAILED', err);
    };

    this.hubConnection.start().then(() => {
      this.connectionStateSubject.next(this.hubConnection.state);
    });
  }

  disconnect() {
    this.hubConnection.stop();
  }
}
