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
  modalDialog: MatDialogRef<SignupComponent, any> | undefined;
  constructor(private snackbarService: SnackbarService, public dialogRef: MatDialogRef<LoginComponent>, private userAuthService: UserAuthService, private authService: AuthService, private router: Router, private matDialog: MatDialog) { }

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
  public loginInvalid!: boolean;
  private formSubmitAttempt!: boolean;
  private returnUrl!: string;

  onLogin() {
    if (this.loginForm.valid) {
      const user: UserModel = {
        id: 0,
        email: this.loginForm.controls.email.value,
        password: this.loginForm.controls.password.value,
        name: null,
        bio: null,
        avatar: null
      };
      if (this.loginForm != null) {
      }
      this.authService.login(user).subscribe({
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