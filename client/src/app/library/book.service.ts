import { Injectable } from '@angular/core';
import { Book, BookFilter } from './models/book.model';

@Injectable({
  providedIn: 'root',
})
export class BookService {
  isListLayout: boolean = false;
  books: Book[] = [
    {
      id: 1,
      title: 'The Lord of the Rings',
      description:
        'The Lord of the Rings is an epic high-fantasy novel written by English author and scholar J. R. R. Tolkien.',
      imageCover:
        'https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1298411339l/33.jpg',
      status: 'In Progress',
      rating: 4.5,
      author: 'J.R.R. Tolkien',
      language: 'English',
      date: '1954',
      categories: [
        {
          id: 1,
          name: 'Romance',
          description:
            '&ensp;Indulge in tales of love, passion, and connection as characters navigate the intricate dance of emotions, weaving enchanting narratives that celebrate the enduring power of the heart.',
          icon: 'favorite',
          classNames: 'bg-rose-200 hover:bg-rose-300',
        },
        {
          id: 2,
          name: 'Fantasy',
          description:
            '&ensp;Immerse yourself in realms of magic, mythical creatures, and epic adventures where imagination knows no bounds.',
          icon: 'partly_cloudy_night',
          classNames: 'bg-purple-200 hover:bg-purple-300',
        },
        {
          id: 3,
          name: 'Action & Adventure',
          description:
            '&ensp;Brace for adrenaline-pumping narratives where courage meets chaos, and protagonists navigate perilous challenges in pursuit of excitement and triumph.',
          icon: 'sailing',
          classNames: 'bg-orange-200 hover:bg-orange-300',
        },
      ],
      tags: ['Fiction', 'Adventure', 'Fantasy'],
      chapters: [
        {
          id: 1,
          title: 'Chapter 1',
          content: 'The Fellowship of the Ring',
        },
        {
          id: 2,
          title: 'Chapter 2',
          content: 'The Two Towers',
        },
        {
          id: 3,
          title: 'Chapter 3',
          content: 'The Return of the King',
        },
      ],
    },
    {
      id: 2,
      title: 'To Kill a Mockingbird',
      description:
        'To Kill a Mockingbird is a novel by Harper Lee published in 1960. It was immediately successful, winning the Pulitzer Prize.',
      imageCover:
        'https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1553383690l/2657.jpg',
      status: 'Done',
      rating: 4.8,
      author: 'Harper Lee',
      language: 'English',
      date: '1960',
      categories: [
        {
          id: 2,
          name: 'Fantasy',
          description:
            '&ensp;Immerse yourself in realms of magic, mythical creatures, and epic adventures where imagination knows no bounds.',
          icon: 'partly_cloudy_night',
          classNames: 'bg-purple-200 hover:bg-purple-300',
        },
        {
          id: 8,
          name: 'Suspense and Thrillers',
          description:
            '&ensp;Dive into gripping narratives where tension tightens, and heart-pounding twists keep you on the edge, unraveling mysteries and testing characters in a relentless pursuit of the unknown.',
          icon: 'directions_run',
          classNames: 'bg-red-200 hover:bg-red-300',
        },
      ],
      tags: ['Classic', 'Fiction', 'Social Issues'],
      chapters: [
        {
          id: 1,
          title: 'Chapter 1',
          content: 'Introduction',
        },
        {
          id: 2,
          title: 'Chapter 2',
          content: 'Growing Up in Maycomb',
        },
        {
          id: 3,
          title: 'Chapter 3',
          content: 'The Trial',
        },
      ],
    },
    {
      id: 1,
      title: 'The Lord of the Rings',
      description:
        'The Lord of the Rings is an epic high-fantasy novel written by English author and scholar J. R. R. Tolkien.',
      imageCover:
        'https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1298411339l/33.jpg',
      status: 'In Progress',
      rating: 4.5,
      author: 'J.R.R. Tolkien',
      language: 'English',
      date: '1954',
      categories: [
        {
          id: 1,
          name: 'Romance',
          description:
            '&ensp;Indulge in tales of love, passion, and connection as characters navigate the intricate dance of emotions, weaving enchanting narratives that celebrate the enduring power of the heart.',
          icon: 'favorite',
          classNames: 'bg-rose-200 hover:bg-rose-300',
        },
        {
          id: 2,
          name: 'Fantasy',
          description:
            '&ensp;Immerse yourself in realms of magic, mythical creatures, and epic adventures where imagination knows no bounds.',
          icon: 'partly_cloudy_night',
          classNames: 'bg-purple-200 hover:bg-purple-300',
        },
        {
          id: 3,
          name: 'Action & Adventure',
          description:
            '&ensp;Brace for adrenaline-pumping narratives where courage meets chaos, and protagonists navigate perilous challenges in pursuit of excitement and triumph.',
          icon: 'sailing',
          classNames: 'bg-orange-200 hover:bg-orange-300',
        },
      ],
      tags: ['Fiction', 'Adventure', 'Fantasy'],
      chapters: [
        {
          id: 1,
          title: 'Chapter 1',
          content: 'The Fellowship of the Ring',
        },
        {
          id: 2,
          title: 'Chapter 2',
          content: 'The Two Towers',
        },
        {
          id: 3,
          title: 'Chapter 3',
          content: 'The Return of the King',
        },
      ],
    },
  ];
  filters: BookFilter = {};
  filteredBooks: Book[] = [...this.books];

  constructor() {}

  applyFilter() {
    this.filteredBooks = this.books.filter((book) => {
      if (this.filters.status && book.status !== this.filters.status) {
        return false;
      }

      if (this.filters.categories && this.filters.categories.length > 0) {
        const bookCategories = book.categories.map((category) => category.id);
        if (
          !this.filters.categories.every((category) =>
            bookCategories.includes(category.id)
          )
        ) {
          return false;
        }
      }

      if (this.filters.dateCreated && book.date !== this.filters.dateCreated) {
        return false;
      }

      return true;
    });
  }

  searchBooks(value: string) {
    this.filteredBooks = this.books.filter((book) => {
      return (
        book.title.toLowerCase().includes(value.toLowerCase()) ||
        book.description.toLowerCase().includes(value.toLowerCase()) ||
        (book.imageCover &&
          book.imageCover.toLowerCase().includes(value.toLowerCase())) ||
        book.language.toLowerCase().includes(value.toLowerCase())
      );
    });
    return this.filteredBooks;
  }
}
