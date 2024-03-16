import { Component, Input, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CompanionsComponent } from './companions/companions.component';
import { ModalComponent } from '../../shared/modal/modal.component';
import { CommonModule } from '@angular/common';
import { ChatService } from '../chat.service';

@Component({
  selector: 'app-edit-chat',
  standalone: true,
  templateUrl: './edit-chat.component.html',
  styleUrl: './edit-chat.component.css',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CompanionsComponent,
    ModalComponent,
  ],
})
export class EditChatComponent implements OnInit {
  @Input() chat: any;
  chatForm!: FormGroup;

  constructor(private chatService: ChatService) {}

  ngOnInit() {
    this.chat ? console.log(this.chat) : console.log('New form: Creating chat');

    this.chatForm = new FormGroup({
      type: new FormControl('public', [Validators.required]),
      name: new FormControl(null, [Validators.required]),
      description: new FormControl(null, [Validators.required]),
      /* usernames: new FormControl([], [Validators.required]), */
    });
  }

  onSubmit() {
    console.log(this.chatForm);
    this.chatService.createChat(this.chatForm.value);
  }
}
