import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SideNavbarService {
  private isOpenSubject = new BehaviorSubject<boolean>(false);
  isOpen = this.isOpenSubject.asObservable();

  constructor() {}

  toggle = () => this.isOpenSubject.next(!this.isOpenSubject.value);
}
