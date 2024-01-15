import { Component } from '@angular/core';
import { SearchComponent } from './search/search.component';
import { ModalService } from '../shared/modal/modal.service';
import { DropdownDirective } from '../shared/dropdown.directive';
import { SideNavbarService } from '../side-navbar/side-navbar.service';

@Component({
  selector: 'app-header',
  standalone: true,
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
  imports: [SearchComponent, DropdownDirective],
})
export class HeaderComponent {
  constructor(
    private sideNavbarService: SideNavbarService,
    private modalService: ModalService
  ) {}

  onAuth = () => this.modalService.openModal('authModal');

  onToggleSideNavbar = () => this.sideNavbarService.toggle();
}
