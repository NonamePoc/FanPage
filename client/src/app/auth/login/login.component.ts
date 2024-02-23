import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ModalComponent } from '../../shared/modal/modal.component';
import { AuthService } from '../auth.service';
import { Observable } from 'rxjs';
import { ModalService } from '../../shared/modal/modal.service';

@Component({
  selector: 'app-login',
  standalone: true,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
  imports: [CommonModule, ReactiveFormsModule, ModalComponent],
})
export class LoginComponent implements OnInit {
  signinForm!: FormGroup;

  constructor(
    private authService: AuthService,
    private modalService: ModalService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.signinForm = new FormGroup({
      email: new FormControl(null, [Validators.required, Validators.email]),
      password: new FormControl(null, [
        Validators.required,
        Validators.minLength(8),
      ]),
    });
  }

  onSubmit(): void {
    if (this.signinForm.invalid) {
      return;
    }
    const { email, password } = this.signinForm.value;

    let authObs: Observable<any> = this.authService.login(email, password);

    authObs.subscribe({
      next: () => {},
      error: (errorMessage) => {
        console.log(errorMessage);
        this.toastr.error(errorMessage, 'Error', {
          timeOut: 3000,
        });
      },
    });

    this.toastr.success('You have been logged in', 'Welcome');
    this.signinForm.reset();
    this.modalService.closeModal('authModal');
  }

  openRestorePassModal(): void {
    this.modalService.openModal('restorePasswordModal');
  }
}
