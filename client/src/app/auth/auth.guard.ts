import {
  ActivatedRouteSnapshot,
  CanActivateChildFn,
  CanActivateFn,
  RouterStateSnapshot,
} from '@angular/router';
import { AuthService } from './auth.service';
import { inject } from '@angular/core';
import { map, take } from 'rxjs/operators';
import { ModalService } from '../shared/modal/modal.service';

export const AuthGuard: CanActivateFn = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot
) => {
  const authService = inject(AuthService);
  const modal = inject(ModalService);

  return authService.user.pipe(
    take(1),
    map((user) => {
      const isAuth = !!user;
      if (isAuth) {
        return true;
      }
      modal.openModal('authModal');
      return false;
    })
  );
};

export const AuthGuardChild: CanActivateChildFn = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot
) => AuthGuard(route, state);
