import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, ActivatedRoute, Params } from '@angular/router';
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
  username: string = '';
  page: number = 1;

  constructor(
    private route: ActivatedRoute,
    private followersService: FollowersService
  ) {}

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.username = params['username'];
      this.followersService.hubConnection.invoke(
        'FollowerList',
        this.username,
        this.page
      );

      this.followersService.hubConnection.on('FollowerList', (data) => {
        this.followers = data;
      });
    });
  }

  onPagePrevious(page: number) {
    this.page < 1 ? (this.page = 1) : (this.page = page - 1);

    this.followersService.hubConnection.invoke(
      'FollowerList',
      this.username,
      this.page
    );
  }

  onPageNext(page: number) {
    this.page = page + 1;

    this.followersService.hubConnection.invoke(
      'FollowerList',
      this.username,
      this.page
    );
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
