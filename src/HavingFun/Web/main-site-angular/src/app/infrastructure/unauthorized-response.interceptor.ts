import { HttpInterceptor, HttpHandler, HttpEvent, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { AuthenticationService } from '../services/authentication.service';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';

export class UnauthorizedResponseInterceptor implements HttpInterceptor {
/**
 *
 */
    constructor(private authService:AuthenticationService,
                private router: Router) {
            
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).pipe(catchError(((err: HttpErrorResponse) =>{
            if(err.status === 401){
              this.authService.logOff();
              this.router.navigate(['/']);
            }

            if(err.status === 403){
              this.router.navigate(['error/insufficient-permissions']);             
            }

            return throwError('Request failed');
        })));
    }   
  }