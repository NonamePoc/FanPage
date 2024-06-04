import {
  ActivatedRouteSnapshot,
  CanActivateChildFn,
  CanActivateFn,
  RouterStateSnapshot,
} from '@angular/router';
import { inject } from '@angular/core';
import { map, take } from 'rxjs/operators';
import { AuthService } from '../auth/auth.service';
import { ModalService } from '../shared/modal/modal.service';

export const AdminGuard: CanActivateFn = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot
) => {
  const authService = inject(AuthService);
  const modal = inject(ModalService);

  return authService.user.pipe(
    take(1),
    map((user) => {
      const isAdmin = user?.role === 'Admin';
      if (isAdmin) {
        return true;
      }
      modal.openModal('authModal');
      return false;
    })
  );
};

export const AdminGuardChild: CanActivateChildFn = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot
) => AdminGuard(route, state);
