import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { HttpClientModule, HttpClient, HTTP_INTERCEPTORS } from '@angular/common/http'; 
import { AuthInterceptorService } from './core/services/auth-interceptor.service';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LoginComponent } from './auth/login/login.component';
import { BannerComponent } from './home/banner/banner.component';
import { HomeModule } from './home/home.module';

@NgModule({
  declarations: [
    AppComponent,
   
  ],
  imports: [
    AppRoutingModule,
    CoreModule,
    HttpClientModule,
    BrowserAnimationsModule,
    BrowserModule,
    CommonModule,
    FormsModule
  ],
  providers: [HttpClient,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
