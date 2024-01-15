import { DOCUMENT } from '@angular/common';
import {
  CUSTOM_ELEMENTS_SCHEMA,
  Component,
  HostListener,
  Inject,
  Input,
} from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { SwiperResponsiveDirective } from './swiper-responsive.directive';

@Component({
  selector: 'app-books-swiper',
  standalone: true,
  imports: [RouterLink, RouterLinkActive, SwiperResponsiveDirective],
  templateUrl: './books-swiper.component.html',
  styleUrl: './books-swiper.component.css',
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class BooksSwiperComponent {
  @Input() title: string = 'Recommendations for';
  @Input() accentText: string = 'you';
  @Input() bookType: string = 'recommended';
}
