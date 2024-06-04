import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ModalComponent } from '../../shared/modal/modal.component';
import { UserService } from '../../shared/user.service';
import { AuthService } from '../../auth/auth.service';
import { ModalService } from '../../shared/modal/modal.service';

@Component({
  selector: 'app-email-change-modal',
  standalone: true,
  templateUrl: './email-change-modal.component.html',
  styleUrl: './email-change-modal.component.css',
  imports: [CommonModule, ReactiveFormsModule, ModalComponent],
})
export class EmailChangeModalComponent implements OnInit {
  emailForm!: FormGroup;

  constructor(
    private toastr: ToastrService,
    private authService: AuthService,
    private userService: UserService,
    private modalService: ModalService
  ) {}

  ngOnInit(): void {
    this.emailForm = new FormGroup({
      email: new FormControl(null, [Validators.required, Validators.email]),
    });
  }

  onSubmit() {
    this.userService.changeEmail(this.emailForm.value.email).subscribe(() => {
      this.toastr.success('Sent email change request');
      this.authService.user.value!.email = this.emailForm.value.email;
      this.authService.user.next(this.authService.user.value);
      this.modalService.closeModal('changeEmailModal');
    });
  }
}
