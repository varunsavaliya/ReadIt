import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import ClassicEditor from '@ckeditor/ckeditor5-build-classic';
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
  public Editor = ClassicEditor;
  public editorConfig = {
    placeholder: 'Description',
    toolbar: [
      'heading', 'bold', 'italic',
      'link', 'bulletedList', 'numberedList', 'indent', 'outdent',
      'blockQuote', 'insertTable',
      'undo', 'redo'
    ],
    height: '4000px'
  };
  blog: Blog = new Blog;
  userId: number = this.userAuthService.getUserId();
  allCategories: CategoryModel[] = [];


  blogImageUrl: string | undefined;
  blogImage: File | null = null;
  blogForm: FormGroup = new FormGroup({
    title: new FormControl(null, [Validators.required]),
    description: new FormControl('', [Validators.required]),
    category: new FormControl(null, [Validators.required]),
    tags: new FormControl(null, [Validators.required]),
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

  constructor(private activeRoute: ActivatedRoute, private router: Router, private userAuthService: UserAuthService, private categoryService: CategoryService, private userBlogService: UserBlogService) { }


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
            });
            if (response.data.blogImageUrl) {
              this.blogImageUrl = 'data:image/jpeg;base64,' + response.data.blogImageUrl;
            }
          } else {
            this.router.navigate(['profile', 'blogs']);
          }
        }
      });
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
  onFileChange(event: any) {
    this.blogImage = event.target.files[0];
    if (this.blogImage) {
      // Do something with the file, such as storing it in a variable or uploading it
      console.log('Selected file:', this.blogImage);
    }
  }

  getBlogImagePreviewUrl() {
    if (this.blogImage) {
      return URL.createObjectURL(this.blogImage);
    }
    return '';
  }

  onSubmit() {
    console.log(this.blogImage);
    if (this.blogForm.valid) {
      const formData = new FormData();
      formData.append('title', this.blogForm.value.title);
      formData.append('description', this.blogForm.value.description);
      formData.append('tags', this.blogForm.value.tags);
      formData.append('createdBy', this.userId.toString());
      formData.append('categoryId', this.blogForm.value.category);
      if (this.blogImage) {
        const mediaType = 'image/jpeg'; // Replace with the desired media type
        const blob = new Blob([this.blogImage], { type: mediaType });
        formData.append('blogImage', blob, 'blogImage.jpg');
      }


      // this.blog.title = this.blogForm.value.title;
      // this.blog.description = this.blogForm.value.description;
      // this.blog.tags = this.blogForm.value.tags;
      // this.blog.categoryId = this.blogForm.value.category;
      // this.blog.createdBy = this.userId;
      // this.blog.blogImage = this.blogImage;
      if (this.getBlogId() != 0) {
        this.userBlogService.update(this.getBlogId(), formData).subscribe({
          next: (response) => {
            this.router.navigate(['profile', 'user-blogs'])
          }
        })
      }
      else {
        this.userBlogService.create(formData).subscribe({
          next: (response) => {
            this.router.navigate(['profile', 'user-blogs'])
            console.log(response);
          }
        })
      }
    }
  }
}
