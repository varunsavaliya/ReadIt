import { CommaExpr } from '@angular/compiler';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CommentService } from 'src/app/core/apiservices/comment.service';
import { CommentModel } from 'src/app/core/models/comment.model';
import { UserModel } from 'src/app/core/models/user.model';
import { UserAuthService } from 'src/app/core/services/user-auth.service';

@Component({
  selector: 'app-comment-form',
  templateUrl: './comment-form.component.html',
  styleUrls: ['./comment-form.component.css']
})
export class CommentFormComponent {
  @Input() blogId!: number;
  @Output() commentAdded: EventEmitter<void> = new EventEmitter<void>();
  user!: UserModel;
  comment: CommentModel = {
    id: 0,
    blogId: this.blogId,
    createdOn: new Date(),
    createdBy: null,
    name: null,
    email: null,
    website: null,
    text: ''
  };
  commentForm: FormGroup = new FormGroup({
    name: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required]),
    website: new FormControl(null),
    message: new FormControl(null, [Validators.required]),
  });
  get name() {
    return this.commentForm.get('name');
  }
  get email() {
    return this.commentForm.get('email');
  }
  get website() {
    return this.commentForm.get('website');
  }
  get message() {
    return this.commentForm.get('message');
  }
  constructor(private userAuthService: UserAuthService, private commentService: CommentService, private router: Router) { }
  ngOnInit() {
    this.setForm()
  }

  ngOnChanges() {
    this.setForm()
  }
  setForm() {
    this.comment.blogId = this.blogId
    if (this.userAuthService.getUser()) {
      this.comment.createdBy = this.userAuthService.getUserId()

      this.user = this.userAuthService.getUser()
      this.commentForm.patchValue({
        name: this.user.name,
        email: this.user.email
      })
      this.name?.disable();
      this.email?.disable();
    }
  }

  onSubmit(event : Event) {
    event.preventDefault();
    if (this.commentForm.valid) {
      if (!this.comment.createdBy) {
        this.comment.name = this.commentForm.value.name
        this.comment.email = this.commentForm.value.email
      }
      this.comment.website = this.commentForm.value.website
      this.comment.text = this.commentForm.value.message
      this.commentService.add(this.comment).subscribe({
        next: (response) => {
          if (response.success) {
            this.commentForm.reset();
            if (this.userAuthService.getUser()) {
              this.commentForm.patchValue({
                name: this.user.name,
                email: this.user.email
              })
            }
            this.commentAdded.emit();
          }
          this.router.navigate(['/blog', this.blogId])
        }
      })
    }
    else {
      Object.values(this.commentForm.controls).forEach(control => {
        control.markAsTouched();
      });
    }
  }
}
