import { Category } from './category.model';
import { Chapter } from './chapter.model';

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
