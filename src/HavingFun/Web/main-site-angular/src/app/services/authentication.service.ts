import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserModel } from '../models/user-model';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private apiUrl:string="https://localhost:44327/api/users";

  private loggedUser:UserModel = null;

  constructor(private http: HttpClient) { 

  }
 

  public isAuthenticated(){
    return this.loggedUser && !!this.loggedUser.token;
  }

  public authenticate(userModel:UserModel){
    this.http.post<UserModel>(this.apiUrl+"/authenticate", userModel)
      .subscribe((response)=>{
          this.loggedUser=response;
      }, (err)=>{
        alert(err);
      });
  }

  private getHeaders(){
    var headers=new HttpHeaders();
    if(this.isAuthenticated()){
      headers=headers.set("Content-Type","application/json");
      headers=headers.set("Authorization", "Bearer " + this.loggedUser.token);
    }
    return headers;
  }
  
  public getUsers(){
    return this.http.get<UserModel[]>(this.apiUrl, {headers: this.getHeaders()});
  }
}
