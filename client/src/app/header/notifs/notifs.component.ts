import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { DropdownDirective } from '../../shared/dropdown.directive';

@Component({
  selector: 'app-notifs',
  standalone: true,
  imports: [CommonModule, DropdownDirective],
  templateUrl: './notifs.component.html',
  styleUrl: './notifs.component.css',
})
export class NotifsComponent {
  @Input() isAuthenticated: boolean = false;
  notifications = [];
}
