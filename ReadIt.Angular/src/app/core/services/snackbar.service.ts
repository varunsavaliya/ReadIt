import { Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class SnackbarService {

  private defaultDuration = 2000;
  private defaultPosition: MatSnackBarConfig['verticalPosition'] = 'bottom';
  private defaultHorizontalPosition: MatSnackBarConfig['horizontalPosition'] = 'center';


  constructor(private snackBar: MatSnackBar) { }

  openSnackBar(message: string) {
    const mergedConfig: MatSnackBarConfig = {
      duration: this.defaultDuration,
      verticalPosition: this.defaultPosition,
      horizontalPosition: this.defaultHorizontalPosition,
      // panelClass: ['success-snackbar']
    };
    this.snackBar.open(message, 'Close', mergedConfig);
  }
}
