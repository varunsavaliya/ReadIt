import { Component, Input } from '@angular/core';
import { Blog } from 'src/app/core/models/blog';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css']
})
export class ArticleComponent {
  @Input() article: Blog = {} as Blog;
}
