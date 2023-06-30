import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryService } from 'src/app/core/apiservices/category.service';
import { UserBlogService } from 'src/app/core/apiservices/user-blog.service';
import { Blog } from 'src/app/core/models/blog';
import { CategoryModel } from 'src/app/core/models/category.model';
import { UserAuthService } from 'src/app/core/services/user-auth.service';

@Component({
  selector: 'app-add-blog',
  templateUrl: './add-blog.component.html',
  styleUrls: ['./add-blog.component.css']
})
export class AddBlogComponent {
  //   blog:Blog = {
  // title:
  //   };
  blog: Blog = new Blog;
  userId: number = this.userAuthService.getUserId();
  constructor(private activeRoute: ActivatedRoute, private router: Router, private userAuthService: UserAuthService, private categoryService: CategoryService, private userBlogService: UserBlogService) { }

  allCategories: CategoryModel[] = [];

  ngOnInit() {
    this.categoryService.getAll().subscribe({
      next: (response) => {
        this.allCategories = response.items;
      }
    })
    if (this.getBlogId() != 0) {
      this.userBlogService.getBlogById(this.getBlogId()).subscribe({
        next: (response) => {
          if (response.success) {
            this.blogForm.patchValue({
              title: response.data.title,
              description: response.data.description,
              category: response.data.categoryId,
              tags: response.data.tags,
            })
          }
          else {
            this.router.navigate(['profile', 'blogs'])
          }
        }
      })
    }
  }

  getBlogId(): number {
    let id = 0;
    this.activeRoute.paramMap.subscribe({
      next: (params) => {
        id = Number(params.get('id'));
      },
    });
    return id;
  }


  blogForm: FormGroup = new FormGroup({
    title: new FormControl('', [Validators.required]),
    description: new FormControl(null, [Validators.required,]),
    category: new FormControl(null, [Validators.required,]),
    tags: new FormControl('', [Validators.required]),
    // blogImage: new FormControl('', [Validators.required]),
  });

  get title() {
    return this.blogForm.get('title');
  }
  get description() {
    return this.blogForm.get('description');
  }
  get category() {
    return this.blogForm.get('category');
  }
  get tags() {
    return this.blogForm.get('tags');
  }
  // get blogImage() {
  //   return this.blogForm.get('blogImage');
  // }
  onSubmit() {
    if (this.blogForm.valid) {
      this.blog.title = this.blogForm.value.title;
      this.blog.description = this.blogForm.value.description;
      this.blog.tags = this.blogForm.value.tags;
      this.blog.categoryId = this.blogForm.value.category;
      this.blog.createdBy = this.userId;

      if (this.getBlogId() != 0) {
        this.userBlogService.update(this.getBlogId(), this.blog).subscribe({
          next: (response) => {
            this.router.navigate(['profile', 'user-blogs'])
          }
        })
      }
      else {
        this.userBlogService.create(this.blog).subscribe({
          next: (response) => {
            this.router.navigate(['profile', 'user-blogs'])
            console.log(response);
          }
        })
      }
    }
  }
}
