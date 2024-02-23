import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ModalComponent } from '../../shared/modal/modal.component';
import { AuthService } from '../auth.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-restore-password-modal',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, ModalComponent],
  templateUrl: './restore-password-modal.component.html',
  styleUrl: './restore-password-modal.component.css',
})
export class RestorePasswordModalComponent implements OnInit {
  restorePassForm!: FormGroup;

  constructor(
    private toastr: ToastrService,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.restorePassForm = new FormGroup({
      email: new FormControl(null, [Validators.required, Validators.email]),
    });
  }

  onSubmit(): void {
    this.authService
      .restorePassword(this.restorePassForm.value.email)
      .subscribe(() => {
        this.toastr.success(
          'New password has been sent to your email address.',
          'Success'
        );
      });
  }
}
