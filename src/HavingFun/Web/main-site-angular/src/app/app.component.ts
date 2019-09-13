import { Component } from '@angular/core';
import {NgForm} from '@angular/forms';
import { AuthenticationService } from './services/authentication.service';
import { HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'main-site-angular';

  constructor(private authService:AuthenticationService, private router: Router){

  }
  
  logOff(){
    this.authService.logOff();
    this.router.navigate(['/']);
  }
}
