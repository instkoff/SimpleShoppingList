import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AddProductFormComponent } from './add-product-form/add-product-form.component';

@NgModule({
  declarations: [
    AppComponent,
    AddProductFormComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
