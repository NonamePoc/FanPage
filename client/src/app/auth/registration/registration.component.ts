import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  ValidatorFn,
  Validators,
} from '@angular/forms';
import { ModalComponent } from '../../shared/modal/modal.component';

@Component({
  selector: 'app-registration',
  standalone: true,
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css',
  imports: [CommonModule, ReactiveFormsModule, ModalComponent],
})
export class RegistrationComponent implements OnInit {
  signupForm!: FormGroup;

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
    console.log(this.signupForm);
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
