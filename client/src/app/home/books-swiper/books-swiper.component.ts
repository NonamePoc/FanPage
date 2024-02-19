import { CommonModule } from '@angular/common';
import {
  CUSTOM_ELEMENTS_SCHEMA,
  Component,
  Input,
  OnInit,
} from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { SwiperResponsiveDirective } from './swiper-responsive.directive';
import { BookService } from '../../library/book.service';
import { Observable } from 'rxjs';
import { ImageNormalizePipe } from '../../shared/image-normalize.pipe';

@Component({
  selector: 'app-books-swiper',
  standalone: true,
  templateUrl: './books-swiper.component.html',
  styleUrl: './books-swiper.component.css',
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  imports: [
    CommonModule,
    RouterLink,
    RouterLinkActive,
    SwiperResponsiveDirective,
    ImageNormalizePipe,
  ],
})
export class BooksSwiperComponent implements OnInit {
  @Input() title: string = 'Popular';
  @Input() accentText: string = 'now';
  @Input() bookType: string = 'popular';
  @Input() books: any[] = [];

  constructor(private bookService: BookService) {}

  ngOnInit(): void {
    if (typeof localStorage !== 'undefined') {
      this.bookType === 'popular'
        ? this.bookService.getPopularBooks().subscribe((books: any) => {
            this.books = books;
          })
        : this.bookService.getLatestBooks().subscribe((books: any) => {
            this.books = books;
          });
    }
  }
}
