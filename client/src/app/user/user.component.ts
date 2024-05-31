import { Component, OnInit } from '@angular/core';
import { UserWorksComponent } from './user-works/user-works.component';
import { UserDetailsComponent } from './user-details/user-details.component';
import { ActivatedRoute, Params } from '@angular/router';
import { UserService } from '../shared/user.service';
import { ImageNormalizePipe } from '../shared/image-normalize.pipe';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-user',
  standalone: true,
  templateUrl: './user.component.html',
  styleUrl: './user.component.css',
  imports: [
    CommonModule,
    UserWorksComponent,
    UserDetailsComponent,
    ImageNormalizePipe,
  ],
})
export class UserComponent implements OnInit {
  avatar: string = '';
  username: string = '';
  isFollowing: boolean = false;

  isLoading = true;

  constructor(
    private route: ActivatedRoute,
    private userService: UserService
  ) {}

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      const username = params['username'];
      this.userService.getUser(username).subscribe((data) => {
        this.avatar = data.avatar;
        this.username = data.username;
        this.isFollowing = data.isFollowing;
        this.isLoading = false;
      });
    });
  }
}
