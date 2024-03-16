import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import {
  HubConnection,
  HubConnectionBuilder,
  HubConnectionState,
  LogLevel,
} from '@microsoft/signalr';
import { AuthService } from '../auth/auth.service';

@Injectable({
  providedIn: 'root',
})
export class ChatService {
  private hubConnection!: HubConnection;

  constructor(private authService: AuthService) {}

  connect() {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(`${environment.apiUrl}/chatHub`, {
        accessTokenFactory: () => {
          return this.authService.user.value?.token!;
        },
      })
      .configureLogging(LogLevel.Trace)
      .build();

    this.hubConnection
      .start()
      .then(() => {
        console.log('Connection started');
      })
      .catch((err) => console.error('Error while starting connection: ' + err));
  }

  createChat(data: any) {
    if (this.hubConnection.state !== HubConnectionState.Connected) {
      console.error('Connection is not established');
    }
    this.hubConnection.invoke('CreateChat', data);
    this.hubConnection.on('CreateChat', () => {
      console.log('Chat created');
    });
  }

  disconnect() {
    if (this.hubConnection.state === HubConnectionState.Connected) {
      this.hubConnection.stop();
    }
  }
}
