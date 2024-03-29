import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ReadingProgressService {
  getReadingProgress(): {
    [key: string]: { chapterId: number; scrollPosition?: number };
  } | null {
    const progress = localStorage.getItem('readingProgress');
    return progress ? JSON.parse(progress) : null;
  }

  getBookProgress(
    bookId: number
  ): { chapterId: number; scrollPosition?: number } | null {
    const progress = this.getReadingProgress();
    return progress ? progress[bookId] : null;
  }

  setReadingProgress(bookId: number, chapterId: number) {
    const progress = this.getReadingProgress() || {};
    progress[bookId] = { chapterId };
    localStorage.setItem('readingProgress', JSON.stringify(progress));
  }

  setScrollPosition(bookId: number, chapterId: number, scrollPosition: number) {
    const progress = this.getReadingProgress() || {};
    if (!progress[bookId]) {
      progress[bookId] = { chapterId };
    }
    progress[bookId].scrollPosition = scrollPosition;
    localStorage.setItem('readingProgress', JSON.stringify(progress));
  }

  clearProgress() {
    localStorage.removeItem('readingProgress');
  }
}
