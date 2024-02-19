import { Component } from '@angular/core';
import { CategoryService } from './category.service';
import { CommonModule } from '@angular/common';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Category } from '../../../models/category.model';
import { DropdownDirective } from '../../../../shared/dropdown.directive';

@Component({
  selector: 'app-category-selector',
  standalone: true,
  imports: [CommonModule, DropdownDirective],
  templateUrl: './category-selector.component.html',
  styleUrl: './category-selector.component.css',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: CategorySelectorComponent,
      multi: true,
    },
  ],
})
export class CategorySelectorComponent implements ControlValueAccessor {
  categories: Category[] = this.categoryService.getCategories();
  selected: string[] = [];

  constructor(
    private categoryService: CategoryService,
    private toastr: ToastrService
  ) {}

  writeValue(value: any) {
    this.selected = value;
  }

  registerOnChange(fn: any) {
    this.onChanged = fn;
  }

  registerOnTouched(fn: any) {
    this.onTouched = fn;
  }

  onSelectCategory(index: number, category: Category) {
    this.onTouched();
    if (this.selected.includes(category.name)) {
      this.toastr.error('Category already selected');
      return;
    }
    this.selected[index] = category.name;
    this.onChanged(this.selected);
  }

  onAddCategory() {
    this.onTouched();
    const category = this.categories.find(
      (category) => !this.selected.includes(category.name)
    );
    if (!category) {
      this.toastr.error('All categories are selected');
      return;
    }
    this.selected.push(category.name);
    this.onChanged(this.selected);
  }

  onRemoveCategory(index: number) {
    this.onTouched();
    this.selected.splice(index, 1);
    this.onChanged(this.selected);
  }

  private onChanged!: Function;
  private onTouched!: Function;
}
