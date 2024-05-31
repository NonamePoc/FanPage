import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'imageNormalize',
  standalone: true,
})
export class ImageNormalizePipe implements PipeTransform {
  transform(value: string | undefined): any {
    if (!value) {
      return 'assets/img/placeholder.jpg';
    }

    var base64Content = `data:image/webp;base64,${value}`;
    return base64Content;
  }
}
