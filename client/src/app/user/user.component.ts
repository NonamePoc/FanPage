import { Component } from '@angular/core';
import { UserWorksComponent } from './user-works/user-works.component';
import { UserDetailsComponent } from './user-details/user-details.component';

@Component({
  selector: 'app-user',
  standalone: true,
  templateUrl: './user.component.html',
  styleUrl: './user.component.css',
  imports: [UserWorksComponent, UserDetailsComponent],
})
export class UserComponent {}
