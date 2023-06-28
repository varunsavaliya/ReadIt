import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/apiservices/auth.service';
import { UserModel } from 'src/app/core/models/user.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  constructor(public dialogRef: MatDialogRef<LoginComponent>, private authService: AuthService, private router: Router) { }

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
            localStorage.setItem('token', response.token);
            this.router.navigate(['']);
            console.log(response.message);
          } else {
            this.loginInvalid = true;
            console.log(response.message);
          }
        }
      })
    }
  }

  closeModal() {
    this.dialogRef.close();
  }
}
