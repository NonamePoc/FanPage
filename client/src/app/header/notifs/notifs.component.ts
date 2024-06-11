import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { HubConnectionState } from '@microsoft/signalr';
import { DropdownDirective } from '../../shared/dropdown.directive';
import { AuthService } from '../../auth/auth.service';
import { ChatService } from '../../chat/chat.service';

@Component({
  selector: 'app-notifs',
  standalone: true,
  imports: [CommonModule, DropdownDirective],
  templateUrl: './notifs.component.html',
  styleUrl: './notifs.component.css',
})
export class NotifsComponent implements OnInit {
  @Input() isAuthenticated: boolean = false;
  notifications: any[] = [];
  currentUserName: string | undefined = '';

  constructor(
    private authService: AuthService,
    private chatService: ChatService
  ) {}

  ngOnInit(): void {
    this.connectionStateSubscription =
      this.chatService.connectionState.subscribe((state) => {
        if (state === HubConnectionState.Connected) {
          this.chatService.hubConnection.on('Message', (data) => {
            console.log('notifs', data);
            data.userName !== this.authService.user.value?.username &&
              this.notifications.push(data);
          });
        }
      });
  }

  private connectionStateSubscription!: Subscription;
}
