import { Injectable } from '@angular/core';
import { UserModel } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserAuthService {

  constructor() { }
  isLoggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }

  getUserName(){
   const user : UserModel = JSON.parse(localStorage.getItem('user')!);
    return user.name;
  }

  getUserId(){
    const user : UserModel = JSON.parse(localStorage.getItem('user')!);
    return user.id;
  }
}
