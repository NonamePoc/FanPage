import { Category } from './category.model';
import { Chapter } from './chapter.model';

export interface Book {
  id?: number;
  title: string;
  description: string;
  image?: string;
  author: string;
  origin: boolean;
  status: string;
  rating?: number;
  language: string;
  date?: string;
  categories?: Category[];
  tags?: string[];
  chapters?: Chapter[];
}

export interface BookFilter {
  status?: string;
  categories?: Category[];
  dateCreated?: string;
}
