import { Component } from '@angular/core';
import { AuthorService } from 'src/app/core/apiservices/author.service';
import { UserModel } from 'src/app/core/models/user.model';

@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css']
})
export class AuthorsComponent {
  authors: UserModel[] = [];
  totalAuthors: number = 0;
  authorsPerPage: number = 3;
  currentPage: number = 1;
  constructor(private authorService: AuthorService) { }

  ngOnInit() {
    this.getAuthors();
  }
  getAuthors() {
    this.authorService.getAuthors(this.authorsPerPage, this.currentPage).subscribe({
      next: (response) => {
        if (response.success) {
          this.totalAuthors = response.totalItems
          this.authors = response.items;
        }
      }
    })
  }
  onPageChange(page: number) {
    this.currentPage = page;
    this.getAuthors();
  }
}
