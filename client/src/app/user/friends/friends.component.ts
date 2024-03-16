import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ModalComponent } from '../../shared/modal/modal.component';
import { DropdownDirective } from '../../shared/dropdown.directive';
import { FriendsService } from './friends.service';
import { ImageNormalizePipe } from '../../shared/image-normalize.pipe';

@Component({
  selector: 'app-friends',
  standalone: true,
  templateUrl: './friends.component.html',
  styleUrl: './friends.component.css',
  imports: [
    CommonModule,
    RouterLink,
    DropdownDirective,
    ModalComponent,
    ImageNormalizePipe,
  ],
})
export class FriendsComponent implements OnInit {
  type!: string;
  people: any[] = [];

  constructor(
    private toastr: ToastrService,
    private friendService: FriendsService
  ) {}

  ngOnInit(): void {
    this.friendService.currentType.subscribe((type) => {
      this.type = type;
      this.loadFriendsByType(type);
    });
  }

  onRemove(person: any) {
    this.friendService.changeFriendTies(person.friendName);
    this.toastr.info('Friend removed', 'Success', {
      progressBar: true,
      progressAnimation: 'decreasing',
      positionClass: 'toast-bottom-right',
    });
  }

  private loadFriendsByType(type: string) {
    switch (type) {
      case 'mutuals':
        this.people = this.friendService.mutuals;
        break;
      case 'followers':
        this.people = this.friendService.followers;
        break;
      case 'following':
        this.people = this.friendService.following;
        break;
      default:
        console.error('Invalid type');
        break;
    }
  }
}
