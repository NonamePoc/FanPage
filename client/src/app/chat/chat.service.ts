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
export class ChatService {
  hubConnection!: HubConnection;

  private connectionStateSubject = new BehaviorSubject<HubConnectionState>(
    HubConnectionState.Disconnected
  );
  connectionState = this.connectionStateSubject.asObservable();
  private chatsSubject = new BehaviorSubject<any[]>([]);
  chats = this.chatsSubject.asObservable();
  private invitesSubject = new BehaviorSubject<any[]>([]);
  invites = this.invitesSubject.asObservable();

  constructor(private authService: AuthService) {}

  connect() {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(`${environment.apiUrl}/chat`, {
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

      this.hubConnection.invoke('GlobalChats');
      this.hubConnection.invoke('ChatsRequestUser');

      this.hubConnection.on('GlobalChats', (data) => {
        this.chatsSubject.next(data);
      });

      this.hubConnection.on('ChatRequestUser', (data) => {
        this.invitesSubject.next(data);
      });
    });
  }

  disconnect() {
    if (this.hubConnection.state === HubConnectionState.Connected) {
      this.hubConnection.stop();
    }
  }
}
