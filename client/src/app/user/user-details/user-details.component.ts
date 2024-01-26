import { Component, EventEmitter, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ModalService } from '../../shared/modal/modal.service';

@Component({
  selector: 'app-user-details',
  standalone: true,
  imports: [],
  templateUrl: './user-details.component.html',
  styleUrl: './user-details.component.css',
})
export class UserDetailsComponent {
  @Output() modalType = new EventEmitter<string>();
  isFollowing = false;

  constructor(
    private modalService: ModalService,
    private toastr: ToastrService
  ) {}

  onFollow() {
    this.isFollowing
      ? this.toastr.info('You are following `user` now!', 'Followed', {
          progressBar: true,
          progressAnimation: 'decreasing',
          positionClass: 'toast-bottom-right',
        })
      : this.toastr.warning(
          'You are no longer following `user`.',
          'Unfollowed',
          {
            progressBar: true,
            progressAnimation: 'decreasing',
            positionClass: 'toast-bottom-right',
          }
        );
    this.isFollowing = !this.isFollowing;
  }

  showFriendsModal(type: string) {
    this.modalType.emit(type);
    this.modalService.openModal('friendsModal');
  }
}
