import { User } from './../auth/user.model';
import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { SearchComponent } from './search/search.component';
import { ModalService } from '../shared/modal/modal.service';
import { DropdownDirective } from '../shared/dropdown.directive';
import { SideNavbarService } from '../side-navbar/side-navbar.service';
import { AuthService } from '../auth/auth.service';
import { ToastrService } from 'ngx-toastr';
import { ImageNormalizePipe } from '../shared/image-normalize.pipe';

@Component({
  selector: 'app-header',
  standalone: true,
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
  imports: [
    CommonModule,
    SearchComponent,
    DropdownDirective,
    ImageNormalizePipe,
  ],
})
export class HeaderComponent implements OnInit {
  isAuthenticated = false;
  user?: User | null;

  constructor(
    public authService: AuthService,
    private sideNavbarService: SideNavbarService,
    private modalService: ModalService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.authService.user.subscribe((user) => {
      this.isAuthenticated = !!user;
      this.user = user;
    });
  }

  onAuth(): void {
    this.isAuthenticated
      ? (this.authService.logout(),
        this.toastr.info('You have been logged out', 'Logout'))
      : this.modalService.openModal('authModal');
  }

  onToggleSideNavbar = () => this.sideNavbarService.toggle();
}