import { Component, Input, resolveForwardRef } from '@angular/core';
import { CommentService } from 'src/app/core/apiservices/comment.service';
import { CommentModel } from 'src/app/core/models/comment.model';

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.css']
})
export class CommentsComponent {
  @Input() blogId!: number;
  comments: CommentModel[] = [];
  constructor(private commentService: CommentService) { }
  ngOnInit() {
    this.commentService.getCommentsByBlogId(this.blogId).subscribe({
      next: (response) => {
        this.comments = response.items;
      }
    })
  }
}
