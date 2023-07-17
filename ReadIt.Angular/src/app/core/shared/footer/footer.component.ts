import { Component } from '@angular/core';
import { BlogService } from 'src/app/core/apiservices/blog.service';
import { Blog } from 'src/app/core/models/blog.model';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent {
  recentBlogs: Blog[] = [];
  constructor(private blogService: BlogService) { }

  ngOnInit() {
    this.getRecentBlogs();
  }

  ngOnChange() {
    this.getRecentBlogs();
  }

  getRecentBlogs() {
    this.blogService.recentByCount(2).subscribe({
      next: (response) => {
        this.recentBlogs = response.items;
      }
    })
  }
}
