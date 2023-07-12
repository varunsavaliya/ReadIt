import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-banner',
  templateUrl: './banner.component.html',
  styleUrls: ['./banner.component.css']
})
export class BannerComponent {
@Input() subHeading?: string;
@Input() heading!: string;
@Input() description!: string;

}
