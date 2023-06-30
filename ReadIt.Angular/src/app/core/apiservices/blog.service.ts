import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ResponseDataModel, ResponseListModel } from '../models/response.model';
import { Blog } from '../models/blog';

@Injectable({
  providedIn: 'root'
})
export class BlogService {


  private ApiUrl : string = environment.baseApiUrl  + 'api/Blog/';

  constructor(private http: HttpClient) { }

  getAll(): Observable<ResponseListModel<Blog>> {
    return this.http.get<ResponseListModel<Blog>>(this.ApiUrl);
  }

  getById(id: number): Observable<ResponseDataModel<Blog>> {
    return this.http.get<ResponseDataModel<Blog>>(this.ApiUrl + id);
  }
}
