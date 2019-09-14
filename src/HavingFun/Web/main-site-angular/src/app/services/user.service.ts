import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PageableQueryResult } from '../models/pageable-query-result';
import { DisplayUserModel } from '../models/users/display-user-model';
import { EditUserModel } from '../models/users/edit-user-model';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl:string="https://localhost:44327/api";

  constructor(private http:HttpClient) { }
 
  public getUsers(pageSize, pageNumber){
    return this.http.get<PageableQueryResult<DisplayUserModel>>(this.apiUrl+"/users", {params:{
      pageSize,
      pageNumber
    }});
  }

  public register(userModel: EditUserModel){
    return this.http.put<number>(this.apiUrl+"/user", userModel);
  }

  public checkUsernameNotTaken(username: string) {
    return this.http
      .get<number>(this.apiUrl+'/userByName', {params:{name: username}})
      .pipe(map(userId => !userId));
  }
}
