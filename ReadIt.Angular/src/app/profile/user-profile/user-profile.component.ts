import { NonNullAssert } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/apiservices/auth.service';
import { UserService } from 'src/app/core/apiservices/user.service';
import { ChangePassModel } from 'src/app/core/models/change-pass.model';
import { UserModel } from 'src/app/core/models/user.model';
import { SnackbarService } from 'src/app/core/services/snackbar.service';
import { UserAuthService } from 'src/app/core/services/user-auth.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  avatarImage: File | null = null;
  avatarPreview: string | null = null;
  user: UserModel = {} as UserModel;
  changePassData: ChangePassModel = {} as ChangePassModel;
  userForm: FormGroup = new FormGroup({
    name: new FormControl('', [Validators.required]),
    email: new FormControl(null, [Validators.required,]),
    bio: new FormControl(null, [Validators.required,]),
  });
  changePassForm: FormGroup = new FormGroup({
    oldPassword: new FormControl('', [Validators.required]),
    newPassword: new FormControl('', [Validators.required,]),
  });

  get name() {
    return this.userForm.get('name');
  }
  get email() {
    return this.userForm.get('email');
  }
  get bio() {
    return this.userForm.get('bio');
  }
  get oldPassword() {
    return this.changePassForm.get('oldPassword');
  }
  get newPassword() {
    return this.changePassForm.get('newPassword');
  }
  constructor(private snackbarService: SnackbarService,private authService: AuthService, private userService: UserService, private userAuthService: UserAuthService, private router: Router) { }

  ngOnInit() {
    this.userService.getUserById(this.userAuthService.getUserId()).subscribe({
      next: (response) => {
        this.user = response.data;
        this.userForm.patchValue({
          name: response.data.name,
          email: response.data.email,
          bio: response.data.bio,
        })
      }
    })
  }

 
  onFileChange(event: any) {
    this.avatarImage = event.target.files[0];
    const file = event.target.files[0];
    const reader = new FileReader();

    reader.onload = () => {
      const base64String = reader.result as string;
      this.avatarPreview = base64String;
    };

    reader.readAsDataURL(file);
  }
  onUserFormSubmit() {
    const formData = new FormData();
    formData.append('name', this.userForm.value.name);
    formData.append('bio', this.userForm.value.bio);

    if (this.avatarImage) {
      const mediaType = 'image/jpeg'; // Replace with the desired media type
      const blob = new Blob([this.avatarImage], { type: mediaType });
      formData.append('avatarImage', blob, 'blogImage.jpg');
    }
    if (this.userForm.valid) {
      this.userService.editUser(this.userAuthService.getUserId(), formData).subscribe({
        next: (response) => {
          this.snackbarService.openSnackBar(response.message)
          this.router.navigate(['/profile']);
        }
      })
    }
  }

  onChangePassword() {
    this.changePassData.oldPassword = this.changePassForm.value.oldPassword;
    this.changePassData.newPassword = this.changePassForm.value.newPassword;
    this.changePassData.userId = this.userAuthService.getUserId();
    if (this.changePassForm.valid) {
      this.authService.changePassword(this.changePassData).subscribe({
        next: (response) => {
          this.snackbarService.openSnackBar(response.message)
          this.router.navigate(['/profile']);
        }
      })
    }
  }

  onCancel(){
    this.router.navigate(['/profile'])
  }
}
