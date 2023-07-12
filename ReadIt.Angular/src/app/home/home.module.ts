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
import { SideBarComponent } from './blogs/blog/side-bar/side-bar.component';
import { AuthorComponent } from './authors/author/author.component';
import { ArticleComponent } from './articles/article/article.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CommentFormComponent } from './blogs/blog/comment-form/comment-form.component';
import { RouterModule } from '@angular/router';
import { CommentsComponent } from './blogs/blog/comments/comments.component';
import { AppModule } from '../app.module';


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
    ArticleComponent,
    CommentFormComponent,
    CommentsComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    CoreModule,
    ReactiveFormsModule,
    RouterModule,
  ],
  exports:[
    BannerComponent
  ],
  providers: [CommentsComponent]
})
export class HomeModule { }
