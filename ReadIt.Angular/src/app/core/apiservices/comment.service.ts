import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CommentModel } from '../models/comment.model';
import { ResponseListModel, ResponseModel } from '../models/response.model';

@Injectable({
  providedIn: 'root'
})
export class CommentService {
  private ApiUrl : string = environment.baseApiUrl  + 'api/Comment/';

  constructor(private http: HttpClient) { }

  add(comment: CommentModel):Observable<ResponseModel>{
    return this.http.post<ResponseModel>(this.ApiUrl, comment);
  }
  
  getCommentsByBlogId(blogId: number, showAllComments: boolean): Observable<ResponseListModel<CommentModel>> {
    const params = { id: blogId.toString(), showAllComments: showAllComments };
    return this.http.get<ResponseListModel<CommentModel>>(this.ApiUrl, {params});
  }
}
