import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, RouterLink } from '@angular/router';
import { LanguageSelectorComponent } from './language-selector/language-selector.component';
import { CategorySelectorComponent } from './category-selector/category-selector.component';
import { TagInputComponent } from './tag-input/tag-input.component';

@Component({
  selector: 'app-edit-book',
  standalone: true,
  templateUrl: './edit-book.component.html',
  styleUrl: './edit-book.component.css',
  imports: [
    CommonModule,
    RouterLink,
    LanguageSelectorComponent,
    CategorySelectorComponent,
    TagInputComponent,
  ],
})
export class EditBookComponent implements OnInit {
  editMode = false;
  id!: number;

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.id = +params['id'];
      this.editMode = params['id'] != null;
    });
  }
}
