import { CommonModule } from '@angular/common';
import {
  Component,
  ElementRef,
  EventEmitter,
  HostListener,
  Input,
  Output,
} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BookService } from '../../book.service';
import { Category } from '../../models/category.model';
import { CategoryService } from '../../book/edit-book/category-selector/category.service';
import { BookFilter } from '../../models/book.model';

@Component({
  selector: 'app-filter',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './filter.component.html',
  styleUrl: './filter.component.css',
})
export class FilterComponent {
  @Input() books: any[] = [];
  @Input() isListLayout: boolean = true;
  @Input() filterOptions: BookFilter = {};
  @Output() filteredBooks = new EventEmitter<any[]>();
  @Output() layoutChange = new EventEmitter<boolean>();

  isOpen: boolean = false;
  categories = this.categoryService.getCategories();

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
    this.layoutChange.emit(true);
  }

  onGridLayout() {
    this.layoutChange.emit(false);
  }

  onSelectStatus = (status: string) => {
    this.filterOptions.status = status;
    this.filteredBooks.emit();
  };

  onSelectCategory = (category: Category) => {
    !this.filterOptions.categories && (this.filterOptions.categories = []);

    const index = this.filterOptions.categories.indexOf(category);
    index === -1
      ? this.filterOptions.categories.push(category)
      : this.filterOptions.categories.splice(index, 1);

    this.filteredBooks.emit();
  };

  onClearStatus = () => {
    this.filterOptions.status = undefined;
    this.filteredBooks.emit();
  };

  onClearCategory = (category: Category) => {
    if (this.filterOptions.categories) {
      this.filterOptions.categories.splice(
        this.filterOptions.categories.indexOf(category),
        1
      );
      this.filteredBooks.emit();
    }
  };
}
