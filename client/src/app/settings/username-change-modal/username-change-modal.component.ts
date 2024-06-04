import { CUSTOM_ELEMENTS_SCHEMA, Component, OnInit } from '@angular/core';
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
import { ReCaptchaV3Service, RecaptchaV3Module } from 'ng-recaptcha';
import { environment } from '../../../environments/environment.development';
import { ModalService } from '../../shared/modal/modal.service';
import { AuthService } from '../../auth/auth.service';

@Component({
  selector: 'app-username-change-modal',
  standalone: true,
  templateUrl: './username-change-modal.component.html',
  styleUrl: './username-change-modal.component.css',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ModalComponent,
    RecaptchaV3Module,
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class UsernameChangeModalComponent implements OnInit {
  usernameForm!: FormGroup;
  SITE_KEY = environment.recaptcha.siteKey;

  constructor(
    private toastr: ToastrService,
    private recaptchaV3Service: ReCaptchaV3Service,
    private modalService: ModalService,
    private userService: UserService,
    private authService: AuthService
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
    this.recaptchaV3Service.execute('changeUsername').subscribe({
      next: () => {
        this.changeUsername();
      },
      error: () => {
        this.toastr.error('Recaptcha error');
      },
    });
  }

  private changeUsername() {
    this.userService
      .changeUsername(this.usernameForm.value.username)
      .subscribe(() => {
        this.authService.user.value!.username =
          this.usernameForm.value.username;
        this.authService.user.next(this.authService.user.value);
        this.toastr.success('Username changed successfully', 'Please login');
        this.modalService.closeModal('changeUsernameModal');
        this.authService.logout();
        this.modalService.openModal('authModal');
      });
    this.usernameForm.disable();
  }
}
