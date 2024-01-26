import { Component } from '@angular/core';
import { UserWorksComponent } from './user-works/user-works.component';
import { UserDetailsComponent } from './user-details/user-details.component';
import { FriendsComponent } from './friends/friends.component';

@Component({
  selector: 'app-user',
  standalone: true,
  templateUrl: './user.component.html',
  styleUrl: './user.component.css',
  imports: [UserWorksComponent, UserDetailsComponent, FriendsComponent],
})
export class UserComponent {
  modalType!: string;

  showFriends(type: string) {
    this.modalType = type;
  }
}
