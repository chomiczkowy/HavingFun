import { Component, OnInit } from '@angular/core';
import { NgForm, FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm:FormGroup;

  constructor(private authService: AuthenticationService,
              private router:Router,
              private fb:FormBuilder) { }

  ngOnInit() {
    this.redirectIfLoggedIn();

    this.loginForm=this.fb.group({
      username:['', Validators.required],
      password:['', Validators.required]
    });
   
  }

  private redirectIfLoggedIn(){
    if(this.authService.isAuthenticated()){
      this.router.navigate(['user/list']);
    }
  }

  onSubmit(){
    if(this.loginForm.valid){
      this.authService.authenticate(<any>this.loginForm.value)
        .add(()=>{
          this.redirectIfLoggedIn();
        });
    }
  }

  isAuthenticated(){
    return this.authService.isAuthenticated();
  }  
}
