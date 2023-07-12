import { Component, Input } from '@angular/core';
import { Blog } from 'src/app/core/models/blog.model';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css']
})
export class ArticleComponent {
  @Input() article: Blog = {} as Blog;
  getDescription(): string {
    if (this.article.description.length > 100) {
      return this.article.description.slice(0, 100) + '...';
    } else {
      return this.article.description;
    }
  }
}
