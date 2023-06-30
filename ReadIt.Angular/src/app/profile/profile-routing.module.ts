import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserBlogsComponent } from './blogs/user-blogs/user-blogs.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { AddBlogComponent } from './blogs/add-blog/add-blog.component';

const routes: Routes = [
  { path: '', component: UserProfileComponent },
  { path: 'user-blogs', component: UserBlogsComponent },
  { path: 'add-blog', component: AddBlogComponent },
  { path: 'blogs/:id', component: AddBlogComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProfileRoutingModule { }
