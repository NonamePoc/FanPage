import { Directive, ElementRef, HostListener, NgZone } from '@angular/core';

@Directive({
  selector: '[appDropdown]',
  standalone: true,
})
export class DropdownDirective {
  private isOpen = false;

  @HostListener('document:click', ['$event'])
  toggleOpen(event: Event) {
    this.isOpen =
      this.elRef.nativeElement.contains(event.target) && !this.isOpen;

    this.updateDropdown();
  }

  private updateDropdown() {
    this.zone.runOutsideAngular(() => {
      setTimeout(() => {
        this.zone.run(() => {
          const nextSibling = this.elRef.nativeElement.nextElementSibling;
          if (nextSibling) {
            nextSibling.classList.toggle('open', this.isOpen);
          }
        });
      }, 0);
    });
  }

  constructor(private elRef: ElementRef, private zone: NgZone) {}
}
