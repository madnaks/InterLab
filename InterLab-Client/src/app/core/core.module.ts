import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { WaiterComponent } from './components/waiter/waiter.component';

@NgModule({
  imports: [
    CommonModule,
    SharedModule
  ],
  declarations: [
    WaiterComponent
  ],
  exports: [
    WaiterComponent
  ]
})
export class CoreModule { }
