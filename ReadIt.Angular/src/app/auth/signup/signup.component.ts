import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/apiservices/auth.service';
import { UserModel } from 'src/app/core/models/user.model';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {

  constructor(private authService: AuthService, private router: Router) { }

  signUpForm = new FormGroup({
    name:new FormControl('',[Validators.required]),
    password:new FormControl('',[Validators.required]),
    // repassword:new FormControl('',[Validators.required,  this.checkPasswords.bind(this)]),
    email:new FormControl('',[Validators.required]),
  });
  // checkPasswords(control: FormControl): any {
  //   const pass: string | null = this.signUpForm.controls.password.value;
  //   const confirmPass: string | null = control.value;

  //   return pass === confirmPass ? null : { notSame: true };
  // }
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

    onSignUp(){
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
              localStorage.setItem('token', response.token);
              this.router.navigate(['']);
              console.log(response.message);
            } else {
              console.log(response.message);
            }
          }
        })
      }
    }
}
