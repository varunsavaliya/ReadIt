import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ResponseDataModel, ResponseListModel, ResponseModel } from '../models/response.model';
import { Blog } from '../models/blog';

@Injectable({
  providedIn: 'root'
})
export class UserBlogService {

  private ApiUrl : string = environment.baseApiUrl  + 'api/UserBlogs/';

  constructor(private http: HttpClient) { }

  getAllByUserId(id: number): Observable<ResponseListModel<Blog>> {
    return this.http.get<ResponseListModel<Blog>>(this.ApiUrl + 'all/' + id);
  }

  create(blog: Blog): Observable<ResponseModel> {
    return this.http.post<ResponseModel>(this.ApiUrl, blog);
  }

  delete(id: number): Observable<ResponseModel> {
    return this.http.delete<ResponseModel>(this.ApiUrl + id);
  }

  getBlogById(id: number): Observable<ResponseDataModel<Blog>> {
    return this.http.get<ResponseDataModel<Blog>>(this.ApiUrl + id);
  }

  update(id: number, blog: Blog): Observable<ResponseModel> {
    return this.http.put<ResponseModel>(this.ApiUrl  + id, blog);
  }
}
