import { Component } from '@angular/core';
import { BlogService } from 'src/app/core/apiservices/blog.service';
import * as signalR from '@microsoft/signalr';
import { environment } from 'src/environments/environment';
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
    this.getBlogs();
  }

  getBlogs() {
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
