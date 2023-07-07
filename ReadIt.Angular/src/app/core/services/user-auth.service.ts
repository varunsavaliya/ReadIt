import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { UserModel } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserAuthService {
  private isLoggedInSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  isLoggedIn$: Observable<boolean> = this.isLoggedInSubject.asObservable();

  private userNameSubject: BehaviorSubject<string> = new BehaviorSubject<string>(this.getUserName());
  userName$: Observable<string> = this.userNameSubject.asObservable();
  constructor() { }
  login(token: string, user: UserModel) {
    this.isLoggedInSubject.next(true);
    this.setUserAndToken(token, user);
    this.userNameSubject.next(user.name || '');
  }

  signup(token: string, user: UserModel) {
    this.isLoggedInSubject.next(true);
    this.setUserAndToken(token, user);
    this.userNameSubject.next(user.name || '');
  }

  logout() {
    localStorage.removeItem('token')
    localStorage.removeItem('user')
    this.isLoggedIn$.subscribe((isLoggedIn) => {
      console.log(isLoggedIn);
    });
    this.isLoggedInSubject.next(false);
    this.userNameSubject.next('');
    this.isLoggedIn$.subscribe((isLoggedIn) => {
      console.log(isLoggedIn);
    });
  }
  isLoggedIn(): BehaviorSubject<boolean> {
    const token = localStorage.getItem('token');
    return new BehaviorSubject<boolean>(!!token);
  }

  setUserAndToken(token: string, user: UserModel) {
    localStorage.setItem('token', token);
    localStorage.setItem('user', JSON.stringify(user));
  }

  getUserName() {
    let userName = '';
    this.isLoggedIn$.subscribe((isLoggedIn) => {
      if (isLoggedIn) {
        const user: UserModel = JSON.parse(localStorage.getItem('user')!);
        userName = user.name!;
      }
    });
    return userName;
  }

  getUserId() {
    const user: UserModel = JSON.parse(localStorage.getItem('user')!);
    return user.id;
  }

  getUser() {
    const user: UserModel = JSON.parse(localStorage.getItem('user')!);
    return user;
  }
}
