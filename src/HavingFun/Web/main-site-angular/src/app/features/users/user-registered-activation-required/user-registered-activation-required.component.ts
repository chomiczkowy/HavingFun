import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-registered-activation-required',
  templateUrl: './user-registered-activation-required.component.html',
  styleUrls: ['./user-registered-activation-required.component.scss']
})
export class UserRegisteredActivationRequiredComponent implements OnInit {
  emailAddress:string;

  constructor(private activatedRoute:ActivatedRoute) { }

  ngOnInit() {
    this.activatedRoute.queryParams.subscribe((params)=>{
      this.emailAddress=params.emailAddress;
    });
  }

}
