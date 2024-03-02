import { Component, EventEmitter, Input, OnInit } from '@angular/core';
import { ModalComponent } from '../../../shared/modal/modal.component';

@Component({
  selector: 'app-ban-modal',
  standalone: true,
  templateUrl: './ban-modal.component.html',
  styleUrl: './ban-modal.component.css',
  imports: [ModalComponent],
})
export class BanModalComponent implements OnInit {
  @Input() userChanged = new EventEmitter<string>();
  user: any;

  ngOnInit() {
    this.userChanged.subscribe((user) => {
      this.user = user;
      console.log('User changed', user);
    });
  }
}
