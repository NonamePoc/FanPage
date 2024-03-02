import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ThemeService {
  private isDarkModeSubject = new BehaviorSubject<boolean>(false);
  isDarkMode = this.isDarkModeSubject.asObservable();

  getTheme() {
    if (typeof localStorage !== 'undefined') {
      const isDarkMode = JSON.parse(
        localStorage.getItem('isDarkMode') || 'false'
      );
      this.isDarkModeSubject.next(isDarkMode);
      return isDarkMode;
    }
  }

  setTheme(isDarkMode: boolean) {
    localStorage.setItem('isDarkMode', JSON.stringify(isDarkMode));
    this.isDarkModeSubject.next(isDarkMode);
  }
}
