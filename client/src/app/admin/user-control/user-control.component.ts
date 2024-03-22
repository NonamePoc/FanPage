import { Component, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Subject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';

import { ThemeService } from '../../shared/theme.service';
import { AdminService } from '../admin.service';
import { ModalService } from '../../shared/modal/modal.service';
import { BanModalComponent } from './ban-modal/ban-modal.component';

@Component({
  selector: 'app-user-control',
  standalone: true,
  templateUrl: './user-control.component.html',
  styleUrl: './user-control.component.css',
  imports: [CommonModule, FormsModule, BanModalComponent],
})
export class UserControlComponent {
  user: any;
  selectedUser: any;
  searchInput: string = '';
  selectedUserChanged = new EventEmitter<any>();

  constructor(
    private themeService: ThemeService,
    private adminService: AdminService,
    private modalService: ModalService
  ) {}

  ngOnInit(): void {
    this.themeService.setTheme(true);

    this.searchSubject.pipe(debounceTime(500)).subscribe((value) => {
      this.performSearch(value);
    });
  }

  onSearch() {
    this.searchSubject.next(this.searchInput);
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
        user.whoBan = 'None';
      });
      return;
    }
    this.selectedUser = user;
    this.selectedUserChanged.emit(user);
    this.modalService.openModal('banModal');
  }

  onDelete(userId: string) {
    this.adminService.deleteUser(userId).subscribe(() => {
      this.user = null;
    });
  }

  private performSearch(searchValue: string) {
    !searchValue
      ? (this.user = [])
      : this.adminService.getUser(searchValue).subscribe((user) => {
          this.user = user;
        });
  }

  private searchSubject = new Subject<string>();
}
