import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PagerComponent } from './components/pager/pager.component';
import { PagerHeaderComponent } from './components/pager-header/pager-header.component';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { OrderTotalsComponent } from './components/order-totals/order-totals.component';

@NgModule({
  declarations: [
    PagerComponent,
    PagerHeaderComponent,
    OrderTotalsComponent,
  ],
  imports: [
    CommonModule,
    PaginationModule.forRoot(),
    CarouselModule.forRoot(),
  ],
  exports: [
    PaginationModule,
    PagerHeaderComponent,
    PagerComponent,
    CarouselModule,
    OrderTotalsComponent,
  ]
})
export class SharedModule { }
