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
constructor(private authorService: AuthorService){}

ngOnInit(){
  this.authorService.getAll().subscribe({
    next: (response) => {
      if(response.success){
        this.authors = response.items;
      }
    }
  })
}
}
