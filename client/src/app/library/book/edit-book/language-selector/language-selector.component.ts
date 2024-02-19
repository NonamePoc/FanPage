import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { LanguageService } from './language.service';
import { DropdownDirective } from '../../../../shared/dropdown.directive';
import { Language } from './language.model';

@Component({
  selector: 'app-language-selector',
  standalone: true,
  imports: [CommonModule, DropdownDirective],
  templateUrl: './language-selector.component.html',
  styleUrl: './language-selector.component.css',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: LanguageSelectorComponent,
      multi: true,
    },
  ],
})
export class LanguageSelectorComponent implements ControlValueAccessor {
  languages: Language[] = this.languageService.getLanguages();
  selected = this.languages[0];
  selectedCode = this.selected.code;

  constructor(private languageService: LanguageService) {}

  writeValue(value: any) {
    this.selectedCode = value;
    this.selected = this.languages.find((l) => l.code === value)!;
  }

  registerOnChange(fn: any) {
    this.onChanged = fn;
  }

  registerOnTouched(fn: any) {
    this.onTouched = fn;
  }

  onSelectLanguage(language: Language) {
    this.onTouched();
    this.selected = language;
    this.selectedCode = this.selected.code;
    this.onChanged(this.selectedCode);
  }

  private onChanged!: Function;
  private onTouched!: Function;
}
