import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ArticlesComponent } from './articles/articles.component';
import { AuthorsComponent } from './authors/authors.component';
import { BlogComponent } from './blogs/blog/blog.component';
import { HomeComponent } from './home.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'articles', component: ArticlesComponent},
  { path: 'articles/:id', component: ArticlesComponent},
  { path: 'authors', component: AuthorsComponent},
  { path: 'blog/:id', component: BlogComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
