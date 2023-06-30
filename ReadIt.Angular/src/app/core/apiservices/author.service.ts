import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ResponseListModel } from '../models/response.model';
import { UserModel } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class AuthorService {
  private ApiUrl : string = environment.baseApiUrl  + 'api/Author/';

  constructor(private http: HttpClient) { }

  getAll(): Observable<ResponseListModel<UserModel>> {
    return this.http.get<ResponseListModel<UserModel>>(this.ApiUrl);
  }
}
