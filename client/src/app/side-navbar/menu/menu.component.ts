import { Component, OnInit } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { SideNavbarService } from '../side-navbar.service';
import { AuthService } from '../../auth/auth.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [CommonModule, RouterLink, RouterLinkActive],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css',
})
export class MenuComponent implements OnInit {
  username?: string;
  isAdmin: boolean = false;

  constructor(
    private sideNavbarService: SideNavbarService,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.authService.user.subscribe((user) => {
      this.username = user?.username;
      this.isAdmin = user?.role === 'Admin';
    });
  }

  onRouterLinkClick = () => this.sideNavbarService.toggle();
}
