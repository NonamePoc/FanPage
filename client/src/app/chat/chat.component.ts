import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { BehaviorSubject, Subscription } from 'rxjs';
import { ModalService } from '../shared/modal/modal.service';
import { ChatService } from './chat.service';
import { AuthService } from '../auth/auth.service';
import { EditChatComponent } from './edit-chat/edit-chat.component';
import { InvitationsComponent } from './invitations/invitations.component';

@Component({
  selector: 'app-chat',
  standalone: true,
  templateUrl: './chat.component.html',
  styleUrl: './chat.component.css',
  imports: [CommonModule, RouterLink, EditChatComponent, InvitationsComponent],
})
export class ChatComponent implements OnInit {
  currentUsername!: string;
  chats: any[] = [];

  private chatsSubscription!: Subscription;
  private currentChatSubject = new BehaviorSubject<any>(null);
  chat = this.currentChatSubject.asObservable();

  constructor(
    private modalService: ModalService,
    private authService: AuthService,
    private chatService: ChatService
  ) {}

  ngOnInit() {
    this.currentUsername = this.authService.user.value?.username!;
    this.chatsSubscription = this.chatService.chats.subscribe((data) => {
      this.chats = data;
    });
  }

  onEdit(chat: any) {
    this.currentChatSubject.next(chat);
    this.modalService.openModal('chatFormModal');
  }

  onCreateChat() {
    this.currentChatSubject.next(null);
    this.modalService.openModal('chatFormModal');
  }

  search($event: any) {
    this.chatService.hubConnection.invoke('Search', $event.target.value);

    this.chatService.hubConnection.on('Search', (data) => {
      this.chats = data;
    });
  }
}
