import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { BlogCardComponent } from './blog-card/blog-card.component';
import { CoreModule } from '../core/core.module';
import { AuthModule } from '../auth/auth.module';
import { AddBlogComponent } from './add-blog/add-blog.component';


@NgModule({
  declarations: [
    HomeComponent,
    BlogCardComponent,
    AddBlogComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    CoreModule,
  ]
})
export class HomeModule { }
