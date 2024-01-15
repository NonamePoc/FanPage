import { ModalService } from './modal.service';
import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-modal',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './modal.component.html',
  styleUrl: './modal.component.css',
})
export class ModalComponent {
  @Input() modalId!: string;
  @Input() title!: string;
  @Input() description!: string;

  constructor(private modalService: ModalService) {}

  get isVisible() {
    return this.modalService.isVisible(this.modalId);
  }

  close() {
    this.modalService.closeModal(this.modalId);
  }
}
