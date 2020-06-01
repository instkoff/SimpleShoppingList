import { Component, OnInit } from '@angular/core';
import { Product, ProductsService } from '../services/products.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.less']
})

export class ProductListComponent implements OnInit {
  productList:Product[] = [];

  constructor(private _productService: ProductsService) { }

  ngOnInit(): void {
    this._productService.sharedProductList.subscribe((p: Product[])=> {
      this.productList = p;
    })
    this._productService.getAllProducts();
  }

  onSelect(selectedProduct: any){
    this._productService.getConcreteProduct(selectedProduct);
  }

}
