import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { BehaviorSubject, Subject, Subscription } from 'rxjs';
import { debounceTime } from 'rxjs/operators';
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
export class ChatComponent implements OnInit, OnDestroy {
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

    this.searchSubject.pipe(debounceTime(500)).subscribe((value) => {
      this.performSearch(value);
    });

    this.chatService.hubConnection.on('Search', (data) => {
      this.chats = data;
    });
  }

  ngOnDestroy() {
    this.chatsSubscription.unsubscribe();
    this.searchSubject.complete();
  }

  onEdit(chat: any) {
    this.currentChatSubject.next(chat);
    this.modalService.openModal('chatFormModal');
  }

  onCreateChat() {
    this.currentChatSubject.next(null);
    this.modalService.openModal('chatFormModal');
  }

  onSearch($event: any) {
    this.searchSubject.next($event.target.value);
  }

  private performSearch(value: string) {
    this.chatService.hubConnection.invoke('Search', value);
  }

  private searchSubject = new Subject<string>();
}
