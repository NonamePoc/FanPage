import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ModalComponent } from '../../shared/modal/modal.component';
import { DropdownDirective } from '../../shared/dropdown.directive';

@Component({
  selector: 'app-friends',
  standalone: true,
  templateUrl: './friends.component.html',
  styleUrl: './friends.component.css',
  imports: [CommonModule, DropdownDirective, ModalComponent],
})
export class FriendsComponent {
  @Input() type!: string;

  constructor(private router: Router, private toastr: ToastrService) {}

  onRemove() {
    this.toastr.info('Friend removed', 'Success', {
      progressBar: true,
      progressAnimation: 'decreasing',
      positionClass: 'toast-bottom-right',
    });
  }

  onToProfile() {
    this.router.navigate(['/user/1']);
  }
}
