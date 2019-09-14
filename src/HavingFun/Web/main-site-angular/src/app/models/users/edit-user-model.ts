import { Claim } from './claim';

export interface EditUserModel{
    id?:number;
    username:string;
    password:string;
    token?:string;
    firstName:string;
    lastName:string;
    emailAddress:string;
    claims: Claim[]
  }