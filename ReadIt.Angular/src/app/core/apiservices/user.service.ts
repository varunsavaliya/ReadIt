import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ResponseDataModel, ResponseModel } from '../models/response.model';
import { UserModel } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private ApiUrl: string = environment.baseApiUrl + 'api/User/';

  constructor(private http: HttpClient) { }

  getUserById(id: number): Observable<ResponseDataModel<UserModel>> {
    return this.http.get<ResponseDataModel<UserModel>>(this.ApiUrl + id);
  }

  editUser(id: number, formData: FormData): Observable<ResponseModel> {
    const headers = new HttpHeaders();
    headers.append('Content-Type', 'multipart/form-data');
    return this.http.post<ResponseModel>(this.ApiUrl + 'edit/' + id, formData);
  }
}
