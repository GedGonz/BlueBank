import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent,HttpErrorResponse } from '@angular/common/http';
import { Observable,throwError  } from 'rxjs';
import { AuthService } from "../services/auth.service";
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptorService implements HttpInterceptor  {

  constructor(private _authService: AuthService, private _route: Router) { }

  
intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>>
{     

  const token: string = this._authService.getToken();
 
  let request = req;

  if (token) {
    request = req.clone({
      setHeaders: {
        authorization: `Bearer ${ token }`
      }
    });
  }
  
  return next.handle(request).pipe(
    catchError((err: HttpErrorResponse) => {

      if (err.status === 401) {
        this._authService.logout();
        this._route.navigateByUrl('/login');
      }

      return throwError( err );

    })
  );
}
  


}
