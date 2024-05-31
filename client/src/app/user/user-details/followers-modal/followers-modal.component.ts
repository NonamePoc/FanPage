import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, ActivatedRoute, Params } from '@angular/router';
import { ModalComponent } from '../../../shared/modal/modal.component';
import { ImageNormalizePipe } from '../../../shared/image-normalize.pipe';
import { FollowersService } from '../../../shared/followers.service';
import { Subscription } from 'rxjs';
import { DropdownDirective } from '../../../shared/dropdown.directive';
import { UserDetailsComponent } from '../user-details.component';
import { ModalService } from '../../../shared/modal/modal.service';

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
  isFollowersType: boolean = true;
  isLoading: boolean = true;
  people: any[] = [];
  username: string = '';
  page: number = 1;

  constructor(
    private route: ActivatedRoute,
    private followersService: FollowersService,
    private userDetailsComp: UserDetailsComponent,
    private modalService: ModalService
  ) {}

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.username = params['username'];
    });

    this.userDetailsComp.modalType.subscribe((type) => {
      this.isFollowersType = type;
      this.isLoading = true;

      this.isFollowersType
        ? this.invokeFollowers(this.page)
        : this.invokeFollowing(this.page);
    });

    this.followersService.hubConnection.on('FollowerList', (data) => {
      this.people = data;
      this.isLoading = false;
    });

    this.followersService.hubConnection.on('UserFollower', (data) => {
      this.people = data;
      this.isLoading = false;
    });
  }

  onPagePrevious(page: number) {
    this.page < 1 ? (this.page = 1) : (this.page = page - 1);

    this.isFollowersType
      ? this.invokeFollowers(this.page)
      : this.invokeFollowing(this.page);
  }

  onPageNext(page: number) {
    this.page = page + 1;

    this.isFollowersType
      ? this.invokeFollowers(this.page)
      : this.invokeFollowing(this.page);
  }

  closeModal() {
    this.modalService.closeModal('followers');
  }

  private invokeFollowers(page: number) {
    this.followersService.hubConnection.invoke(
      'UserFollower',
      this.username,
      page
    );
  }

  private invokeFollowing(page: number) {
    this.followersService.hubConnection.invoke(
      'FollowerList',
      this.username,
      page
    );
  }
}
