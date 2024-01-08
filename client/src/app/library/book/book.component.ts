import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { ChaptersComponent } from './chapters/chapters.component';
import { ReviewsComponent } from './reviews/reviews.component';

@Component({
  selector: 'app-book',
  standalone: true,
  templateUrl: './book.component.html',
  styleUrl: './book.component.css',
  imports: [RouterLink, ChaptersComponent, ReviewsComponent],
})
export class BookComponent {}
