import { Component } from '@angular/core';
import { BooksSwiperComponent } from './books-swiper/books-swiper.component';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
  imports: [RouterLink, BooksSwiperComponent],
})
export class HomeComponent {}
