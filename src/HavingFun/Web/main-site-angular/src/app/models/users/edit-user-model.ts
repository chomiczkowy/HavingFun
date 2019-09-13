import { Claim } from './claim';

export interface EditUserModel{
    id?:number;
    username:string;
    password:string;
    token?:string;
    claims: Claim[]
  }