import {
  HttpEvent,
  HttpInterceptorFn,
  HttpRequest,
  HttpHandlerFn,
} from '@angular/common/http';
import { Observable } from 'rxjs';

export const authInterceptor: HttpInterceptorFn = (
  req: HttpRequest<any>,
  next: HttpHandlerFn
): Observable<HttpEvent<any>> => {
  if (typeof localStorage !== 'undefined') {
    const userData = JSON.parse(localStorage.getItem('userData') || '{}');
    const token = userData._token;
    if (token) {
      const modifiedReq = req.clone({
        headers: req.headers
          .append('Authorization', 'Bearer ' + token)
          .append('ngrok-skip-browser-warning', 'true'),
      });
      return next(modifiedReq);
    }
  }
  return next(req);
};
