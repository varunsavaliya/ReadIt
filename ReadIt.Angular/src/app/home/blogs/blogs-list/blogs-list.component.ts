import { Component } from '@angular/core';
import { BlogService } from 'src/app/core/apiservices/blog.service';
import { UserBlogService } from 'src/app/core/apiservices/user-blog.service';
import { Blog } from 'src/app/core/models/blog.model';
import { ResponseListModel } from 'src/app/core/models/response.model';

@Component({
  selector: 'app-blogs-list',
  templateUrl: './blogs-list.component.html',
  styleUrls: ['./blogs-list.component.css']
})
export class BlogsListComponent {
  totalBlogs: number = 0;
  blogsPerPage: number = 3;
  currentPage: number = 1;
  allBlogs: any[] = [];
  constructor(private blogService: BlogService) { }

  ngOnInit() {
    this.getBlogs()
  }

  getBlogs(){
    this.blogService.getArticles(this.blogsPerPage, this.currentPage).subscribe({
      next: (response) => {
        this.allBlogs = response.items;
        this.totalBlogs = response.totalItems;
      }
    })
  }
  
  onPageChange(page: number) {
    this.currentPage = page;
    this.getBlogs();
  }
}
