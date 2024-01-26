import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { ModalService } from '../shared/modal/modal.service';
import { ModalComponent } from '../shared/modal/modal.component';
import { EditChatComponent } from './edit-chat/edit-chat.component';

@Component({
  selector: 'app-chat',
  standalone: true,
  templateUrl: './chat.component.html',
  styleUrl: './chat.component.css',
  imports: [RouterOutlet, RouterLink, ModalComponent, EditChatComponent],
})
export class ChatComponent {
  constructor(private modalService: ModalService) {}

  onCreateChat() {
    this.modalService.openModal('chatFormModal');
  }
}
