import { Component } from '@angular/core';
import { BlogService } from 'src/app/core/apiservices/blog.service';
import { Blog } from 'src/app/core/models/blog';
import { ResponseListModel } from 'src/app/core/models/response.model';

@Component({
  selector: 'app-articles',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.css']
})
export class ArticlesComponent {
  constructor(private blogService: BlogService) { }

  apiResponse: ResponseListModel<Blog> = {
    items: [],
    success: false,
    message: ''
  };

  articles: any[] = [];

  ngOnInit() {
    this.blogService.getAll().subscribe({
      next: (response) => {
        this.articles = response.items;
      }
    })
  }
}
