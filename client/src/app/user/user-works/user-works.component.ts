import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from './../../auth/auth.service';
import { UserService } from '../../shared/user.service';
import { BookListComponent } from '../../library/book-list/book-list.component';
import { FilterComponent } from '../../library/book-list/filter/filter.component';

@Component({
  selector: 'app-user-works',
  standalone: true,
  templateUrl: './user-works.component.html',
  styleUrl: './user-works.component.css',
  imports: [CommonModule, BookListComponent, FilterComponent],
})
export class UserWorksComponent implements OnInit {
  username: string = '';
  isCurrentUser: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.route.params.subscribe((params) => {
      this.username = params['username'];
      this.username === this.authService.user?.getValue()?.username;
    });
  }
}
