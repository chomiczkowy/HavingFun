import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { DisplayUserModel } from 'src/app/models/users/display-user-model';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss']
})
export class UsersListComponent implements OnInit {
  defaultPageSize=10;
  allUsersCount=0;

  constructor(private userService:UserService) { }

  ngOnInit() {
    this.getUsers(10,0);
  }

  usersPage:DisplayUserModel[]=[];

  getUsers(pageSize, pageNumber){
    this.userService.getUsers(pageSize>0? pageSize : this.defaultPageSize, pageNumber>0?pageNumber:0).subscribe((results)=>{
      //TODO: find out why paginator is not fully working before first page size change - page numbers are not visible
      this.allUsersCount=results.allItemsCount;
      this.usersPage=results.items;
      
    }, (err)=>{
      alert(err);
    });
  }

  loadPage(event){
    ///TODO: Is there an interface type for event data?
    this.getUsers(event.rows, event.page);
  }
}
