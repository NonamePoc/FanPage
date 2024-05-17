import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { ModalComponent } from '../../../shared/modal/modal.component';
import { ImageNormalizePipe } from '../../../shared/image-normalize.pipe';
import { FollowersService } from '../../../shared/followers.service';
import { Subscription } from 'rxjs';
import { DropdownDirective } from '../../../shared/dropdown.directive';

@Component({
  selector: 'app-followers-modal',
  standalone: true,
  imports: [
    CommonModule,
    DropdownDirective,
    ModalComponent,
    RouterLink,
    ImageNormalizePipe,
  ],
  templateUrl: './followers-modal.component.html',
  styleUrl: './followers-modal.component.css',
})
export class FollowersModalComponent implements OnInit {
  followers: any[] = [];
  page: number = 1;

  private followersSubscription!: Subscription;

  constructor(private followersService: FollowersService) {}

  ngOnInit() {
    this.followersSubscription = this.followersService.followers.subscribe(
      (data) => {
        this.followers = data;
      }
    );
  }

  onPagePrevious(page: number) {
    this.page < 1 ? (this.page = 1) : (this.page = page - 1);

    this.followersService.hubConnection.invoke('GetFollowers', this.page);
  }

  onPageNext(page: number) {
    this.page = page + 1;

    this.followersService.hubConnection.invoke('GetFollowers', this.page);
  }

  onRemove(follower: any) {
    console.log('Removing follower...', follower);

    this.followersService.hubConnection.invoke('Unsubscribe', follower.subName);
    this.followersService.hubConnection.on('Unsubscribe', (data) => {
      console.log('Unsubscribed from: ', data);
      /* this.followers = this.followers.filter(
        (follower) => follower.userName !== data
      ); */
    });
  }
}
