import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProfileRoutingModule } from './profile-routing.module';
import { ProfileComponent } from './profile.component';
import { UserBlogsComponent } from './blogs/user-blogs/user-blogs.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { CoreModule } from '../core/core.module';
import { AddBlogComponent } from './blogs/add-blog/add-blog.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeModule } from '../home/home.module';


@NgModule({
  declarations: [
    ProfileComponent,
    UserBlogsComponent,
    UserProfileComponent,
    AddBlogComponent,
  ],
  imports: [
    CommonModule,
    ProfileRoutingModule,
    CoreModule,
    FormsModule,
    ReactiveFormsModule,
    HomeModule
  ]
})
export class ProfileModule { }
