import { Component, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ModalComponent } from '../../shared/modal/modal.component';
import { CommonModule } from '@angular/common';
import { ChatService } from '../chat.service';
import { ChatComponent } from '../chat.component';
import { ModalService } from '../../shared/modal/modal.service';

@Component({
  selector: 'app-edit-chat',
  standalone: true,
  templateUrl: './edit-chat.component.html',
  styleUrl: './edit-chat.component.css',
  imports: [CommonModule, ReactiveFormsModule, ModalComponent],
})
export class EditChatComponent implements OnInit {
  chatForm!: FormGroup;
  editMode: boolean = false;
  chat: any;

  constructor(
    private chatService: ChatService,
    private chatComp: ChatComponent,
    private modalService: ModalService
  ) {}

  ngOnInit() {
    this.chatComp.chat.subscribe((chat) => {
      chat
        ? ((this.editMode = true), (this.chat = chat))
        : (this.editMode = false);

      this.chatForm = new FormGroup({
        Type: new FormControl(chat ? chat.type : 'public', [
          Validators.required,
        ]),
        Name: new FormControl(chat ? chat.name : '', [Validators.required]),
        Description: new FormControl(chat ? chat.description : '', [
          Validators.required,
        ]),
      });
    });
  }

  onSubmit() {
    this.editMode
      ? (this.chatService.hubConnection.invoke('Update', this.chat.id, {
          name: this.chatForm.value.Name,
          description: this.chatForm.value.Description,
          type: this.chatForm.value.Type,
        }),
        this.chatService.hubConnection.on('Update', (data) => {
          this.chatComp.chats = this.chatComp.chats.map((chat) =>
            chat.id === data.id ? data : chat
          );
        }))
      : this.chatService.hubConnection.invoke('Create', this.chatForm.value),
      this.chatService.hubConnection.on(
        'Create',
        (data) =>
          this.chatComp.chats.length < 15 && this.chatComp.chats.push(data)
      );

    this.modalService.closeModal('chatFormModal');
  }

  onDelete() {
    this.chatService.hubConnection.invoke('Delete', this.chat.id);
    this.chatService.hubConnection.on('Delete', () => {
      this.chatComp.chats = this.chatComp.chats.filter(
        (chat) => chat.id !== this.chat.id
      );
    });

    this.modalService.closeModal('chatFormModal');
  }
}
