import { Component } from '@angular/core';
import { ThemeService } from '../../shared/theme.service';

@Component({
  selector: 'app-theme-change',
  standalone: true,
  imports: [],
  templateUrl: './theme-change.component.html',
  styleUrl: './theme-change.component.css',
})
export class ThemeChangeComponent {
  constructor(private themeService: ThemeService) {}

  onThemeChange(theme: boolean) {
    this.themeService.setDarkMode(theme);
  }
}
