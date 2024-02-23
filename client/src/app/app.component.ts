import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { SideNavbarComponent } from './side-navbar/side-navbar.component';
import { AuthComponent } from './auth/auth.component';
import { HeaderComponent } from './header/header.component';
// import function to register Swiper custom elements
import { register } from 'swiper/element/bundle';
import { AuthService } from './auth/auth.service';
import { FriendsService } from './user/friends/friends.service';
// register Swiper custom elements
register();

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  imports: [
    CommonModule,
    RouterOutlet,
    SideNavbarComponent,
    HeaderComponent,
    AuthComponent,
  ],
})
export class AppComponent implements OnInit {
  title = 'client';

  constructor(
    private authService: AuthService,
    private friendService: FriendsService
  ) {}

  ngOnInit(): void {
    this.authService.autoLogin();
    // timeout
    setTimeout(() => {
      this.friendService.fetchUserTies();
    }, 1000);
  }
}
