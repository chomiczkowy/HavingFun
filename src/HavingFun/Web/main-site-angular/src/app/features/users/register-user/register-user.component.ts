import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder, AbstractControl } from '@angular/forms';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { ValidateUsernameNotTaken } from 'src/app/validators/validate-username-not-taken';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.scss']
})
export class RegisterUserComponent implements OnInit {
  registerUserForm:FormGroup;
  duringSave:boolean=false;

  constructor(private authService: AuthenticationService,
    private userService: UserService,
    private router:Router,
    private fb:FormBuilder) { }

  ngOnInit() {
    this.redirectIfLoggedIn();

    this.registerUserForm=this.fb.group({
      firstName:['', [Validators.required, Validators.maxLength(100)]],
      lastName:['', [Validators.required, Validators.maxLength(100)]],
      emailAddress:['', [Validators.required, Validators.email, Validators.minLength(7), Validators.maxLength(100)]],
      username:['', [Validators.required, Validators.minLength(7), Validators.maxLength(100)], ValidateUsernameNotTaken.createValidator(this.userService) ],
      password:['', [Validators.required, Validators.minLength(7), Validators.maxLength(100)]]
    });
   
  }
  
  private redirectIfLoggedIn(){
    if(this.authService.isAuthenticated()){
      this.router.navigate(['user/list']);
    }
  }

  onSubmit(){
    console.log(this.registerUserForm.value);  
    console.log(this.registerUserForm.valid);

    if(this.registerUserForm.valid){
      this.duringSave=true;

      this.userService.register(<any>this.registerUserForm.value)
        .subscribe((createdUserId)=>{
          this.duringSave=false;
          this.router.navigate(['user/activationRequired'], {
            queryParams:{emailAddress:this.registerUserForm.value.emailAddress}
          });
        }, (err)=>{
          this.duringSave=false;
        });
    }
  }
}
