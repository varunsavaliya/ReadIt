import { Component, Input } from '@angular/core';
import { Blog } from 'src/app/core/models/blog.model';
import { DecimalPipe } from '@angular/common';
@Component({
  selector: 'app-blog-card',
  templateUrl: './blog-card.component.html',
  styleUrls: ['./blog-card.component.css'],
  providers: [DecimalPipe]
})
export class BlogCardComponent {
  @Input() blog: Blog = {} as Blog;
  readTime: number = 0;
  ngOnInit() {
    this.readTime = Math.ceil(this.blog.description.length / 170);
  }

  getDescription(): string {
    if (this.blog.description.length > 80) {
      return this.blog.description.slice(0, 80) + '...';
    } else {
      return this.blog.description;
    }
  }
  
}
