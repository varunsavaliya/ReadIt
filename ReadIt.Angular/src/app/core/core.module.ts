import { NgModule } from '@angular/core';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatTabsModule } from '@angular/material/tabs';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSelectModule } from '@angular/material/select';
import { MatCardContent, MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';


// import { ToastrModule } from 'ngx-toastr';
// import { ConfirmModalComponent } from './components/confirm-modal/confirm-modal.component';
import {MatDialogModule} from '@angular/material/dialog';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule} from '@angular/material/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { HeaderComponent } from './shared/header/header.component';
import { ConfirmationModalComponent } from './shared/confirmation-modal/confirmation-modal.component';
import { PaginationComponent } from './shared/pagination/pagination.component';
import { FooterComponent } from './shared/footer/footer.component';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { BannerComponent } from './shared/banner/banner.component';

@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    ConfirmationModalComponent,
    PaginationComponent,
    BannerComponent
  ],
  imports: [
    RouterModule,
    CommonModule,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatListModule,
    MatTabsModule,
    MatButtonModule,
    MatMenuModule,
    MatTableModule,
    MatFormFieldModule,
    MatInputModule,
    MatPaginatorModule,
    MatSelectModule,
    MatDialogModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatCardModule,
    MatGridListModule,
    MatSnackBarModule,
    FlexLayoutModule,
    MatSelectModule,
    CKEditorModule,
    
    // ToastrModule.forRoot({
    //   closeButton: true,
    //   timeOut: 1500, // 15 seconds
    //   progressBar: true,
    // }),
  ],
  exports: [
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatListModule,
    MatTabsModule,
    MatButtonModule,
    MatMenuModule,
    MatTableModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatCardModule,
    MatCardContent,
    MatGridListModule,
    MatSnackBarModule,
    FlexLayoutModule,
    MatSelectModule,
    CKEditorModule,
    // ToastrModule

    HeaderComponent,
    FooterComponent,
    ConfirmationModalComponent,
    PaginationComponent,
    BannerComponent
  ]
})
export class CoreModule { }
