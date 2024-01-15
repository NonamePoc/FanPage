import { Category } from './edit-book/category-selector/category';

export interface Book {
  id?: number;
  title: string;
  description: string;
  author: string;
  imageCover?: string;
  status: string;
  rating: number;
  language: string;
  date: string;
  categories: Category[];
  tags: string[];
  chapters?: Chapter[];
}

export interface BookFilter {
  status?: string;
  categories?: Category[];
  dateCreated?: string;
}

export interface Chapter {
  id: number;
  title: string;
  content: string;
}
