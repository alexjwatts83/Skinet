import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PagerComponent } from './components/pager/pager.component';
import { PagerHeaderComponent } from './components/pager-header/pager-header.component';

@NgModule({
  declarations: [
    PagerComponent,
    PagerHeaderComponent
  ],
  imports: [
    CommonModule,
    PaginationModule.forRoot()
  ],
  exports: [
    PaginationModule,
    PagerHeaderComponent,
    PagerComponent
  ]
})
export class SharedModule { }
