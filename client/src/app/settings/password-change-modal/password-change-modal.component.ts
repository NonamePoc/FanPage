import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ModalComponent } from '../../shared/modal/modal.component';
import { UserService } from '../../shared/user.service';
import { ModalService } from '../../shared/modal/modal.service';

@Component({
  selector: 'app-password-change-modal',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, ModalComponent],
  templateUrl: './password-change-modal.component.html',
  styleUrl: './password-change-modal.component.css',
})
export class PasswordChangeModalComponent {
  passwordForm!: FormGroup;

  constructor(
    private toastr: ToastrService,
    private userService: UserService,
    private modalService: ModalService
  ) {}

  ngOnInit(): void {
    this.passwordForm = new FormGroup({
      password: new FormControl(null, [Validators.required]),
      newPassword: new FormControl(null, [
        Validators.required,
        Validators.minLength(8),
      ]),
      newConfirmPassword: new FormControl(null, [
        Validators.required,
        Validators.minLength(8),
      ]),
    });
  }

  onSubmit() {
    this.userService.changePassword(this.passwordForm.value).subscribe(() => {
      this.toastr.success('Password changed successfully');
      this.modalService.closeModal('changePasswordModal');
    });
  }
}
