import { CommonModule } from '@angular/common';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import {
  AbstractControl,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  ValidatorFn,
  Validators,
} from '@angular/forms';
import { ModalComponent } from '../../shared/modal/modal.component';
import { AuthService } from '../auth.service';
import { Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-registration',
  standalone: true,
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css',
  imports: [CommonModule, ReactiveFormsModule, ModalComponent],
})
export class RegistrationComponent implements OnInit {
  signupForm!: FormGroup;
  @Output() loadingChanged = new EventEmitter<boolean>();

  constructor(
    private authService: AuthService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.signupForm = new FormGroup(
      {
        username: new FormControl(null, [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(12),
        ]),
        email: new FormControl(null, [Validators.required, Validators.email]),
        password: new FormControl(null, [
          Validators.required,
          Validators.minLength(8),
        ]),
        confirmPassword: new FormControl(null, [
          Validators.required,
          Validators.minLength(8),
        ]),
      },
      { validators: this.passwordMatchValidator }
    );
  }

  onSubmit(): void {
    if (this.signupForm.invalid) {
      return;
    }
    this.loadingChanged.emit(true);
    const { username, email, password, confirmPassword } =
      this.signupForm.value;

    let authObs: Observable<any> = this.authService.signup(
      email,
      username,
      password,
      confirmPassword
    );
    authObs.subscribe({
      next: () => {
        this.toastr.success('Please check you mail', 'Email sent', {
          timeOut: 3000,
          positionClass: 'toast-center-center',
        });
      },
      error: (errorMessage) => {
        this.toastr.error(errorMessage, 'Error', {
          timeOut: 3000,
        });
      },
      complete: () => {
        this.loadingChanged.emit(false);
      },
    });

    this.signupForm.reset();
  }

  passwordMatchValidator: ValidatorFn = (
    control: AbstractControl<any>
  ): { [key: string]: boolean } | null => {
    const password = control.get('password');
    const confirmPassword = control.get('confirmPassword');

    return password &&
      confirmPassword &&
      password.value === confirmPassword.value
      ? null
      : { passwordsDoNotMatch: true };
  };
}
