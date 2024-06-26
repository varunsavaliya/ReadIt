import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { UserBlogService } from 'src/app/core/apiservices/user-blog.service';
import { Blog } from 'src/app/core/models/blog.model';
import { SnackbarService } from 'src/app/core/services/snackbar.service';
import { UserAuthService } from 'src/app/core/services/user-auth.service';
import { ConfirmationModalComponent } from 'src/app/core/shared/confirmation-modal/confirmation-modal.component';

@Component({
  selector: 'app-user-blogs',
  templateUrl: './user-blogs.component.html',
  styleUrls: ['./user-blogs.component.css']
})
export class UserBlogsComponent implements AfterViewInit, OnInit {
  userId: number = this.userAuthService.getUserId();
  allBlogs: Blog[] = [];

  displayedColumns: string[] = ['position', 'Title', 'Category', 'Action'];
  dataSource = new MatTableDataSource<Blog>(this.allBlogs);

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private snackbarService: SnackbarService, private userBlogService: UserBlogService, private userAuthService: UserAuthService, private dialog: MatDialog) { }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }
  ngOnInit() {
    this.userBlogService.getAllByUserId(this.userId).subscribe({
      next: (response) => {
        this.allBlogs = response.items;
        this.dataSource.data = this.allBlogs;
      }
    })
  }
  deleteBlog(id: number) {
    const dialogRef = this.dialog.open(ConfirmationModalComponent, {
      width: '400px',
      data: {
        title: 'Confirmation',
        message: 'Are you sure you want to delete?',
      }
    })
    dialogRef.afterClosed().subscribe((result: boolean) => {
      if (result) {
        this.userBlogService.delete(id).subscribe({
          next: (response) => {
            this.snackbarService.openSnackBar(response.message)
            this.userBlogService.getAllByUserId(this.userId).subscribe({
              next: (response) => {
                this.dataSource.data = response.items;
                this.allBlogs = response.items;
                this.dataSource.paginator = this.paginator;
              }
            })
          }
        })
      }
    })
  }
}
