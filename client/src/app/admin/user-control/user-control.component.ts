import { Component, EventEmitter } from '@angular/core';
import { ThemeService } from '../../shared/theme.service';
import { AdminService } from '../admin.service';
import { CommonModule } from '@angular/common';
import { ModalService } from '../../shared/modal/modal.service';
import { ModalComponent } from '../../shared/modal/modal.component';
import { BanModalComponent } from './ban-modal/ban-modal.component';

@Component({
  selector: 'app-user-control',
  standalone: true,
  templateUrl: './user-control.component.html',
  styleUrl: './user-control.component.css',
  imports: [CommonModule, BanModalComponent],
})
export class UserControlComponent {
  users: any[] = [{ username: 'Apple', bannedBy: 'None', role: 'User' }];
  selectedUser: any;
  selectedUserChanged = new EventEmitter<any>();

  constructor(
    private themeService: ThemeService,
    private adminService: AdminService,
    private modalService: ModalService
  ) {}

  ngOnInit(): void {
    this.themeService.setTheme(true);
  }

  onSearch(event: any) {
    const search = event.target.value;
    console.log('Search', search);
  }

  onSelectRole(event: any, user: any) {
    this.adminService
      .changeRole(user.id, event.target.value)
      .subscribe((res) => {
        user.role = event.target.value;
      });
  }

  onBan(user: any, isBanned: boolean) {
    if (isBanned) {
      this.adminService.unbanUser(user.id).subscribe((res) => {
        user.bannedBy = 'None';
      });
      return;
    }
    this.selectedUser = user;
    this.selectedUserChanged.emit(user);
    this.modalService.openModal('banModal');
  }

  onDelete(userId: string) {
    this.adminService.deleteUser(userId).subscribe((res) => {
      this.users = this.users.filter((u) => u.id !== userId);
    });
  }
}
