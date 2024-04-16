import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ModalComponent } from '../../../shared/modal/modal.component';
import { ChatRoomComponent } from '../chat-room.component';
import { FormControl, FormGroup } from '@angular/forms';
import { FriendsService } from '../../../shared/friends.service';

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
  friends: any[] = [];
  showSearchResults: boolean = false;

  constructor(
    private chatRoomComp: ChatRoomComponent,
    private friendsService: FriendsService
  ) {}

  ngOnInit() {
    this.chatRoomComp.members.subscribe((data) => {
      this.members = data;
      this.chatId = data[0]?.chatId;
    });

    this.friends = this.friendsService.mutuals;
  }

  search($event: any) {
    const searchValue = $event.target.value;
    searchValue.length > 0 &&
      (this.friends = this.friendsService.mutuals.filter((user) =>
        user.friendName.includes(searchValue)
      ));
  }
}
