import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HubConnectionState } from '@microsoft/signalr';
import { BehaviorSubject } from 'rxjs';
import { CommentService } from './comment.service';
import { ModalService } from '../../../../../shared/modal/modal.service';
import { AuthService } from '../../../../../auth/auth.service';

@Component({
  selector: 'app-comments',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './comments.component.html',
  styleUrl: './comments.component.css',
})
export class CommentsComponent implements OnInit {
  currentUsername!: string;
  comments: any[] = [];

  private currentCommentSubject = new BehaviorSubject<any>(null);
  comment = this.currentCommentSubject.asObservable();

  constructor(
    private route: ActivatedRoute,
    private authService: AuthService,
    private commentService: CommentService,
    private modalService: ModalService
  ) {}

  ngOnInit(): void {
    this.currentUsername = this.authService.user.value?.username!;

    this.route.params.subscribe((params: Params) => {
      this.commentService.connectionState.subscribe((state) => {
        if (state === HubConnectionState.Connected) {
          this.commentService.hubConnection.invoke(
            'CommentsByFanficId',
            +params['id']
          );
        }
      });

      this.commentService.hubConnection.on('CommentsByFanficId', (data) => {
        this.comments = data;
      });
    });
  }

  openEditModal(comment: any) {
    this.currentCommentSubject.next(comment);
    this.modalService.openModal('commentFormModal');
  }
}
