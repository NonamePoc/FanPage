import { Component, OnInit } from '@angular/core';
import { BookListComponent } from '../../library/book-list/book-list.component';
import { FilterComponent } from '../../library/filter/filter.component';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-works',
  standalone: true,
  templateUrl: './user-works.component.html',
  styleUrl: './user-works.component.css',
  imports: [BookListComponent, FilterComponent],
})
export class UserWorksComponent implements OnInit {
  username: string = '';

  constructor(private route: ActivatedRoute) {}

  ngOnInit() {
    this.route.params.subscribe((params) => {
      this.username = params['username'];
    });
  }
}
