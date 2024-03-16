import { CUSTOM_ELEMENTS_SCHEMA, Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../auth/auth.service';

@Component({
  selector: 'app-ads',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './ads.component.html',
  styleUrl: './ads.component.css',
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AdsComponent implements OnInit {
  isAdmin: boolean = false;

  constructor(private authService: AuthService) {}

  ngOnInit() {
    this.authService.user.subscribe((user) => {
      this.isAdmin = user?.role === 'Admin';
      console.log('isAdmin', this.isAdmin);
    });
  }
}
