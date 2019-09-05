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

  allUsers:UserModel[]=[];

  constructor(private authService: AuthenticationService){

  }
  
  private userModel : UserModel={
    username:"",
    password:"",
  };

  onSubmit(f:NgForm){
    console.log(f.value);  
    console.log(f.valid);

    if(f.valid){
      this.authService.authenticate(this.userModel)
    }
  }

  isAuthenticated(){
    return this.authService.isAuthenticated();
  }  

  getUsers(){
    this.authService.getUsers().subscribe((results)=>{
      this.allUsers=results;
    }, (err)=>{
      alert(err);
    });
  }
}
