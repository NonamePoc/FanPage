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
import { ThemeService } from './shared/theme.service';
import { Subscription } from 'rxjs';
import { ChatService } from './chat/chat.service';
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
  isDarkMode: boolean = false;
  private themeSubscription!: Subscription;

  constructor(
    private authService: AuthService,
    private themeService: ThemeService,
    private friendService: FriendsService,
    private chatService: ChatService
  ) {}

  ngOnInit(): void {
    this.authService.autoLogin();
    this.themeSubscription = this.themeService.isDarkMode.subscribe((value) => {
      this.isDarkMode = value;
    });
    if (this.authService.user.value) {
      this.friendService.fetchUserTies();
      this.chatService.connect();
    }
  }
}
