import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { AdsComponent } from './ads/ads.component';
import { MenuComponent } from './menu/menu.component';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { AdminMenuComponent } from './admin-menu/admin-menu.component';

@Component({
  selector: 'app-side-navbar',
  standalone: true,
  templateUrl: './side-navbar.component.html',
  styleUrl: './side-navbar.component.css',
  imports: [
    CommonModule,
    RouterLink,
    RouterLinkActive,
    AdsComponent,
    MenuComponent,
    AdminMenuComponent,
  ],
})
export class SideNavbarComponent {
  isAdmin: boolean = false;
}
