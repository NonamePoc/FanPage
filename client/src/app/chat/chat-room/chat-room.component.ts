import { ModalService } from './../../shared/modal/modal.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router, RouterLink } from '@angular/router';
import { DropdownDirective } from '../../shared/dropdown.directive';
import { ChatService } from '../chat.service';
import { HubConnectionState } from '@microsoft/signalr';
import { ParticipantsModalComponent } from './participants-modal/participants-modal.component';
import { BehaviorSubject } from 'rxjs';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../auth/auth.service';

@Component({
  selector: 'app-chat-room',
  standalone: true,
  templateUrl: './chat-room.component.html',
  styleUrl: './chat-room.component.css',
  imports: [
    CommonModule,
    RouterLink,
    DropdownDirective,
    ParticipantsModalComponent,
  ],
})
export class ChatRoomComponent implements OnInit {
  chat: any;
  message: string = '';
  isCurrentUser: boolean = false;

  private membersSubject = new BehaviorSubject<any[]>([]);
  members = this.membersSubject.asObservable();

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private chatService: ChatService,
    private modalService: ModalService,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.chatService.connectionState.subscribe((state) => {
        if (state === HubConnectionState.Connected) {
          this.chatService.hubConnection.invoke('ChatsUser');
        }
      });

      this.chatService.hubConnection.on('ChatsUser', (joinedChats) => {
        this.chatService.chats.subscribe((publicChats) => {
          console.log('publicChats', publicChats);
          console.log('joinedChats', joinedChats);

          const chatId = +params['id'];
          console.log('chatId', chatId);
          //check if there is a chat user joined
          const isJoined = joinedChats.some((chat: any) => chat.id === chatId);
          console.log('isJoined', isJoined);

          !isJoined
            ? this.chatService.hubConnection.invoke('JoinChat', chatId)
            : this.chatService.hubConnection.invoke('GetChat', chatId);

          this.chatService.hubConnection.invoke('GetChat', chatId);
        });
      });

      this.chatService.hubConnection.on('GetChat', (data) => {
        console.log('GetChat', data);
        this.setChatandMembers(data);
      });

      this.chatService.hubConnection.on('JoinChat', (data) => {
        console.log('JoinChat', data);
        this.setChatandMembers(data);
      });
    });
  }

  onOpenParticipants() {
    this.modalService.openModal('participantsModal');
  }

  onInput($event: any) {
    this.message = $event.target.value;
  }

  sendMessage() {
    this.chatService.hubConnection.invoke('Message', +this.chat.id, {
      Content: this.message,
    });

    this.chatService.hubConnection.on('Message', (data) => {
      console.log('Content', data);
      this.chat.messages.push(data);
    });
  }

  onLeave() {
    this.chatService.hubConnection.invoke('LeaveChat', +this.chat.id);
    this.chatService.hubConnection.on('LeaveChat', () => {
      this.router.navigate(['/chat']);
    });
  }

  private setChatandMembers(data: any) {
    this.chat = data;
    this.isCurrentUser = data.chatUsers.some(
      (user: any) => user.userName === this.authService.user.value?.username
    );
    this.membersSubject.next(data.chatUsers);
  }
}
