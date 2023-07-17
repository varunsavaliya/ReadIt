import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/apiservices/auth.service';
import { UserModel } from 'src/app/core/models/user.model';
import { SnackbarService } from 'src/app/core/services/snackbar.service';
import { UserAuthService } from 'src/app/core/services/user-auth.service';
import { SignupComponent } from '../signup/signup.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  dialogConfig = new MatDialogConfig();
  userEmail: string;
  userPassword: string;
  modalDialog: MatDialogRef<SignupComponent, any> | undefined;
  public loginInvalid!: boolean;
  loginForm = new FormGroup({
    password: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required]),
  });
  get email() {
    return this.loginForm.get('email');
  }
  get password() {
    return this.loginForm.get('password');
  }

  constructor(private snackbarService: SnackbarService, public dialogRef: MatDialogRef<LoginComponent>, private userAuthService: UserAuthService, private authService: AuthService, private router: Router, private matDialog: MatDialog) { }
  onLogin() {
    if (this.loginForm.valid) {
      if (this.loginForm.controls.email.value && this.loginForm.controls.password.value) {
        this.userEmail = this.loginForm.controls.email.value;
        this.userPassword = this.loginForm.controls.password.value;
      }
      if (this.loginForm != null) {
      }
      this.authService.login(this.userEmail, this.userPassword).subscribe({
        next: (response) => {
          if (response.success) {
            this.userAuthService.login(response.token, response.data);
            this.closeLoginModal()
            this.snackbarService.openSnackBar(response.message)
          } else {
            this.loginInvalid = true;
          }
        }
      })
    }
  }

  closeLoginModal() {
    this.dialogRef.close();
  }

  openSignUpModal() {
    this.dialogRef.close();
    this.matDialog.open(SignupComponent, this.dialogConfig);
  }
}