import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home.component';
import { AddBlogComponent } from './add-blog/add-blog.component';

const routes: Routes = [
  {path:'',component: HomeComponent},
  { path: '', children:[
    {path:'add-blog', component:AddBlogComponent}
  ] },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
