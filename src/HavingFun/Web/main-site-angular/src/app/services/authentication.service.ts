import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserModel } from '../models/user-model';
import { Subscription } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private apiUrl:string="https://localhost:44327/api/users";

  private loggedUser:UserModel = null;

  constructor(private http: HttpClient) { 

  }
 
  public isAuthenticated(){
    return !!this.getAuthToken();
  }

  public authenticate(userModel:UserModel): Subscription {
    return this.http.post<UserModel>(this.apiUrl+"/authenticate", userModel)
      .subscribe((response)=>{
          this.loggedUser=response;
      }, (err)=>{
        alert(err);
      });
  }

  public getAuthToken(){
    return this.loggedUser? this.loggedUser.token : null;
  }
}
