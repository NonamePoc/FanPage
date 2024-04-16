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
      this.invitations = data;
    });
  }
}
