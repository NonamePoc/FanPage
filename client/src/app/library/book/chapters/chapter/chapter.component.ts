import { CommonModule } from '@angular/common';
import { ActivatedRoute, Params, Router, RouterLink } from '@angular/router';
import {
  Component,
  ElementRef,
  HostListener,
  OnInit,
  ViewChild,
} from '@angular/core';
import { CommentsComponent } from './comments/comments.component';
import { ChapterService } from '../chapter.service';
import { ImageNormalizePipe } from '../../../../shared/image-normalize.pipe';
import { ReadingProgressService } from './reading-progress.service';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../../../../auth/auth.service';

@Component({
  selector: 'app-chapter',
  standalone: true,
  templateUrl: './chapter.component.html',
  styleUrl: './chapter.component.css',
  imports: [CommonModule, RouterLink, CommentsComponent, ImageNormalizePipe],
})
export class ChapterComponent implements OnInit {
  @ViewChild('chapterContent') chapterContent!: ElementRef;
  @HostListener('window:scroll')
  onScroll() {
    const scrollPosition = window.scrollY;

    this.readingProgressService.setScrollPosition(
      this.bookId,
      this.chapterId,
      scrollPosition
    );
  }

  currentUsername!: string;
  bookId!: number;
  chapterId!: number;
  chapter: any;
  isLoading = true;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService,
    private authService: AuthService,
    private chapterService: ChapterService,
    private readingProgressService: ReadingProgressService
  ) {}

  ngOnInit(): void {
    this.currentUsername = this.authService.user.value?.username!;

    this.route.params.subscribe((params: Params) => {
      this.bookId = +params['id'];
      this.chapterId = +params['chapterId'];
      this.isLoading = true;

      this.chapterService.getChapter(this.chapterId, this.bookId).subscribe({
        next: (data: any) => {
          this.chapter = data;
          this.isLoading = false;
        },
        error: () => {
          this.isLoading = false;
        },
      });

      this.initProgress();
    });
  }

  async onPrevious() {
    if (await this.checkIfChapterExists(this.chapterId - 1))
      this.router.navigate(['../', this.chapterId - 1], {
        relativeTo: this.route,
      });
  }

  async onNext() {
    if (await this.checkIfChapterExists(this.chapterId + 1))
      this.router.navigate(['../', this.chapterId + 1], {
        relativeTo: this.route,
      });
    else {
      this.toastr.info('You have reached the end of the book.');
    }
  }

  private checkIfChapterExists(chapterId: number): Promise<boolean> {
    return new Promise((resolve) => {
      this.chapterService.getChapter(chapterId, this.bookId).subscribe({
        next: () => resolve(true),
        error: () => {
          resolve(false);
        },
      });
    });
  }

  private initProgress() {
    const bookProgress = this.readingProgressService.getBookProgress(
      this.bookId
    );

    (!bookProgress || this.chapterId > bookProgress.chapterId) &&
      this.readingProgressService.setReadingProgress(
        this.bookId,
        this.chapterId
      );

    this.chapterId === bookProgress?.chapterId &&
      setTimeout(() => window.scrollTo(0, bookProgress.scrollPosition ?? 0), 0);
  }
}
