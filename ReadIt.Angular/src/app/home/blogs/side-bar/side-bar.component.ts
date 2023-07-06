import { Component, Input } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BlogService } from 'src/app/core/apiservices/blog.service';
import { CategoryService } from 'src/app/core/apiservices/category.service';
import { Blog } from 'src/app/core/models/blog';
import { CategoryModel } from 'src/app/core/models/category.model';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.css']
})
export class SideBarComponent {
  categories: CategoryModel[] = [];
  recentBlogs: Blog[] = [];
  @Input() categoryId: number  = {} as number;
  @Input() blogId: number  = {} as number;

  serachCategoryForm: FormGroup = new FormGroup({
    searchText: new FormControl('', [Validators.required]),
  });
  get searchText() {
    return this.serachCategoryForm.get('searchText');
  }
  constructor(private categoryService: CategoryService, private blogService: BlogService) { }
  ngOnInit() {
    this.categoryService.getAll().subscribe({
      next: (response) => {
        this.categories = response.items;
      }
    })

    this.blogService.recentByCountAndCategory(3, this.categoryId, this.blogId).subscribe({
      next: (response) => {
        this.recentBlogs = response.items;
      }
    })
  }

  onsubmit(){
    if(this.serachCategoryForm.value.searchText == ''){
      this.categoryService.getAll().subscribe({
        next: (response) => {
          this.categories = response.items;
        }
      })
    }
    else{
      this.categoryService.searchCategory(this.serachCategoryForm.value.searchText).subscribe({
        next: (response) => {
          this.categories = response.items
        }
      })
    }
  }
}
