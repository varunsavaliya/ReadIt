import { Component, Input } from '@angular/core';
import { UserModel } from 'src/app/core/models/user.model';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css']
})
export class AuthorComponent {
  @Input() author: UserModel = {} as UserModel;
  getBio(): string {
    if ( this.author.bio && this.author.bio!.length > 70) {
      return this.author.bio!.slice(0, 70) + '...';
    } else {
      return this.author.bio!;
    }
  }
}
