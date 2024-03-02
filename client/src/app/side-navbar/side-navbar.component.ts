import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { AdsComponent } from './ads/ads.component';
import { MenuComponent } from './menu/menu.component';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { SideNavbarService } from './side-navbar.service';

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
  ],
})
export class SideNavbarComponent implements OnInit {
  isOpen: boolean = false;

  constructor(private sideNavbarService: SideNavbarService) {}

  ngOnInit() {
    this.sideNavbarService.isOpen.subscribe((isOpen) => {
      this.isOpen = isOpen;
    });
  }

  onToggle = () => this.sideNavbarService.toggle();
}
