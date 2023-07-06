import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ResponseDataModel, ResponseListModel, ResponseModel } from '../models/response.model';
import { Blog } from '../models/blog';

@Injectable({
  providedIn: 'root'
})
export class UserBlogService {

  private ApiUrl: string = environment.baseApiUrl + 'api/UserBlogs/';

  constructor(private http: HttpClient) { }

  getAllByUserId(id: number): Observable<ResponseListModel<Blog>> {
    return this.http.get<ResponseListModel<Blog>>(this.ApiUrl + 'all/' + id);
  }

  create(formData: FormData): Observable<ResponseModel> {
    const headers = new HttpHeaders();
    headers.append('Content-Type', 'multipart/form-data');
    return this.http.post<ResponseModel>(this.ApiUrl, formData);
  }

  delete(id: number): Observable<ResponseModel> {
    return this.http.delete<ResponseModel>(this.ApiUrl + id);
  }

  getBlogById(id: number): Observable<ResponseDataModel<Blog>> {
    return this.http.get<ResponseDataModel<Blog>>(this.ApiUrl + id);
  }

  // getBlogById(id: number): Observable<ResponseDataModel<Blog>> {
  //   return this.http.get<ResponseDataModel<Blog>>(this.ApiUrl + id).pipe(
  //     map((response: ResponseDataModel<Blog>) => {
  //       if (response.success && response.data && response.data.blogImage) {
  //         response.data.blogImageUrl = URL.createObjectURL(response.data.blogImage);
  //       }
  //       return response;
  //     })
  //   );
  // }
  

  update(id: number, formData: FormData): Observable<ResponseModel> {
    const headers = new HttpHeaders();
    headers.append('Content-Type', 'multipart/form-data');
    return this.http.put<ResponseModel>(this.ApiUrl + id, formData);
  }
}
