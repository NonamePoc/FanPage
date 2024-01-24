import { Component, ViewChild } from '@angular/core';
import { EditorComponent, EditorModule } from '@tinymce/tinymce-angular';
import { ToastrService } from 'ngx-toastr';
import { environment } from '../../../../../../environments/environment.development';

@Component({
  selector: 'app-edit-chapter',
  standalone: true,
  imports: [EditorModule],
  templateUrl: './edit-chapter.component.html',
  styleUrl: './edit-chapter.component.css',
})
export class EditChapterComponent {
  @ViewChild('editor') editor!: EditorComponent;

  API_KEY = environment.editorApiKey;

  constructor(private toastr: ToastrService) {}

  onSubmit(): void {
    this.editor.editor.getContent() === ''
      ? this.toastr.error('Chapter content cannot be empty')
      : this.toastr.success('Chapter saved');
  }
}
