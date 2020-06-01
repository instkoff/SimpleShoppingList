import { Component, OnInit } from '@angular/core';
import { ProductsService, Product } from '../services/products.service';

@Component({
  selector: 'app-add-product-form',
  templateUrl: './add-product-form.component.html',
  styleUrls: ['./add-product-form.component.less']
})

export class AddProductFormComponent implements OnInit {
  currentProduct:Product;
  productName:string = "";
  productPrice:number = 0;
  constructor(private _productsService: ProductsService) { }

  ngOnInit() {
    this._productsService.sharedProduct.subscribe(p=>{
      this.currentProduct = p;
      this.productName = p.name;
      this.productPrice = p.price;
    })
  }

  addProduct() {
    if (!this.currentProduct.name.trim()) {
      return;
    }

    const newProduct:Product = {
      name: this.productName,
      price: this.productPrice
    }
    this._productsService.addProduct(newProduct);
  }
  delProduct() {
    this._productsService.deleteProduct(this.currentProduct);
  }
  updateProduct() {
    const updatedProduct:Product = {
      id: this.currentProduct.id,
      name: this.productName,
      createDate: this.currentProduct.createDate,
      price: this.productPrice
    }
    this._productsService.updateSelectedProduct(updatedProduct);
  }


}
