import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserAuthService {

  constructor() { }
  isLoggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }
}
