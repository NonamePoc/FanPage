import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { ModalService } from '../../shared/modal/modal.service';
import { ImageNormalizePipe } from '../../shared/image-normalize.pipe';
import { AuthService } from '../../auth/auth.service';
import { User } from '../../auth/user.model';
import { UserService } from '../../shared/user.service';
import { FollowersService } from '../../shared/followers.service';
import { FollowersModalComponent } from './followers-modal/followers-modal.component';
import { BehaviorSubject, Subscription } from 'rxjs';

@Component({
  selector: 'app-user-details',
  standalone: true,
  templateUrl: './user-details.component.html',
  styleUrl: './user-details.component.css',
  imports: [CommonModule, ImageNormalizePipe, FollowersModalComponent],
})
export class UserDetailsComponent implements OnInit {
  @Input() avatar: string = '';
  @Input() isFollowing: boolean = false;

  username: string = '';
  isLoading: boolean = true;
  isCurrentUser: boolean = false;

  private currentModalTypeSubject = new BehaviorSubject<boolean>(true);
  modalType = this.currentModalTypeSubject.asObservable();
  private followersSubscription!: Subscription;

  constructor(
    private modalService: ModalService,
    private authService: AuthService,
    private route: ActivatedRoute,
    private followersService: FollowersService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.username = params['username'];
      this.isCurrentUser =
        this.username === this.authService.user?.getValue()?.username;
    });
    this.isLoading = false;
  }

  onFollow() {
    this.isFollowing ? this.unfollow() : this.follow();
  }

  openFollowersModal() {
    this.currentModalTypeSubject.next(true);
    this.modalService.openModal('followers');
  }

  openFollowingModal() {
    this.currentModalTypeSubject.next(false);
    this.modalService.openModal('followers');
  }

  private follow() {
    this.followersService.hubConnection.invoke('Subscribe', this.username);
    this.followersService.hubConnection.on('Subscribe', (data) => {
      console.log('Subscribed to: ', data);
      this.isFollowing = true;
    });
  }

  private unfollow() {
    this.followersService.hubConnection.invoke('Unsubscribe', this.username);
    this.followersService.hubConnection.on('Unsubscribe', (data) => {
      console.log('Unsubscribed from: ', data);
      this.isFollowing = false;
    });
  }
}
