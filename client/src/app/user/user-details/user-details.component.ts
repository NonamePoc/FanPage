import { CommonModule } from '@angular/common';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ModalService } from '../../shared/modal/modal.service';
import { ImageNormalizePipe } from '../../shared/image-normalize.pipe';
import { AuthService } from '../../auth/auth.service';
import { User } from '../../auth/user.model';
import { UserService } from '../../shared/user.service';
import { FriendsService } from '../friends/friends.service';

@Component({
  selector: 'app-user-details',
  standalone: true,
  templateUrl: './user-details.component.html',
  styleUrl: './user-details.component.css',
  imports: [CommonModule, ImageNormalizePipe],
})
export class UserDetailsComponent implements OnInit {
  @Output() modalType = new EventEmitter<string>();

  user: User | null = null;
  isLoading: boolean = true;
  isCurrentUser: boolean = false;
  friendType!: string;

  constructor(
    private modalService: ModalService,
    private authService: AuthService,
    private userService: UserService,
    private route: ActivatedRoute,
    private friendService: FriendsService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      const username = params['username'];
      this.userService.getUser(username).subscribe((data) => {
        this.user = data;
        this.isCurrentUser =
          this.user?.username === this.authService.user?.getValue()?.username;
      });
      this.friendType = this.friendService.checkFriendTies(username);
      this.isLoading = false;
    });
  }

  getButtonText() {
    return this.friendType === 'following' || this.friendType === 'mutual'
      ? 'Unfollow'
      : 'Follow';
  }

  onFollow() {
    this.friendType = this.friendService.changeFriendTies(this.user?.username!);
  }

  showFriendsModal(type: string) {
    this.modalType.emit(type);
    this.modalService.openModal('friendsModal');
  }
}
