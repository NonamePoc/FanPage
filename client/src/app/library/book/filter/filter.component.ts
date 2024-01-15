import { CommonModule } from '@angular/common';
import { Component, ElementRef, HostListener } from '@angular/core';
import { BookService } from '../../book.service';
import { CategoryService } from '../edit-book/category-selector/category.service';
import { BookFilter } from '../book';
import { FormsModule } from '@angular/forms';
import { Category } from '../edit-book/category-selector/category';

@Component({
  selector: 'app-filter',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './filter.component.html',
  styleUrl: './filter.component.css',
})
export class FilterComponent {
  isOpen: boolean = false;
  categories = this.categoryService.getCategories();
  filters = this.bookService.filters;

  constructor(
    public bookService: BookService,
    public categoryService: CategoryService,
    private elementRef: ElementRef
  ) {}

  @HostListener('document:click', ['$event'])
  onClickOutside(event: Event) {
    !this.elementRef.nativeElement.contains(event.target) &&
      (this.isOpen = false);
  }

  onToggle() {
    this.isOpen = !this.isOpen;
  }

  onListLayout() {
    this.bookService.isListLayout = true;
  }

  onGridLayout() {
    this.bookService.isListLayout = false;
  }

  onSelectStatus = (status: string) => {
    this.filters.status = status;
    this.bookService.applyFilter();
  };

  onSelectCategory = (category: Category) => {
    !this.filters.categories && (this.filters.categories = []);

    const index = this.filters.categories.indexOf(category);
    index === -1
      ? this.filters.categories.push(category)
      : this.filters.categories.splice(index, 1);

    this.bookService.applyFilter();
  };

  onClearStatus = () => {
    this.filters.status = undefined;
    this.bookService.applyFilter();
  };

  onClearCategory = (category: Category) => {
    if (this.filters.categories) {
      this.filters.categories.splice(
        this.filters.categories.indexOf(category),
        1
      );
      this.bookService.applyFilter();
    }
  };
}
