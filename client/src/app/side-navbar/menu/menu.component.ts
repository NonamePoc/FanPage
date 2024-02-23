import { Component, OnInit } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { SideNavbarService } from '../side-navbar.service';
import { AuthService } from '../../auth/auth.service';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css',
})
export class MenuComponent implements OnInit {
  username?: string;

  constructor(
    private sideNavbarService: SideNavbarService,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.authService.user.subscribe((user) => {
      this.username = user?.username;
    });
  }

  onRouterLinkClick = () => this.sideNavbarService.toggle();
}
