import { Component } from '@angular/core';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { LoginComponent } from 'src/app/auth/login/login.component';
import { UserAuthService } from 'src/app/core/services/user-auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  dialogConfig = new MatDialogConfig();
  modalDialog: MatDialogRef<LoginComponent, any> | undefined;
  isLoggedIn: boolean = this.userAuthService.isLoggedIn();
  userName: string | null = null;

  ngOnInit() {
    if (this.isLoggedIn) {
      this.userName = this.userAuthService.getUserName();
    }
  }
  constructor( private userAuthService: UserAuthService, private matDialog: MatDialog, private router: Router) { }

  openLoginModal() {
    this.matDialog.open(LoginComponent, this.dialogConfig).afterClosed().subscribe(() => {
      this.userName = this.userAuthService.getUserName();
      this.isLoggedIn = this.userAuthService.isLoggedIn();
    });
  }

  logout() {
    this.router.navigate(['']);
    localStorage.removeItem('token')
    localStorage.removeItem('user')
    localStorage.removeItem('userName')
    this.isLoggedIn = false;
  }
}
