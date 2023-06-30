import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { UserBlogService } from 'src/app/core/apiservices/user-blog.service';
import { Blog } from 'src/app/core/models/blog';
import { UserAuthService } from 'src/app/core/services/user-auth.service';

@Component({
  selector: 'app-user-blogs',
  templateUrl: './user-blogs.component.html',
  styleUrls: ['./user-blogs.component.css']
})
export class UserBlogsComponent {
  userId: number = this.userAuthService.getUserId();
  allBlogs: Blog[] = [];

  displayedColumns: string[] = ['position', 'Title', 'Description', 'Category','Action'];
  dataSource = new MatTableDataSource<Blog>(this.allBlogs);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

constructor(private userBlogService: UserBlogService, private userAuthService: UserAuthService){}
ngOnInit(){
  this.userBlogService.getAllByUserId(this.userId).subscribe({
    next : (response) => {
      this.allBlogs = response.items;
      this.dataSource.data = response.items;
    }
  })
}
deleteBlog(id: number) {
  this.userBlogService.delete(id).subscribe({
    next: (response) => {
      this.userBlogService.getAllByUserId(this.userId).subscribe({
        next : (response) => {
          this.dataSource.data = response.items;
        }
      })
    }
  })
}
}
