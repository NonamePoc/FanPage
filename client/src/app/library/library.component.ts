import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { BookListComponent } from './book-list/book-list.component';

@Component({
  selector: 'app-library',
  standalone: true,
  templateUrl: './library.component.html',
  styleUrl: './library.component.css',
  imports: [CommonModule, RouterLink, BookListComponent],
})
export class LibraryComponent {
  isReadingMode: boolean = true;

  onReadingMode() {
    this.isReadingMode = true;
  }

  onWritingMode() {
    this.isReadingMode = false;
  }
}
