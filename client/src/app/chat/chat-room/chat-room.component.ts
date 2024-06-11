import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Params, Router, RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { BehaviorSubject, Subscription } from 'rxjs';
import { HubConnectionState } from '@microsoft/signalr';
import { ParticipantsModalComponent } from './participants-modal/participants-modal.component';
import { DropdownDirective } from '../../shared/dropdown.directive';
import { ChatService } from '../chat.service';
import { ModalService } from './../../shared/modal/modal.service';
import { AuthService } from '../../auth/auth.service';
import { ScrollToBottomDirective } from './scroll.directive';

@Component({
  selector: 'app-chat-room',
  standalone: true,
  templateUrl: './chat-room.component.html',
  styleUrl: './chat-room.component.css',
  imports: [
    CommonModule,
    RouterLink,
    FormsModule,
    DropdownDirective,
    ParticipantsModalComponent,
    ScrollToBottomDirective,
  ],
})
export class ChatRoomComponent implements OnInit, OnDestroy {
  @ViewChild(ScrollToBottomDirective)
  scroll!: ScrollToBottomDirective;

  chat: any;
  currentUserName: string | undefined = '';
  isLoading: boolean = true;
  msgInput: string = '';

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
    this.authService.user.subscribe((user) => {
      this.currentUserName = user?.username;
    });
    this.route.params.subscribe((params: Params) => {
      this.connectionStateSubscription =
        this.chatService.connectionState.subscribe((state) => {
          if (state === HubConnectionState.Connected) {
            this.isLoading = true;
            this.chatService.hubConnection.invoke('GetChat', +params['id']);
          }
        });
    });

    this.chatService.hubConnection.on('GetChat', (data) => {
      this.setChatandMembers(data);
      this.isLoading = false;
      console.log('GetChat', data);
    });

    this.chatService.hubConnection.on('Message', (data) => {
      this.chat.messages.push(data);
    });
  }

  ngOnDestroy() {
    this.connectionStateSubscription.unsubscribe();
  }

  onOpenParticipants() {
    this.modalService.openModal('participantsModal');
  }

  sendMessage() {
    this.chatService.hubConnection.invoke('Message', +this.chat.id, {
      Content: this.msgInput,
    });
    this.msgInput = '';
  }

  onLeave() {
    this.chatService.hubConnection.invoke('LeaveChat', +this.chat.id);
    this.chatService.hubConnection.on('LeaveChat', () => {
      this.router.navigate(['/chat']);
    });
  }

  private setChatandMembers(data: any) {
    this.chat = data;
    this.membersSubject.next(data.chatUsers);
  }

  private connectionStateSubscription!: Subscription;
}
