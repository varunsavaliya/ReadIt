import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CategoryModel } from '../models/category.model';
import { ResponseListModel } from '../models/response.model';

@Injectable({
  providedIn: 'root'
})

export class CategoryService {

  private ApiUrl : string = environment.baseApiUrl  + 'api/Category';
  constructor(private http: HttpClient) { }

  getAll():Observable<ResponseListModel<CategoryModel>>{
    return this.http.get<ResponseListModel<CategoryModel>>(this.ApiUrl);
  }
}
