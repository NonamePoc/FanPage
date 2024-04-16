import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { ModalService } from '../shared/modal/modal.service';
import { EditChatComponent } from './edit-chat/edit-chat.component';
import { InvitationsComponent } from './invitations/invitations.component';
import { ChatService } from './chat.service';
import { CommonModule } from '@angular/common';
import { BehaviorSubject, Subscription } from 'rxjs';
import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'app-chat',
  standalone: true,
  templateUrl: './chat.component.html',
  styleUrl: './chat.component.css',
  imports: [CommonModule, RouterLink, EditChatComponent, InvitationsComponent],
})
export class ChatComponent implements OnInit {
  currentUsername!: string;
  joinedChats: any[] = [];
  publicChats: any[] = [];

  private joinedChatsSubscription!: Subscription;
  private publicChatsSubscription!: Subscription;

  private currentChatSubject = new BehaviorSubject<any>(null);
  chat = this.currentChatSubject.asObservable();

  constructor(
    private modalService: ModalService,
    private authService: AuthService,
    private chatService: ChatService
  ) {}

  ngOnInit() {
    this.currentUsername = this.authService.user.value?.username!;
    this.publicChatsSubscription = this.chatService.publicChats.subscribe(
      (data) => {
        this.publicChats = data;
      }
    );
    this.joinedChatsSubscription = this.chatService.chats.subscribe((data) => {
      this.joinedChats = data;
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
      this.publicChats = data;
    });
  }
}
