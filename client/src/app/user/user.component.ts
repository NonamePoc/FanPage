import { Component } from '@angular/core';
import { UserMenuComponent } from './user-menu/user-menu.component';
import { UserDetailsComponent } from './user-details/user-details.component';

@Component({
  selector: 'app-user',
  standalone: true,
  templateUrl: './user.component.html',
  styleUrl: './user.component.css',
  imports: [UserMenuComponent, UserDetailsComponent],
})
export class UserComponent {}
