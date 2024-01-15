import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { LanguageService } from './language.service';
import { DropdownDirective } from '../../../../shared/dropdown.directive';
import { Language } from './language';

@Component({
  selector: 'app-language-selector',
  standalone: true,
  imports: [CommonModule, DropdownDirective],
  templateUrl: './language-selector.component.html',
  styleUrl: './language-selector.component.css',
})
export class LanguageSelectorComponent {
  languages: Language[] = this.languageService.getLanguages();
  selectedLanguage = this.languages[0];

  constructor(private languageService: LanguageService) {}

  onSelectLanguage(language: Language) {
    this.selectedLanguage = language;
  }
}
