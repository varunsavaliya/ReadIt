import { Component } from '@angular/core';
import { BlogService } from 'src/app/core/apiservices/blog.service';
import { UserBlogService } from 'src/app/core/apiservices/user-blog.service';
import { Blog } from 'src/app/core/models/blog';
import { ResponseListModel } from 'src/app/core/models/response.model';

@Component({
  selector: 'app-blogs-list',
  templateUrl: './blogs-list.component.html',
  styleUrls: ['./blogs-list.component.css']
})
export class BlogsListComponent {
  constructor(private blogService: BlogService) { }

  apiResponse: ResponseListModel<Blog> = {
    items: [],
    success: false,
    message: ''
  };

  allBlogs: any[] = [];

  ngOnInit() {
    this.blogService.getAll().subscribe({
      next: (response) => {
        this.allBlogs = response.items;
      }
    })
  }

  
}
