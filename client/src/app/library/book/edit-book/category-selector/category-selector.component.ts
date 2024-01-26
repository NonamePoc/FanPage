import { Component } from '@angular/core';
import { CategoryService } from './category.service';
import { CommonModule } from '@angular/common';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Category, SelectedCategory } from '../../../models/category.model';
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
  selected: SelectedCategory[] = [];

  constructor(
    private categoryService: CategoryService,
    private toastr: ToastrService
  ) {}

  writeValue(value: any) {
    value &&
      (this.selected = value.map((category: Category) =>
        this.mapToCategory(category)
      ));
  }

  registerOnChange(fn: any) {
    this.onChanged = fn;
  }

  registerOnTouched(fn: any) {
    this.onTouched = fn;
  }

  onSelectCategory(index: number, category: Category) {
    this.onTouched();
    if (this.selected.find((selected) => selected.id === category.id)) {
      this.toastr.warning('Category already added!');
      return;
    }
    this.selected[index] = this.mapToCategory(category);
    this.onChanged(this.selected);
  }

  onAddCategory() {
    this.onTouched();
    this.selected.push(
      this.mapToCategory(
        this.categories.find(
          (category) =>
            !this.selected.find((selected) => selected.id === category.id)
        )!
      )
    );
    this.onChanged(this.selected);
  }

  onRemoveCategory(index: number) {
    this.selected.splice(index, 1);
    this.onChanged(this.selected);
  }

  private onChanged!: Function;
  private onTouched!: Function;

  private mapToCategory(category: Category) {
    return {
      id: category.id,
      name: category.name,
    };
  }
}
