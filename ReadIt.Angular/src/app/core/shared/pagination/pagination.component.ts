import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css']
})
export class PaginationComponent {
  @Input() totalRecords!: number
  @Input() recordsPerPage!: number
  @Input() currentPage!: number
  @Output() pageChange: EventEmitter<number> = new EventEmitter<number>();
  totalPages: number = 0;
  pagesArray: number[] = [];
  ngOnInit() {
    this.totalPages = Math.ceil(this.totalRecords / this.recordsPerPage);
    this.pagesArray = Array.from({ length: this.totalPages }, (_, index) => index + 1);
  }
  onPageClick(page: number) {
    this.pageChange.emit(page);
  }
}
