import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ThemeService {
  private _isDarkMode = new BehaviorSubject<boolean>(this.getInitialTheme());

  get isDarkMode() {
    return this._isDarkMode.asObservable();
  }

  private getInitialTheme(): boolean {
    if (typeof localStorage !== 'undefined') {
      const storedTheme = localStorage.getItem('theme');
      return storedTheme ? JSON.parse(storedTheme) : false;
    }
    return false;
  }

  setDarkMode(isDarkMode: boolean) {
    localStorage.setItem('theme', JSON.stringify(isDarkMode));
    this._isDarkMode.next(isDarkMode);
  }
}
