import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { BookComponent } from '../book.component';

@Component({
  selector: 'app-chapters',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './chapters.component.html',
  styleUrl: './chapters.component.css',
})
export class ChaptersComponent implements OnInit {
  chapters: any[] = [];
  isLoading = true;
  bookId!: number;

  constructor(private bookComp: BookComponent) {}

  ngOnInit(): void {
    this.bookComp.currentBook.subscribe((book) => {
      this.bookId = book.id;
      this.chapters = book.chapters;
      this.isLoading = false;
    });
  }
}
