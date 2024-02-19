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
import { AuthGuard } from './auth/auth.guard';

export const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    pathMatch: 'full',
  },
  {
    path: 'books',
    component: LibraryComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'books',
    children: [
      {
        path: ':id',
        component: BookComponent,
      },
      {
        path: ':id/chapters/new',
        component: EditChapterComponent,
        canActivate: [AuthGuard],
      },
      {
        path: ':id/chapters/:chapterId',
        component: ChapterComponent,
      },
      {
        path: ':id/chapters/:chapterId/edit',
        component: EditChapterComponent,
        canActivate: [AuthGuard],
      },
    ],
  },
  {
    path: 'user/:username',
    component: UserComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'chat',
    component: ChatComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'chat/:id',
    component: ChatRoomComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'settings',
    component: SettingsComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'auth',
    component: AuthComponent,
  },
  {
    path: 'admin',
    component: AdminComponent,
    canActivate: [AuthGuard],
  },
];
