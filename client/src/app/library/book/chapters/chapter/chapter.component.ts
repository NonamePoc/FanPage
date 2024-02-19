import { CommonModule } from '@angular/common';
import { ActivatedRoute, Params, RouterLink } from '@angular/router';
import { Component, OnInit } from '@angular/core';
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
  bookId!: number;
  chapterId!: number;
  chapter: any;
  isLoading = true;

  constructor(
    private route: ActivatedRoute,
    private chapterService: ChapterService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.bookId = +params['id'];
      this.chapterId = +params['chapterId'];
      this.chapterService.getChapter(this.chapterId).subscribe((data: any) => {
        this.chapter = data;
        this.isLoading = false;
      });
    });
  }
}
