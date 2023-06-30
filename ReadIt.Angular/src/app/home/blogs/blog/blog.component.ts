import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BlogService } from 'src/app/core/apiservices/blog.service';
import { Blog } from 'src/app/core/models/blog';
import { UserAuthService } from 'src/app/core/services/user-auth.service';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css']
})
export class BlogComponent {
  blog: Blog = {} as Blog;
  blogTags: string[] = [];
  constructor(private activeRoute: ActivatedRoute, private blogService: BlogService, private router: Router) { }
  ngOnInit() {
    let id = 0;
    this.activeRoute.paramMap.subscribe({
      next: (params) => {
        id = Number(params.get('id'));
      },
    });

    this.blogService.getById(id).subscribe({
      next : (response) => {
        if(!response.success){
          this.router.navigate(['']);
        }else{
          this.blog = response.data;
          this.blogTags = this.blog.tags.split(',');
          console.log(this.blogTags);
          
          console.log(response);
        }
      }
    })
  }
}
