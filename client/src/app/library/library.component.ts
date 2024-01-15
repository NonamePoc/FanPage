import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { FilterComponent } from './book/filter/filter.component';
import { BookListComponent } from './book/book-list/book-list.component';

@Component({
  selector: 'app-library',
  standalone: true,
  templateUrl: './library.component.html',
  styleUrl: './library.component.css',
  imports: [CommonModule, RouterLink, FilterComponent, BookListComponent],
})
export class LibraryComponent {
  isReadingMode: boolean = true;

  onReadingMode() {
    this.isReadingMode = true;
    console.log('onReadingMode()', this.isReadingMode);
  }

  onWritingMode() {
    this.isReadingMode = false;
    console.log('onWritingMode', this.isReadingMode);
  }
}
