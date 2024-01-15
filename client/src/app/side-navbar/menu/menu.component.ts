import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { SideNavbarService } from '../side-navbar.service';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css',
})
export class MenuComponent {
  constructor(private sideNavbarService: SideNavbarService) {}

  onRouterLinkClick = () => this.sideNavbarService.toggle();
}
