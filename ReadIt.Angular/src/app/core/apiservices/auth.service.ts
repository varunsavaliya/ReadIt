import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UserModel } from '../models/user.model';
import { AuthModel } from '../models/response.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private ApiUrl : string = environment.baseApiUrl  + 'api/Auth/';

  constructor(private http: HttpClient) { }

  login(user: UserModel):Observable<AuthModel>{
    return this.http.post<AuthModel>(this.ApiUrl + 'login', user);
  }
  
  signup(user: UserModel):Observable<AuthModel>{
    return this.http.post<AuthModel>(this.ApiUrl + 'signup', user);
  }
}
