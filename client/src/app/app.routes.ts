import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { BookComponent } from './library/book/book.component';
import { UserComponent } from './user/user.component';
import { ChatComponent } from './chat/chat.component';
import { AuthComponent } from './auth/auth.component';
import { AdminComponent } from './admin/admin.component';
import { SettingsComponent } from './settings/settings.component';
import { ChatRoomComponent } from './chat/chat-room/chat-room.component';
import { LibraryComponent } from './library/library.component';
import { EditBookComponent } from './library/book/edit-book/edit-book.component';
import { ChapterComponent } from './library/book/chapters/chapter/chapter.component';
import { EditChapterComponent } from './library/book/chapters/chapter/edit-chapter/edit-chapter.component';

export const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    pathMatch: 'full',
  },
  {
    path: 'books',
    component: LibraryComponent,
  },
  {
    path: 'books/new',
    component: EditBookComponent,
  },
  {
    path: 'books/:id',
    component: BookComponent,
  },
  {
    path: 'books/:id/edit',
    component: EditBookComponent,
  },
  {
    path: 'books/:id/chapters/:chapterId',
    component: ChapterComponent,
  },
  {
    path: 'books/:id/chapters/:chapterId/edit',
    component: EditChapterComponent,
  },
  {
    path: 'user/:id',
    component: UserComponent,
  },
  {
    path: 'chat',
    component: ChatComponent,
  },
  {
    path: 'chat/:id',
    component: ChatRoomComponent,
  },
  {
    path: 'settings',
    component: SettingsComponent,
  },
  {
    path: 'auth',
    component: AuthComponent,
  },
  {
    path: 'admin',
    component: AdminComponent,
  },
];
