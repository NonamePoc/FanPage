import { DOCUMENT } from '@angular/common';
import {
  CUSTOM_ELEMENTS_SCHEMA,
  Component,
  HostListener,
  Inject,
} from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-books-swiper',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './books-swiper.component.html',
  styleUrl: './books-swiper.component.css',
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class BooksSwiperComponent {
  slidesPerView: number = 3;
  screenWidth!: number;

  constructor(@Inject(DOCUMENT) private document: Document) {
    this.getScreenWidth();
  }

  @HostListener('window:resize', ['$event'])
  getScreenWidth() {
    if (this.document.defaultView) {
      this.screenWidth = this.document.defaultView.innerWidth;
      this.screenWidth <= 1400
        ? (this.slidesPerView = 1)
        : (this.slidesPerView = 3);
    }
  }
}
