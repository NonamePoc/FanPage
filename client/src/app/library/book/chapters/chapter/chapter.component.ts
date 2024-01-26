import { RouterLink } from '@angular/router';
import { Component } from '@angular/core';
import { CommentsComponent } from './comments/comments.component';

@Component({
  selector: 'app-chapter',
  standalone: true,
  templateUrl: './chapter.component.html',
  styleUrl: './chapter.component.css',
  imports: [RouterLink, CommentsComponent],
})
export class ChapterComponent {}
