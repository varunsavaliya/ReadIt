import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { authGuard } from './core/services/auth.guard';

const routes: Routes = [
  { path: 'auth', loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule),canActivate:[authGuard]  },
  { path: 'home', loadChildren: () => import('./home/home.module').then(m => m.HomeModule)},
  {path:'',  redirectTo:'home', pathMatch:'full' },
  { path: '**',component:HomeComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
