import { Component ,Input } from '@angular/core';
import { Blog } from 'src/app/core/models/blog';

@Component({
  selector: 'app-blog-card',
  templateUrl: './blog-card.component.html',
  styleUrls: ['./blog-card.component.css']
})
export class BlogCardComponent {
  @Input() blog: Blog = {} as Blog;

  ngOnInit(){
    
  }
}
