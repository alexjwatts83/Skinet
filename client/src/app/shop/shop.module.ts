import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared';
import {
  ShopComponent,
  ProductDetailsComponent,
  ProductItemComponent,
} from '.';
import { ShopRoutingModule } from './shop-routing.module';

@NgModule({
  declarations: [ShopComponent, ProductItemComponent, ProductDetailsComponent],
  imports: [CommonModule, SharedModule, ShopRoutingModule],
  exports: [ShopComponent, ProductDetailsComponent],
})
export class ShopModule {}
