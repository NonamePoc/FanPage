import {
  AfterViewInit,
  Component,
  EventEmitter,
  Inject,
  Input,
  OnDestroy,
  Output,
  PLATFORM_ID,
} from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { CommonModule, isPlatformBrowser } from '@angular/common';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../auth.service';
import { ModalService } from '../../shared/modal/modal.service';

declare let google: any;

@Component({
  selector: 'app-google',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './google.component.html',
  styleUrl: './google.component.css',
})
export class GoogleComponent implements AfterViewInit, OnDestroy {
  @Input() isLogin: boolean = true;
  @Output() loadingChanged = new EventEmitter<boolean>();

  CLIENT_ID = environment.googleClientId;

  constructor(
    @Inject(PLATFORM_ID) private platformId: any,
    private toastr: ToastrService,
    private authService: AuthService,
    private modalService: ModalService
  ) {}

  ngAfterViewInit() {
    isPlatformBrowser(this.platformId) && this.initializeGoogleOneTap();
  }

  ngOnDestroy() {
    isPlatformBrowser(this.platformId) && google.accounts.id.cancel();
  }

  private initializeGoogleOneTap() {
    google.accounts.id.initialize({
      client_id: this.CLIENT_ID,
      callback: this.handleGoogleAuth.bind(this),
    });
    google.accounts.id.renderButton(document.getElementById('g_id'), {
      shape: 'pill',
      theme: 'outline',
      size: 'large',
    });
  }

  private handleGoogleAuth(response: any) {
    this.loadingChanged.emit(true);
    response.credential
      ? this.isLogin
        ? this.handleLogin(response.credential)
        : this.handleSignup(response.credential)
      : this.toastr.error('Google Sign-In failed', 'Error');
  }

  private handleLogin(googleToken: string) {
    let authObs = this.authService.googleLogin(googleToken);

    authObs.subscribe({
      next: () => {
        this.loadingChanged.emit(false);
      },
      error: (errorMessage) => {
        console.log(errorMessage);
        this.toastr.error(errorMessage, 'Error', {
          timeOut: 3000,
        });
      },
      complete: () => {
        this.toastr.success('You have been logged in', 'Welcome');
        this.modalService.closeModal('authModal');
      },
    });
  }

  private handleSignup(googleToken: string) {
    let authObs = this.authService.googleSignup(googleToken);

    authObs.subscribe({
      next: () => {
        this.toastr.success('You have been signed up', 'Welcome');
        this.modalService.closeModal('authModal');
      },
      error: (errorMessage) => {
        console.log(errorMessage);
        this.toastr.error(errorMessage, 'Error', {
          timeOut: 3000,
        });
      },
      complete: () => {
        this.loadingChanged.emit(false);
      },
    });
  }
}
