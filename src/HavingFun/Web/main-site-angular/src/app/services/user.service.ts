import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PageableQueryResult } from '../models/pageable-query-result';
import { DisplayUserModel } from '../models/users/display-user-model';
import { EditUserModel } from '../models/users/edit-user-model';
import { map } from 'rxjs/operators';
import { environment } from './../../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http:HttpClient) { }
 
  public getUsers(pageSize, pageNumber){
    return this.http.get<PageableQueryResult<DisplayUserModel>>(environment.adminApiUrl + "users", {params:{
      pageSize,
      pageNumber
    }});
  }

  public register(userModel: EditUserModel){
    return this.http.put<number>(environment.userManagementApiUrl +"user", userModel);
  }

  public checkUsernameNotTaken(username: string) {
    return this.http
      .get<number>(environment.userManagementApiUrl +'userByName', {params:{name: username}})
      .pipe(map(userId => !userId));
  }
}
