import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ImageValidateService {
  allowedExtensions = ['png', 'jpeg', 'jpg'];
  maxFileSize = 5 * 1024 * 1024;

  constructor() {}

  validateImage(file: File): string | null {
    if (!file) {
      return 'No file selected.';
    }

    const extension = file.name.split('.').pop()?.toLowerCase();
    if (!extension || !this.allowedExtensions.includes(extension)) {
      return 'Invalid file extension. Please select a PNG, JPEG, or JPG file.';
    }

    if (file.size > this.maxFileSize) {
      return 'File size exceeds limit (5MB).';
    }

    return null;
  }
}
