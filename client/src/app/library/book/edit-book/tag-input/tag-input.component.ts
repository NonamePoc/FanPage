import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { DropdownDirective } from '../../../../shared/dropdown.directive';

@Component({
  selector: 'app-tag-input',
  standalone: true,
  imports: [CommonModule, DropdownDirective],
  templateUrl: './tag-input.component.html',
  styleUrl: './tag-input.component.css',
})
export class TagInputComponent {
  tags = ['Zombi', 'School'];
  selectedTags = [''];

  onSelectTag(index: number, tag: string) {
    console.log(index, tag);
    this.selectedTags[index] = tag;
  }

  onAddTag() {
    this.selectedTags.push('');
  }

  onRemoveTag(index: number) {
    this.selectedTags.splice(index, 1);
  }
}
