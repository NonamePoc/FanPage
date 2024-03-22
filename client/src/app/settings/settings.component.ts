import { ModalService } from './../shared/modal/modal.service';
import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';

import { EmailChangeModalComponent } from './email-change-modal/email-change-modal.component';
import { PasswordChangeModalComponent } from './password-change-modal/password-change-modal.component';
import { UsernameChangeModalComponent } from './username-change-modal/username-change-modal.component';
import { ThemeChangeComponent } from './theme-change/theme-change.component';

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
  ],
})
export class SettingsComponent {
  constructor(private modalService: ModalService) {}

  openModal(modalId: string) {
    this.modalService.openModal(modalId);
  }
}
