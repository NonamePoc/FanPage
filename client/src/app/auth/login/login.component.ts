import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Observable } from 'rxjs';
import { finalize } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';
import { ModalComponent } from '../../shared/modal/modal.component';
import { AuthService } from '../auth.service';
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
  @Output() loadingChanged = new EventEmitter<boolean>();

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
    this.loadingChanged.emit(true);

    const { email, password } = this.signinForm.value;
    let authObs: Observable<any> = this.authService.login(email, password);

    authObs
      .pipe(
        finalize(() => {
          this.modalService.closeModal('authModal');
          window.location.reload();
        })
      )
      .subscribe({
        next: () => {
          this.toastr.success('You have been logged in', 'Welcome');
        },
        error: (errorMessage) => {
          this.toastr.error(errorMessage, 'Error');
        },
      });
    this.signinForm.reset();
  }

  openRestorePassModal(): void {
    this.modalService.openModal('restorePasswordModal');
  }
}
