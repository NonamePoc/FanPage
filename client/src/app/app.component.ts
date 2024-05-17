import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { Subscription } from 'rxjs';
import { register } from 'swiper/element/bundle';

import { SideNavbarComponent } from './side-navbar/side-navbar.component';
import { AuthComponent } from './auth/auth.component';
import { HeaderComponent } from './header/header.component';
import { AuthService } from './auth/auth.service';
import { ThemeService } from './shared/theme.service';
import { ChatService } from './chat/chat.service';
import { FollowersService } from './shared/followers.service';

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
  isDarkMode: boolean = false;
  private themeSubscription!: Subscription;

  constructor(
    private authService: AuthService,
    private themeService: ThemeService,
    private chatService: ChatService,
    private followerService: FollowersService
  ) {}

  ngOnInit(): void {
    this.authService.autoLogin();

    this.themeSubscription = this.themeService.isDarkMode.subscribe(
      (isDarkMode) => {
        this.isDarkMode = isDarkMode;
      }
    );
    if (this.authService.user.value?.token) {
      this.chatService.connect();
      this.followerService.connect();
    }
  }
}
