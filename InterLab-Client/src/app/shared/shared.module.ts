import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';

import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatChipsModule } from '@angular/material/chips';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatMenuModule } from '@angular/material/menu';

const AngularMaterialModules = [
  MatCardModule,
  MatGridListModule,
  MatToolbarModule,
  MatIconModule,
  MatChipsModule,
  MatProgressSpinnerModule,
  MatButtonModule,
  MatSnackBarModule,
  MatSelectModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatInputModule,
  MatTableModule,
  MatMenuModule
];

@NgModule({
  declarations: [],
  imports: [CommonModule, AngularMaterialModules],
  exports: [AngularMaterialModules],
  providers: [MatDatepickerModule, DatePipe],
})
export class SharedModule {}
