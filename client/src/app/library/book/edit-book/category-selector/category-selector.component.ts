import { Component } from '@angular/core';
import { CategoryService } from './category.service';
import { CommonModule } from '@angular/common';
import { Category } from './category';
import { DropdownDirective } from '../../../../shared/dropdown.directive';

@Component({
  selector: 'app-category-selector',
  standalone: true,
  imports: [CommonModule, DropdownDirective],
  templateUrl: './category-selector.component.html',
  styleUrl: './category-selector.component.css',
})
export class CategorySelectorComponent {
  categories: Category[] = this.categoryService.getCategories();
  selectedCategories = [this.categories[0]];

  constructor(private categoryService: CategoryService) {}

  onSelectCategory(index: number, category: Category) {
    this.selectedCategories[index] = category;
  }

  onAddCategory() {
    this.selectedCategories.push(this.categories[0]);
  }

  onRemoveCategory(index: number) {
    this.selectedCategories.splice(index, 1);
  }
}
