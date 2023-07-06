import { HttpClient, HttpParams } from '@angular/common/http';
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

  getAuthors(pageSize: number, currentPage: number): Observable<ResponseListModel<UserModel>> {
    const params = new HttpParams()
      .set('pageSize', pageSize.toString())
      .set('currentPage', currentPage.toString());
  
    return this.http.get<ResponseListModel<UserModel>>(this.ApiUrl, { params });
  }
  
}
