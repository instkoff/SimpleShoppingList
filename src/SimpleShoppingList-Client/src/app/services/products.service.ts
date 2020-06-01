import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';

export interface Product {
  id?:string,
  name:string,
  createDate?:string,
  price: number
}

@Injectable({providedIn: 'root'})
export class ProductsService {
  url:string = "http://localhost:5000/api/Product";

  private productList:Product[] = [];
  private concreteProduct:Product = {
    name:"",
    price:0
  };

  sharedProduct = new BehaviorSubject<Product>(this.concreteProduct);
  sharedProductList = new BehaviorSubject<Product[]>(this.productList);

  constructor(private _httpClient: HttpClient) {}

  addProduct(product:Product) {
    this._httpClient.post<Product>(this.url, product)
    .subscribe(p=> {
      this.productList.push(p);
      this.sharedProductList.next(this.productList);
    })
  }

  getAllProducts() {
    this._httpClient.get<Product[]>(this.url+"/get-all-products")
    .subscribe(p => {
      this.productList = p;
      this.sharedProductList.next(this.productList);
    });
  }

  getConcreteProduct(selectedProduct:Product) {
    this.concreteProduct = selectedProduct;
    this.sharedProduct.next(this.concreteProduct);
  }

  deleteProduct(selectedProduct:Product) {
    this._httpClient.delete(this.url+"?id="+selectedProduct.id)
    .subscribe(()=> {
      this.productList = this.productList.filter(p=>p.id !== selectedProduct.id);
      this.sharedProductList.next(this.productList);
    })
  }
  updateSelectedProduct(selectedProduct:Product) {
    this._httpClient.put(this.url, selectedProduct).subscribe(id=>{
      let index = this.productList.findIndex(p=>p.id === id);
      this.productList[index] = selectedProduct;
      this.sharedProductList.next(this.productList);
    })
  }

}
