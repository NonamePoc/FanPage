import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { DropdownDirective } from '../../../../shared/dropdown.directive';
import {
  ControlValueAccessor,
  FormControl,
  NG_VALUE_ACCESSOR,
  ReactiveFormsModule,
} from '@angular/forms';

@Component({
  selector: 'app-tag-input',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, DropdownDirective],
  templateUrl: './tag-input.component.html',
  styleUrl: './tag-input.component.css',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: TagInputComponent,
      multi: true,
    },
  ],
})
export class TagInputComponent implements ControlValueAccessor {
  tagInputControl = new FormControl();
  tags: string[] = ['Zombi', 'School'];
  selectedTags: string[] = [];
  filteredTags: string[] = [];

  writeValue(value: any) {
    if (value) {
      this.selectedTags = value;
    }
  }

  registerOnChange(fn: any) {
    this.propagateChange = fn;
  }

  registerOnTouched() {}

  onAddTag() {
    const tag = this.tagInputControl.value;
    if (tag && !this.selectedTags.includes(tag)) {
      this.selectedTags.push(tag);
      this.updateValue();
    }
    this.tagInputControl.reset();
  }

  onRemoveTag(index: number) {
    this.selectedTags.splice(index, 1);
    this.updateValue();
  }

  onSelectTag(tag: string) {
    if (!this.selectedTags.includes(tag)) {
      this.selectedTags.push(tag);
      this.updateValue();
    }
    this.tagInputControl.reset();
    this.filterTags();
  }

  updateValue() {
    this.propagateChange(this.selectedTags);
  }

  filterTags(): void {
    this.tagInputControl.value
      ? (this.filteredTags = this.tags.filter((tag) =>
          tag.toLowerCase().includes(this.tagInputControl.value.toLowerCase())
        ))
      : (this.filteredTags = []);
  }

  private propagateChange = (_: any) => {};
}
