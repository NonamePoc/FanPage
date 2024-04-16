import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

import { AuthService } from './../../auth/auth.service';
import { UserService } from '../../shared/user.service';
import { ChatService } from '../../chat/chat.service';
import { BookListComponent } from '../../library/book-list/book-list.component';
import { FilterComponent } from '../../library/book-list/filter/filter.component';

@Component({
  selector: 'app-user-works',
  standalone: true,
  templateUrl: './user-works.component.html',
  styleUrl: './user-works.component.css',
  imports: [CommonModule, BookListComponent, FilterComponent],
})
export class UserWorksComponent implements OnInit {
  username: string = '';
  user: any;
  isCurrentUser: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private toastr: ToastrService,
    private userService: UserService,
    private authService: AuthService,
    private chatService: ChatService
  ) {}

  ngOnInit() {
    this.route.params.subscribe((params) => {
      this.username = params['username'];
      this.userService.getUser(this.username).subscribe((data) => {
        this.user = data;
        this.isCurrentUser =
          data?.username === this.authService.user?.getValue()?.username;
      });
    });
  }

  onChat() {
    this.chatService.hubConnection.invoke('Create', {
      Name: this.username + '&' + this.authService.user?.getValue()?.username,
      Description: 'Private chat',
      Type: 'private',
      FriendId: this.user.id,
    });

    this.toastr.info('User was invited to chat', 'Chat invitation sent!');
  }
}
