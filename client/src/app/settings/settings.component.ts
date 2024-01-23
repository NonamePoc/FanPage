import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

@Component({
  selector: 'app-settings',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './settings.component.html',
  styleUrl: './settings.component.css',
})
export class SettingsComponent implements OnInit {
  personForm!: FormGroup;
  pristine = true;

  ngOnInit(): void {
    this.personForm = new FormGroup({
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
      newPassword: new FormControl(null, [
        Validators.required,
        Validators.minLength(8),
      ]),
    });

    this.personForm.valueChanges.subscribe(() => {
      this.pristine = false;
    });

    this.personForm.setValue({
      username: 'John Doe',
      email: 'johndoe@mail.com',
      password: '',
      newPassword: '',
    });
  }

  onSubmit(): void {
    console.log(this.personForm);
  }

  onReset(): void {
    this.personForm.reset();
  }
}
