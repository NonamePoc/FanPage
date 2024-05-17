import { CUSTOM_ELEMENTS_SCHEMA, Component, OnInit } from '@angular/core';
import { ChatService } from '../chat.service';
import { CommonModule } from '@angular/common';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-invitations',
  standalone: true,
  imports: [CommonModule],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  templateUrl: './invitations.component.html',
  styleUrl: './invitations.component.css',
})
export class InvitationsComponent implements OnInit {
  invitations: any[] = [];

  private inviteSubscription!: Subscription;

  constructor(private chatService: ChatService) {}

  ngOnInit(): void {
    this.inviteSubscription = this.chatService.invites.subscribe((data) => {
      console.log('Invitations: ', data);
      this.invitations = data;
    });
  }

  onAccept(inviteId: number) {
    this.chatService.hubConnection.invoke('UserAccept', inviteId);
    this.chatService.hubConnection.on('UserAccept', () => {
      this.invitations = this.invitations.filter((i) => i.id !== inviteId);
    });
  }

  onDecline(inviteId: number) {
    this.chatService.hubConnection.invoke('UserDecline', inviteId);
    this.chatService.hubConnection.on('UserDecline', () => {
      this.invitations = this.invitations.filter((i) => i.id !== inviteId);
    });
  }
}
