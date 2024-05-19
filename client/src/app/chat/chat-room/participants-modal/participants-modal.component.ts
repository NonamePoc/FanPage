import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ModalComponent } from '../../../shared/modal/modal.component';
import { ChatRoomComponent } from '../chat-room.component';
import { FollowersService } from '../../../shared/followers.service';
import { ChatService } from '../../chat.service';
import { ToastrService } from 'ngx-toastr';

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
    private followersService: FollowersService,
    private chatService: ChatService
  ) {}

  ngOnInit() {
    this.chatRoomComp.members.subscribe((data) => {
      this.members = data;
      this.chatId = data[0]?.chatId;
    });

    /* this.followersService.followers.subscribe((data) => {
      this.followers = data;
      this.filteredFollowers = data;
    }); */
  }

  search($event: any) {
    const searchValue = $event.target.value;
    searchValue.length > 0 && (this.showSearchResults = true);

    this.filteredFollowers = this.followers.filter((f) =>
      f.userName.toLowerCase().includes(searchValue.toLowerCase())
    );
  }

  sendInvitation(username: string) {
    console.log('Inviting', username, 'to chat', this.chatId);
    this.chatService.hubConnection.invoke('InviteUsers', this.chatId, [
      {
        UserName: username,
      },
    ]);

    this.chatService.hubConnection.on('InviteUsers', (data) => {
      console.log('InviteUsers', data);
      this.toastr.success('Invitation sent to ' + username);
    });
  }
}
