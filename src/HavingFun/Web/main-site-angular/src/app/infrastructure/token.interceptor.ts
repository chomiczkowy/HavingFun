import { HttpInterceptor, HttpHandler, HttpEvent, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthenticationService } from '../services/authentication.service';

export class TokenInterceptor implements HttpInterceptor {
/**
 *
 */
    constructor(private authService:AuthenticationService) {
            
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        var token=this.authService.getAuthToken();
        if(token){

            const modified = req.clone({ 
                setHeaders: { "Authorization": "Bearer " + this.authService.getAuthToken()} 
              });

            return next.handle(modified);
        }

        return next.handle(req);
    }
    
  }