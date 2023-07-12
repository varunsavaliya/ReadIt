import { Component, OnInit, ViewChild, } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BlogService } from 'src/app/core/apiservices/blog.service';
import { Blog } from 'src/app/core/models/blog.model';
import { UserModel } from 'src/app/core/models/user.model';
import { CommentsComponent } from './comments/comments.component';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css']
})
export class BlogComponent implements OnInit {
  blog: Blog = {} as Blog;
  blogTags: string[] = [];
  user!: UserModel;
  @ViewChild(CommentsComponent) commentsComponent!: CommentsComponent;

  constructor(private activeRoute: ActivatedRoute, private blogService: BlogService, private router: Router) { }
  ngOnInit() {
    this.activeRoute.paramMap.subscribe(params => {
      const id = Number(params.get('id'));
      this.getBlogById(id);
    });
  }

  getBlogById(id: number) {
    this.blogService.getById(id).subscribe({
      next: (response) => {
        if (response.success) {
          this.blog = response.data;
          this.blogTags = response.data.tags.split(',')
        } else {
          this.router.navigate(['']);
        }
      }
    })
  }
}