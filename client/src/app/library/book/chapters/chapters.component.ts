import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChapterService } from './chapter.service';
import { ActivatedRoute, Params, Router, RouterLink } from '@angular/router';

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

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private chapterService: ChapterService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.bookId = +params['id'];
      this.chapterService
        .getChapters(this.bookId)
        .subscribe((chapters: any) => {
          this.chapters = chapters;
          this.isLoading = false;
        });
    });
  }
}
