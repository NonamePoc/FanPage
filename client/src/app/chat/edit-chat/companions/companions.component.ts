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
  selected = '';

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

  private onChanged!: Function;
  private onTouched!: Function;
}
