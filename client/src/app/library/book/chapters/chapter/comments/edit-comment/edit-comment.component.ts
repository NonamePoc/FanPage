import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { CommentService } from '../comment.service';
import { CommentsComponent } from '../comments.component';
import { ModalComponent } from '../../../../../../shared/modal/modal.component';
import { ModalService } from '../../../../../../shared/modal/modal.service';

@Component({
  selector: 'app-edit-comment',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, ModalComponent],
  templateUrl: './edit-comment.component.html',
  styleUrl: './edit-comment.component.css',
})
export class EditCommentComponent implements OnInit {
  commentForm!: FormGroup;
  editMode: boolean = false;
  comment: any;

  constructor(
    private route: ActivatedRoute,
    private commentService: CommentService,
    private commentsComp: CommentsComponent,
    private modalService: ModalService
  ) {}

  ngOnInit(): void {
    this.commentsComp.comment.subscribe((comment) => {
      comment
        ? ((this.editMode = true), (this.comment = comment))
        : (this.editMode = false);

      this.commentForm = new FormGroup({
        Content: new FormControl(comment ? comment.content : '', [
          Validators.required,
        ]),
      });
    });
  }

  onSubmit() {
    this.editMode
      ? (this.commentService.hubConnection.invoke('Update', {
          Content: this.commentForm.value.Content,
          FanficId: this.route.snapshot.params['id'],
        }),
        this.commentService.hubConnection.on('Update', (data) => {
          this.commentsComp.comments = this.commentsComp.comments.map(
            (comment) => (comment.id === data.id ? data : comment)
          );
        }))
      : (this.commentService.hubConnection.invoke('Create', {
          Content: this.commentForm.value.Content,
          FanficId: this.route.snapshot.params['id'],
        }),
        this.commentService.hubConnection.on('Create', (data) => {
          this.commentsComp.comments.push(data);
        }));

    this.modalService.closeModal('editCommentModal');
  }

  onDelete() {
    this.commentService.hubConnection.invoke('Delete', this.comment.id);
    this.commentService.hubConnection.on('Delete', () => {
      this.commentsComp.comments = this.commentsComp.comments.filter(
        (comment) => comment.id !== this.comment.id
      );
    });

    this.modalService.closeModal('editCommentModal');
  }
}
