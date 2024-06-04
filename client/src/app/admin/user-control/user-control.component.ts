import { Component, EventEmitter, OnDestroy, OnInit } from '@angular/core';
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
export class UserControlComponent implements OnInit, OnDestroy {
  users: any[] = [];
  selectedUser: any;
  searchInput: string = '';
  selectedUserChanged = new EventEmitter<any>();

  constructor(
    private themeService: ThemeService,
    private adminService: AdminService,
    private modalService: ModalService
  ) {}

  ngOnInit(): void {
    this.themeService.setDarkMode(true);

    this.searchSubject.pipe(debounceTime(500)).subscribe((value) => {
      this.performSearch(value);
    });

    this.adminService.getUsers().subscribe((users) => {
      this.users = users;
    });
  }

  ngOnDestroy() {
    this.searchSubject.complete();
  }

  onSearch() {
    this.searchSubject.next(this.searchInput);
  }

  onSelectRole(event: any, user: any) {
    this.adminService.changeRole(user.id, event.target.value).subscribe(() => {
      user.role = event.target.value;
    });
  }

  onBan(user: any, isBanned: boolean) {
    if (isBanned) {
      this.adminService.unbanUser(user.id).subscribe(() => {
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
      this.users = this.users.filter((u) => u.id !== userId);
    });
  }

  private performSearch(searchValue: string) {
    !searchValue
      ? (this.users = [])
      : this.adminService.searchUsers(searchValue).subscribe((users) => {
          this.users = users;
        });
  }

  private searchSubject = new Subject<string>();
}
