import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { HubConnectionState } from '@microsoft/signalr';
import { ToastrService } from 'ngx-toastr';
import { ModalComponent } from '../../../shared/modal/modal.component';
import { ChatRoomComponent } from '../chat-room.component';
import { FollowersService } from '../../../shared/followers.service';
import { ChatService } from '../../chat.service';
import { AuthService } from '../../../auth/auth.service';
import { ModalService } from './../../../shared/modal/modal.service';

@Component({
  selector: 'app-participants-modal',
  standalone: true,
  imports: [CommonModule, ModalComponent],
  templateUrl: './participants-modal.component.html',
  styleUrl: './participants-modal.component.css',
})
export class ParticipantsModalComponent implements OnInit {
  chatId!: number;
  members: any[] = [];
  followers: any[] = [];
  filteredFollowers: any[] = [];
  showSearchResults: boolean = false;

  constructor(
    private toastr: ToastrService,
    private chatRoomComp: ChatRoomComponent,
    private modalService: ModalService,
    private followersService: FollowersService,
    private chatService: ChatService,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.chatRoomComp.members.subscribe((data) => {
      this.members = data;
      this.chatId = data[0]?.chatId;
    });

    this.connectionStateSubscription =
      this.chatService.connectionState.subscribe((state) => {
        if (state === HubConnectionState.Connected) {
          this.followersService.hubConnection.invoke(
            'UserFollower',
            this.authService.user.value?.username,
            1
          );
        }
      });

    this.followersService.hubConnection.on('UserFollower', (data) => {
      this.followers = data;
    });
  }

  search($event: any) {
    const searchValue = $event.target.value;
    searchValue.length > 0 && (this.showSearchResults = true);

    this.filteredFollowers = this.followers.filter(
      (f) =>
        f.subName.toLowerCase().includes(searchValue.toLowerCase()) &&
        !this.members.some(
          (m) => m.subName.toLowerCase() === f.subName.toLowerCase()
        )
    );
  }

  sendInvitation(username: string) {
    this.chatService.hubConnection.invoke('InviteUsers', this.chatId, [
      {
        UserName: username,
      },
    ]);

    this.chatService.hubConnection.on('InviteUsers', (data) => {
      this.toastr.success('Invitation sent to ' + username);
      this.modalService.closeModal('participantsModal');
    });
  }

  private connectionStateSubscription!: Subscription;
}
