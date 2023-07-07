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
  totalComments: number = 0;
  commentsToBeShown: number = 4;
  showAllComments: boolean = false;
  constructor(private commentService: CommentService) { }
  ngOnInit() {
    this.getComments();
  }

  getComments() {
    this.commentService.getCommentsByBlogId(this.blogId, this.showAllComments).subscribe({
      next: (response) => {
        this.comments = response.items;
        this.totalComments = response.totalItems;
      }
    })
  }

  toggleShowAllComments() {
    this.showAllComments = !this.showAllComments;
    this.getComments();
  }
}
