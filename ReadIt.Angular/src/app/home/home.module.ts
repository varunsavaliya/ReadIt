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
import { BannerComponent } from './blogs/banner/banner.component';


@NgModule({
  declarations: [
    HomeComponent,
    BlogCardComponent,
    ArticlesComponent,
    AuthorsComponent,
    BlogsListComponent,
    BlogComponent,
    BannerComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    CoreModule,
  ]
})
export class HomeModule { }
