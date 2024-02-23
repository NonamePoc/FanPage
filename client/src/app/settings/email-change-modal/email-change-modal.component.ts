import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
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
  selector: 'app-email-change-modal',
  standalone: true,
  templateUrl: './email-change-modal.component.html',
  styleUrl: './email-change-modal.component.css',
  imports: [CommonModule, ReactiveFormsModule, ModalComponent],
})
export class EmailChangeModalComponent implements OnInit {
  emailForm!: FormGroup;

  constructor(
    private userService: UserService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.emailForm = new FormGroup({
      email: new FormControl(null, [Validators.required, Validators.email]),
    });
  }

  onSubmit() {
    this.userService.changeEmail(this.emailForm.value.email).subscribe(() => {
      this.toastr.success('Sent email change request');
    });
  }
}
