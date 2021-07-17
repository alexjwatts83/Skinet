import { Component, OnInit } from '@angular/core';
import { IProduct } from '../shared';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  products!: IProduct[];
  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts();
  }
  getProducts() {
    this.shopService.getProducts().subscribe(response => {
      this.products = response.data;
      // this.shopParams.pageNumber = response.pageIndex;
      // this.shopParams.pageSize = response.pageSize;
      // this.totalCount = response.count;
    }, error => {
      console.log(error);
    })
  }
}
