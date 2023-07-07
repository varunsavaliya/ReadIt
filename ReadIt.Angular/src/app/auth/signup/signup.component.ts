import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/apiservices/auth.service';
import { UserModel } from 'src/app/core/models/user.model';
import { UserAuthService } from 'src/app/core/services/user-auth.service';
import { LoginComponent } from '../login/login.component';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {
  dialogConfig = new MatDialogConfig();
  modalDialog: MatDialogRef<LoginComponent, any> | undefined;
  constructor(public dialogRef: MatDialogRef<SignupComponent>,private userAuthService: UserAuthService, private authService: AuthService, private router: Router, private matDialog: MatDialog) { }

  signUpForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required]),
  });
  get name() {
    return this.signUpForm.get('name');
  }
  get password() {
    return this.signUpForm.get('password');
  }
  get repassword() {
    return this.signUpForm.get('repassword');
  }
  get email() {
    return this.signUpForm.get('email');
  }
  public signupInvalid!: boolean;
  private formSubmitAttempt!: boolean;
  private returnUrl!: string;

  onSignUp() {
    if (this.signUpForm.valid) {
      const user: UserModel = {
        id: 0,
        email: this.signUpForm.controls.email.value,
        password: this.signUpForm.controls.password.value,
        name: this.signUpForm.controls.name.value,
        bio: null,
        avatar: null
      };
      if (this.signUpForm != null) {
      }
      this.authService.signup(user).subscribe({
        next: (response) => {
          if (response.success) {
            this.userAuthService.signup(response.token, response.data);
            this.closeSignUpModal();
            // localStorage.setItem('token', response.token);
            // localStorage.setItem('user', JSON.stringify(response.data));
          } else {
            console.log(response.message);
          }
        }
      })
    }
  }
  closeSignUpModal() {
    this.dialogRef.close();
  }

  openLoginModal() {
    this.dialogRef.close();
    this.matDialog.open(LoginComponent, this.dialogConfig);
  }
}
