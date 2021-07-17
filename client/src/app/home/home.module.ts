import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './';
import { SharedModule } from '../shared';



@NgModule({
  declarations: [
    HomeComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
  ],
  exports: [
    HomeComponent,
  ]
})
export class HomeModule { }
