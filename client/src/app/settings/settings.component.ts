import { ModalService } from './../shared/modal/modal.service';
import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

import { EmailChangeModalComponent } from './email-change-modal/email-change-modal.component';
import { PasswordChangeModalComponent } from './password-change-modal/password-change-modal.component';
import { UsernameChangeModalComponent } from './username-change-modal/username-change-modal.component';
import { ThemeChangeComponent } from './theme-change/theme-change.component';
import { AuthService } from '../auth/auth.service';
import { ImageNormalizePipe } from '../shared/image-normalize.pipe';
import { UserService } from '../shared/user.service';
import { ImageValidateService } from '../shared/image-validate.service';

@Component({
  selector: 'app-settings',
  standalone: true,
  templateUrl: './settings.component.html',
  styleUrl: './settings.component.css',
  imports: [
    CommonModule,
    EmailChangeModalComponent,
    PasswordChangeModalComponent,
    UsernameChangeModalComponent,
    ThemeChangeComponent,
    ImageNormalizePipe,
  ],
})
export class SettingsComponent implements OnInit {
  avatar?: string = '';

  constructor(
    private modalService: ModalService,
    private authService: AuthService,
    private userService: UserService,
    private imageValidateService: ImageValidateService,
    private toastr: ToastrService
  ) {}

  ngOnInit() {
    this.authService.user.subscribe((user) => {
      this.avatar = user?.avatar;
    });
  }

  openModal(modalId: string) {
    this.modalService.openModal(modalId);
  }

  onChangeAvatar(event: any) {
    if (event.target.files && event.target.files[0]) {
      const file = event.target.files[0];
      const error = this.imageValidateService.validateImage(file);

      error
        ? this.toastr.error(error)
        : this.userService.changeAvatar(file).subscribe((response) => {
            this.avatar = response.avatar;
            this.authService.user.value!.avatar = response.avatar;
            this.authService.user.next(this.authService.user.value);
          });
    }
  }
}
