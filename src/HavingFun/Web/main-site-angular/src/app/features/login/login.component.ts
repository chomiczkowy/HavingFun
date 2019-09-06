import { Component, OnInit } from '@angular/core';
import { UserModel } from 'src/app/models/user-model';
import { NgForm } from '@angular/forms';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private authService: AuthenticationService,
              private router:Router) { }

  ngOnInit() {
    this.redirectIfLoggedIn();
  }

  private redirectIfLoggedIn(){
    if(this.authService.isAuthenticated()){
      this.router.navigate(['user/list']);
    }
  }

  private userModel : UserModel={
    username:"",
    password:"",
  };

  onSubmit(f:NgForm){
    console.log(f.value);  
    console.log(f.valid);

    if(f.valid){
      this.authService.authenticate(this.userModel).add(()=>{
        this.redirectIfLoggedIn();
      });
    }
  }

  isAuthenticated(){
    return this.authService.isAuthenticated();
  }  
}
