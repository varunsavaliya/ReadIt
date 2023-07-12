import { ChangeDetectorRef, Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BlogService } from 'src/app/core/apiservices/blog.service';
import { CategoryService } from 'src/app/core/apiservices/category.service';
import { Blog } from 'src/app/core/models/blog';
import { UserModel } from 'src/app/core/models/user.model';
import { UserAuthService } from 'src/app/core/services/user-auth.service';
import { CommentsComponent } from './comments/comments.component';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css']
})
export class BlogComponent implements OnInit{
  blog: Blog = {} as Blog;
  blogTags: string[] = [];
  blogImageUrl: string | undefined;
  user!: UserModel;
  blogId!: number;

  constructor(private commentComp: CommentsComponent, private cdr: ChangeDetectorRef,private userAuthService: UserAuthService, private categoryService: CategoryService, private activeRoute: ActivatedRoute, private blogService: BlogService, private router: Router) { }
  ngOnInit() {
    let id = 0;
    debugger
    this.activeRoute.paramMap.subscribe(params => {
      const id = Number(params.get('id'));
      this.blogId = id;
      // this.commentComp.ngOnInit()
      this.getBlogById(id);
    console.log(this.blogId, "2");

    });
    console.log(this.blogId, "1");
    
  }




  getBlogById(id: number) {
    this.blogService.getById(id).subscribe({
      next: (response) => {
        if (response.success) {
          this.blog = response.data;
          this.blogTags = this.blog.tags.split(',');
          this.blogId = this.blog.id;
          console.log(this.blogId, "3");
        } else {
          this.router.navigate(['']);
        }
      }
    })
  }
}