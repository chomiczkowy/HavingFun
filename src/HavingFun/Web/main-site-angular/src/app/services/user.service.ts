import { Injectable } from '@angular/core';
import { UserModel } from '../models/user-model';
import { HttpClient } from '@angular/common/http';
import { PageableQueryResult } from '../models/pageable-query-result';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl:string="https://localhost:44327/api/users";

  constructor(private http:HttpClient) { }
 
  public getUsers(pageSize, pageNumber){
    return this.http.get<PageableQueryResult<UserModel>>(this.apiUrl, {params:{
      pageSize,
      pageNumber
    }});
  }
}
