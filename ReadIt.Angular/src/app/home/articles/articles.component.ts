import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BlogService } from 'src/app/core/apiservices/blog.service';
import { CategoryService } from 'src/app/core/apiservices/category.service';

@Component({
  selector: 'app-articles',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.css']
})
export class ArticlesComponent {
  categoryId!: number;
  bannerHeading: string = 'Articles';
  totalArticles: number = 0;
  articlesPerPage: number = 3;
  currentPage: number = 1;

  articles: any[] = [];
  constructor(private blogService: BlogService, private activatedRoute: ActivatedRoute, private categoryService: CategoryService, private router: Router) { }


  ngOnInit() {
    this.activatedRoute.paramMap.subscribe({
      next: (params) => {
        this.categoryId = Number(params.get('id'));
      },
    });
    if (this.categoryId) {
      this.categoryService.getById(this.categoryId).subscribe({
        next: (response) => {
          this.bannerHeading = response.data.name
        }
      })
      this.getArticlesByCategoryId();
    }
    else {
      this.getArticles();
    }
  }

  getArticlesByCategoryId() {
    this.blogService.getByCategoryId(this.articlesPerPage, this.currentPage, this.categoryId).subscribe({
      next: (response) => {
        this.articles = response.items;
        this.totalArticles = response.totalItems
      }
    })
  }

  getArticles() {
    this.blogService.getArticles(this.articlesPerPage, this.currentPage).subscribe({
      next: (response) => {
        this.articles = response.items;
        this.totalArticles = response.totalItems
      }
    })
  }

  onPageChange(page: number) {
    this.currentPage = page;
    if (this.categoryId) {
      this.getArticlesByCategoryId();
    }
    else {
      this.getArticles();
    }
  }
}
