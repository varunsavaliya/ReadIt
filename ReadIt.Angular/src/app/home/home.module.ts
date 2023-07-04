import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { BlogCardComponent } from './blogs/blog-card/blog-card.component';
import { CoreModule } from '../core/core.module';
import { ArticlesComponent } from './articles/articles.component';
import { AuthorsComponent } from './authors/authors.component';
import { BlogsListComponent } from './blogs/blogs-list/blogs-list.component';
import { BlogComponent } from './blogs/blog/blog.component';
import { BannerComponent } from './banner/banner.component';
import { SideBarComponent } from './blogs/side-bar/side-bar.component';
import { AuthorComponent } from './authors/author/author.component';
import { ArticleComponent } from './articles/article/article.component';


@NgModule({
  declarations: [
    HomeComponent,
    BlogCardComponent,
    ArticlesComponent,
    AuthorsComponent,
    BlogsListComponent,
    BlogComponent,
    BannerComponent,
    SideBarComponent,
    AuthorComponent,
    ArticleComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    CoreModule,
  ],
  exports:[
    BannerComponent
  ]
})
export class HomeModule { }
