import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ModalService {
  private isVisibleSubjects: { [key: string]: BehaviorSubject<boolean> } = {};

  isVisible(modalId: string) {
    if (!this.isVisibleSubjects[modalId]) {
      this.isVisibleSubjects[modalId] = new BehaviorSubject<boolean>(false);
    }
    return this.isVisibleSubjects[modalId].asObservable();
  }

  openModal(modalId: string) {
    if (!this.isVisibleSubjects[modalId]) {
      this.isVisibleSubjects[modalId] = new BehaviorSubject<boolean>(true);
    } else {
      this.isVisibleSubjects[modalId].next(true);
    }
  }

  closeModal(modalId: string) {
    if (this.isVisibleSubjects[modalId]) {
      this.isVisibleSubjects[modalId].next(false);
    }
  }
}
