import { CommonModule } from '@angular/common';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { ModalService } from '../../shared/modal/modal.service';
import { ImageNormalizePipe } from '../../shared/image-normalize.pipe';
import { AuthService } from '../../auth/auth.service';
import { User } from '../../auth/user.model';
import { UserService } from '../../shared/user.service';
import { FollowersService } from '../../shared/followers.service';
import { FollowersModalComponent } from './followers-modal/followers-modal.component';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-user-details',
  standalone: true,
  templateUrl: './user-details.component.html',
  styleUrl: './user-details.component.css',
  imports: [CommonModule, ImageNormalizePipe, FollowersModalComponent],
})
export class UserDetailsComponent implements OnInit {
  user: User | null = null;
  isLoading: boolean = true;
  isCurrentUser: boolean = false;
  followersCount: number = 0;

  private followersSubscription!: Subscription;

  constructor(
    private modalService: ModalService,
    private authService: AuthService,
    private userService: UserService,
    private route: ActivatedRoute,
    private followersService: FollowersService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      const username = params['username'];
      this.userService.getUser(username).subscribe((data) => {
        this.user = data;
        console.log('User: ', this.user);
        this.isCurrentUser =
          this.user?.username === this.authService.user?.getValue()?.username;
      });
      this.isLoading = false;

      this.followersSubscription = this.followersService.followers.subscribe(
        (data) => {
          this.followersCount = data.length;
        }
      );
    });
  }

  onFollow() {
    this.followersService.hubConnection.invoke(
      'Subscribe',
      this.user?.username
    );
    this.followersService.hubConnection.on('Subscribe', (data) => {
      console.log('Subscribed to: ', data);
    });
  }

  openFollowersModal() {
    this.modalService.openModal('followers');
  }
}
