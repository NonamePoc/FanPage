import { Component, Input, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CompanionsComponent } from './companions/companions.component';

@Component({
  selector: 'app-edit-chat',
  standalone: true,
  templateUrl: './edit-chat.component.html',
  styleUrl: './edit-chat.component.css',
  imports: [ReactiveFormsModule, CompanionsComponent],
})
export class EditChatComponent implements OnInit {
  @Input() chat: any;
  chatForm!: FormGroup;

  constructor() {}

  ngOnInit() {
    this.chat ? console.log(this.chat) : console.log('Create new chat');

    this.chatForm = new FormGroup({
      name: new FormControl(null, [Validators.required]),
      users: new FormControl(null, [Validators.required]),
    });
  }

  onSubmit() {
    console.log(this.chatForm);
  }
}
