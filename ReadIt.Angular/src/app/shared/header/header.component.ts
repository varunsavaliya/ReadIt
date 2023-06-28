import { Component } from '@angular/core';
import { UserAuthService } from 'src/app/core/services/user-auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  
  constructor(private userAuthService: UserAuthService){}
  isLoggedIn:boolean = this.userAuthService.isLoggedIn(); 
  ngOnInit(){
  }
  logout(){
    localStorage.removeItem('token')
  }
}
