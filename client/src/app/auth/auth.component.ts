import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ModalComponent } from '../shared/modal/modal.component';
import { ModalService } from '../shared/modal/modal.service';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';

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
  ],
})
export class AuthComponent {
  isLoginMode = true;

  constructor(private modalService: ModalService) {}

  onSwitchMode(): void {
    this.modalService.closeModal('authModal');
    this.isLoginMode = !this.isLoginMode;
    setTimeout(() => {
      this.modalService.openModal('authModal');
    }, 50);
  }
}
