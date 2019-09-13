import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Subscription } from 'rxjs';
import { LoginUserModel } from '../models/users/login-user-model';
import { EditUserModel } from '../models/users/edit-user-model';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private apiUrl:string="https://localhost:44327/api/users";
  private loggedUserLocalStorageKey='having-fun-user';

  private loggedUser:EditUserModel = null;

  constructor(private http: HttpClient) { 
    var alreadyLoggedUserStr=localStorage.getItem(this.loggedUserLocalStorageKey);
    if(alreadyLoggedUserStr){
      var alreadyLoggedUser=<EditUserModel>JSON.parse(alreadyLoggedUserStr);
      if(alreadyLoggedUser && alreadyLoggedUser.token){
          this.loggedUser=alreadyLoggedUser;
      }
    }
  }
 
  public isAuthenticated(){
    return !!this.getAuthToken();
  }

  public authenticate(userModel:LoginUserModel): Subscription {
    return this.http.post<EditUserModel>(this.apiUrl+"/authenticate", userModel)
      .subscribe((response)=>{
          this.loggedUser=response;
          localStorage.setItem(this.loggedUserLocalStorageKey, JSON.stringify(this.loggedUser));
      }, (err)=>{
        alert(err);
      });
  }

  public logOff(){
    this.loggedUser=null;
    localStorage.removeItem(this.loggedUserLocalStorageKey);
  }

  public getAuthToken(){
    return this.loggedUser? this.loggedUser.token : null;
  }
}
