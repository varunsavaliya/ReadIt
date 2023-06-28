import { Component } from '@angular/core';
import { BlogService } from '../core/apiservices/blog.service';
import { ResponseListModel  } from '../core/models/response.model';
import { Blog  } from '../core/models/blog';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
constructor(private blogService: BlogService){}

apiResponse: ResponseListModel<Blog> = {
items : [],
success: false,
message: ''
};

allBlogs: any[] = [];

ngOnInit(){
  this.blogService.getAll().subscribe({
    next: (response) => {
      this.apiResponse = response;
      this.allBlogs = this.apiResponse.items;
    }
  })
}
}
