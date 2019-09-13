import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PageableQueryResult } from '../models/pageable-query-result';
import { DisplayUserModel } from '../models/users/display-user-model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl:string="https://localhost:44327/api/users";

  constructor(private http:HttpClient) { }
 
  public getUsers(pageSize, pageNumber){
    return this.http.get<PageableQueryResult<DisplayUserModel>>(this.apiUrl, {params:{
      pageSize,
      pageNumber
    }});
  }
}
