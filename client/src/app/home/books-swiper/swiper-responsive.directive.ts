import { DOCUMENT } from '@angular/common';
import { Directive, ElementRef, HostListener, Inject } from '@angular/core';

@Directive({
  selector: '[appSwiperResponsive]',
  standalone: true,
})
export class SwiperResponsiveDirective {
  slidesPerView: number = 3;
  screenWidth!: number;

  constructor(
    @Inject(DOCUMENT) private document: Document,
    private elRef: ElementRef
  ) {
    this.getScreenWidth();
  }

  @HostListener('window:resize', ['$event'])
  getScreenWidth() {
    if (this.document.defaultView) {
      this.screenWidth = this.document.defaultView.innerWidth;
      this.screenWidth <= 1400
        ? this.elRef.nativeElement.setAttribute('slides-per-view', '1')
        : this.elRef.nativeElement.setAttribute('slides-per-view', '3');
    }
  }
}
