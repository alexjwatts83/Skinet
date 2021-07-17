import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/shared';
import { BreadcrumbService } from 'xng-breadcrumb';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss'],
})
export class ProductDetailsComponent implements OnInit {
  product!: IProduct;

  constructor(
    private shopService: ShopService,
    private activatedRoute: ActivatedRoute,
    private bsService: BreadcrumbService
  ) {}

  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct() {
    this.activatedRoute.params.subscribe((params) => {
      console.log({params: params});
      let id = +params.id;
      // let id = +(this.activatedRoute.snapshot.paramMap.get('id') || 0);
      this.shopService.getProduct(id).subscribe(
        (product) => {
          this.product = product;
          this.bsService.set('@productDetails', product.name);
        },
        (error) => {
          console.log(error);
        }
      );
    });
  }
}
