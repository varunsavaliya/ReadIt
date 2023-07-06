import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ResponseDataModel, ResponseListModel } from '../models/response.model';
import { Blog } from '../models/blog';

@Injectable({
  providedIn: 'root'
})
export class BlogService {


  private ApiUrl: string = environment.baseApiUrl + 'api/Blog/';

  constructor(private http: HttpClient) { }

  getArticles(pageSize: number, currentPage: number): Observable<ResponseListModel<Blog>> {
    const params = new HttpParams()
      .set('pageSize', pageSize.toString())
      .set('currentPage', currentPage.toString());
    return this.http.get<ResponseListModel<Blog>>(this.ApiUrl, { params });
  }

  getById(id: number): Observable<ResponseDataModel<Blog>> {
    return this.http.get<ResponseDataModel<Blog>>(this.ApiUrl + id);
  }

  getByCategoryId(pageSize: number, currentPage: number, id: number): Observable<ResponseListModel<Blog>> {
    const params = new HttpParams()
      .set('pageSize', pageSize.toString())
      .set('currentPage', currentPage.toString());
    return this.http.get<ResponseListModel<Blog>>(this.ApiUrl + 'category/' + id, {params});
  }

  recentByCount(count: number): Observable<ResponseListModel<Blog>> {
    return this.http.get<ResponseListModel<Blog>>(this.ApiUrl + 'recent/' + count);
  }
  recentByCountAndCategory(count: number, categoryId: number, blogId: number): Observable<ResponseListModel<Blog>> {
    return this.http.get<ResponseListModel<Blog>>(this.ApiUrl + 'recent/' + count + '/' + blogId + '/' + categoryId);
  }
}
