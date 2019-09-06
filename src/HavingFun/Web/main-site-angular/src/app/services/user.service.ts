import { Injectable } from '@angular/core';
import { UserModel } from '../models/user-model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl:string="https://localhost:44327/api/users";

  constructor(private http:HttpClient) { }
 
  public getUsers(){
    return this.http.get<UserModel[]>(this.apiUrl);
  }
}
