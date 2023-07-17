import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UserModel } from '../models/user.model';
import { AuthModel, ResponseModel } from '../models/response.model';
import { ChangePassModel } from '../models/change-pass.model';
import { observableToBeFn } from 'rxjs/internal/testing/TestScheduler';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private ApiUrl : string = environment.baseApiUrl  + 'gateway/auth';

  constructor(private http: HttpClient) { }

  login(email: string, password: string):Observable<AuthModel>{
    const params = new HttpParams()
      .set('email', email)
      .set('password', password);
    return this.http.get<AuthModel>(this.ApiUrl + '/' + 'login', {params});
  }
  
  signup(user: UserModel):Observable<AuthModel>{
    return this.http.post<AuthModel>(this.ApiUrl+ '/' + 'signup', user);
  }

  changePassword(data: ChangePassModel): Observable<ResponseModel>{
    return this.http.post<ResponseModel>(this.ApiUrl+ '/' + 'changePassword',data);
  }
}
