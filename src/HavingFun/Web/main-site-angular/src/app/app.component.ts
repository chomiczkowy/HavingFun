import { Component } from '@angular/core';
import {NgForm} from '@angular/forms';
import { UserModel } from './models/user-model';
import { AuthenticationService } from './services/authentication.service';
import { HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'main-site-angular';

  constructor(){

  }
}
