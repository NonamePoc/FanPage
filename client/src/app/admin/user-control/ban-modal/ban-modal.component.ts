import { Component, EventEmitter, Input, OnInit } from '@angular/core';
import { ModalComponent } from '../../../shared/modal/modal.component';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { AdminService } from '../../admin.service';
import { AuthService } from '../../../auth/auth.service';
import { ToastrService } from 'ngx-toastr';
import { ModalService } from '../../../shared/modal/modal.service';

@Component({
  selector: 'app-ban-modal',
  standalone: true,
  templateUrl: './ban-modal.component.html',
  styleUrl: './ban-modal.component.css',
  imports: [ReactiveFormsModule, ModalComponent],
})
export class BanModalComponent implements OnInit {
  @Input() userChanged = new EventEmitter<string>();
  user: any;
  banForm!: FormGroup;

  constructor(
    private auth: AuthService,
    private adminService: AdminService,
    private toastr: ToastrService,
    private modal: ModalService
  ) {}

  ngOnInit() {
    this.userChanged.subscribe((user) => {
      this.user = user;
    });

    this.banForm = new FormGroup({
      days: new FormControl(1, Validators.required),
    });
  }

  onSubmit() {
    this.adminService
      .banUser(this.user.id, this.banForm.value.days)
      .subscribe(() => {
        this.user.whoBan = this.auth.user.value?.username;
        this.toastr.success('User has been banned');
        this.modal.closeModal('banModal');
      });
  }
}
