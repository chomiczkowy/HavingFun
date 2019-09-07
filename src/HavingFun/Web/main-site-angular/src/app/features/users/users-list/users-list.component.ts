import { Component, OnInit } from '@angular/core';
import { UserModel } from 'src/app/models/user-model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss']
})
export class UsersListComponent implements OnInit {

  constructor(private userService:UserService) { }

  ngOnInit() {
    this.getUsers();
  }

  allUsers:UserModel[]=[];

  getUsers(){
    this.userService.getUsers().subscribe((results)=>{
      this.allUsers=results;
    }, (err)=>{
      alert(err);
    });
  }

}
