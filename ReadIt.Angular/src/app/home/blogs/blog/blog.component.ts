import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BlogService } from 'src/app/core/apiservices/blog.service';
import { CategoryService } from 'src/app/core/apiservices/category.service';
import { Blog } from 'src/app/core/models/blog';
import { CategoryModel } from 'src/app/core/models/category.model';
import { UserModel } from 'src/app/core/models/user.model';
import { UserAuthService } from 'src/app/core/services/user-auth.service';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css']
})
export class BlogComponent {
  blog: Blog = {} as Blog;
  blogTags: string[] = [];
  blogImageUrl: string | undefined;
  user!: UserModel;
  commentForm: FormGroup = new FormGroup({
    name: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required]),
    website: new FormControl(null, [Validators.required]),
    message: new FormControl(null, [Validators.required]),
  });
  get name() {
    return this.commentForm.get('name');
  }
  get email() {
    return this.commentForm.get('email');
  }
  get website() {
    return this.commentForm.get('website');
  }
  get message() {
    return this.commentForm.get('message');
  }
  constructor(private userAuthService: UserAuthService, private categoryService: CategoryService, private activeRoute: ActivatedRoute, private blogService: BlogService, private router: Router) { }
  ngOnInit() {
    let id = 0;
    this.activeRoute.paramMap.subscribe({
      next: (params) => {
        id = Number(params.get('id'));
      },
    });
    if (this.userAuthService.getUser()) {
      this.user = this.userAuthService.getUser()
      this.commentForm.patchValue({
        name: this.user.name,
        email: this.user.email
      })
      this.name?.disable();
      this.email?.disable();
    }
    this.blogService.getById(id).subscribe({
      next: (response) => {
        if (!response.success) {
          this.router.navigate(['']);
        } else {
          this.blog = response.data;
          this.blogTags = this.blog.tags.split(',');
        }
      }
    })
  }

  onsubmit() { }
}
