import { Component } from '@angular/core';
import { BookListComponent } from '../../library/book-list/book-list.component';
import { FilterComponent } from '../../library/filter/filter.component';

@Component({
  selector: 'app-user-works',
  standalone: true,
  templateUrl: './user-works.component.html',
  styleUrl: './user-works.component.css',
  imports: [BookListComponent, FilterComponent],
})
export class UserWorksComponent {}
