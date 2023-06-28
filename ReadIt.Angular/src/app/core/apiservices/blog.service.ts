import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ResponseListModel } from '../models/response.model';
import { Blog } from '../models/blog';

@Injectable({
  providedIn: 'root'
})
export class BlogService {

  
  baseApiUrl : string = environment.baseApiUrl;
  constructor(private http: HttpClient) { }

  getAll():Observable<ResponseListModel<Blog>>{
    return this.http.get<ResponseListModel<Blog>>(this.baseApiUrl + 'api/Blog');
  }
}
