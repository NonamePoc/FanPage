import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ModalComponent } from '../../shared/modal/modal.component';
import { UserService } from '../../shared/user.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-username-change-modal',
  standalone: true,
  templateUrl: './username-change-modal.component.html',
  styleUrl: './username-change-modal.component.css',
  imports: [CommonModule, ReactiveFormsModule, ModalComponent],
})
export class UsernameChangeModalComponent implements OnInit {
  usernameForm!: FormGroup;

  constructor(
    private userService: UserService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.usernameForm = new FormGroup({
      username: new FormControl(null, [
        Validators.required,
        Validators.minLength(3),
      ]),
    });
  }

  onSubmit() {
    this.userService
      .changeUsername(this.usernameForm.value.username)
      .subscribe(() => {
        this.toastr.success('Username changed successfully');
      });
  }
}
