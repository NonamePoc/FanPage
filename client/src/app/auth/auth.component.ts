import { CommonModule } from '@angular/common';
import { Component, OnDestroy } from '@angular/core';
import { ModalComponent } from '../shared/modal/modal.component';
import { ModalService } from '../shared/modal/modal.service';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { Subscription } from 'rxjs';
import { GoogleComponent } from './google/google.component';
import { RestorePasswordModalComponent } from './restore-password-modal/restore-password-modal.component';

@Component({
  selector: 'app-auth',
  standalone: true,
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.css',
  imports: [
    CommonModule,
    ModalComponent,
    RegistrationComponent,
    LoginComponent,
    GoogleComponent,
    RestorePasswordModalComponent,
  ],
})
export class AuthComponent implements OnDestroy {
  isLoginMode = true;
  isLoading = false;

  private closeSub?: Subscription;

  constructor(private modalService: ModalService) {}

  onLoadingChange(isLoading: boolean): void {
    this.isLoading = isLoading;
  }

  onSwitchMode(): void {
    this.modalService.closeModal('authModal');
    setTimeout(() => {
      this.isLoginMode = !this.isLoginMode;
      this.modalService.openModal('authModal');
    }, 300);
  }

  ngOnDestroy(): void {
    this.closeSub && this.closeSub.unsubscribe();
  }
}
