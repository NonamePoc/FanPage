import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'app-companions',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './companions.component.html',
  styleUrl: './companions.component.css',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: CompanionsComponent,
      multi: true,
    },
  ],
})
export class CompanionsComponent implements ControlValueAccessor {
  companions: string[] = ['User1', 'User2'];
  inputValue: string = '';
  showCompanions: boolean = false;
  selected: string[] = [];

  constructor() {}

  writeValue(value: any): void {
    this.selected = value;
  }

  registerOnChange(fn: any): void {
    this.onChanged = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  onInput(event: any): void {
    this.inputValue = event.target.value;
    this.inputValue.length > 2
      ? (this.showCompanions = true)
      : (this.showCompanions = false);
  }

  onAddCompanion(companion?: string): void {
    if (!companion) companion = this.inputValue;
    if (companion && !this.selected.includes(companion)) {
      this.selected.push(companion);
      this.onChanged(this.selected);
      this.inputValue = '';
      this.onTouched();
    }
  }

  onRemoveCompanion(index: number): void {
    this.onTouched();
    this.selected.splice(index, 1);
    this.onChanged(this.selected);
  }

  private onChanged!: Function;
  private onTouched!: Function;
}
