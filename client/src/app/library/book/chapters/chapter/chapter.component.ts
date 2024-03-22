import { CommonModule } from '@angular/common';
import { ActivatedRoute, Params, Router, RouterLink } from '@angular/router';
import { Component, HostListener, OnInit } from '@angular/core';
import { CommentsComponent } from './comments/comments.component';
import { ChapterService } from '../chapter.service';
import { ImageNormalizePipe } from '../../../../shared/image-normalize.pipe';

@Component({
  selector: 'app-chapter',
  standalone: true,
  templateUrl: './chapter.component.html',
  styleUrl: './chapter.component.css',
  imports: [CommonModule, RouterLink, CommentsComponent, ImageNormalizePipe],
})
export class ChapterComponent implements OnInit {
  @HostListener('window:scroll', ['$event'])
  onScroll(event: any) {
    const scrollPosition = window.scrollY;
    const documentHeight = document.documentElement.scrollHeight;
    const viewportHeight = window.innerHeight;

    const scrolledPercentage =
      scrollPosition / (documentHeight - viewportHeight);

    console.log('User scrolled to:', scrolledPercentage * 100, '%');
  }

  bookId!: number;
  chapterId!: number;
  chapter: any;
  isLoading = true;
  notFound = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private chapterService: ChapterService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.bookId = +params['id'];
      this.chapterId = +params['chapterId'];
      this.chapterService.getChapter(this.chapterId, this.bookId).subscribe({
        next: (data: any) => {
          this.chapter = data;
          this.isLoading = false;
          this.notFound = false;
        },
        error: () => {
          this.isLoading = false;
          this.notFound = true;
        },
      });
    });
  }

  onPrevious() {
    if (this.chapterId === 1) return;
    this.router.navigate(['../', this.chapterId - 1], {
      relativeTo: this.route,
    });
  }

  onNext() {
    this.router.navigate(['../', this.chapterId + 1], {
      relativeTo: this.route,
    });
  }
}
