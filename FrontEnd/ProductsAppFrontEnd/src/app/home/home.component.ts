import { Component, OnInit } from '@angular/core';
import { Product } from '../_models/product';
import { ProductService } from '../_services/product.service';
import { AuthenticationService } from '../_services/authentication.service';

@Component({
    templateUrl: 'home.component.html'
})

export class HomeComponent implements OnInit {
    products: Product[] = [];
    username: string;
    errormessage: string = '';

    constructor(private productService: ProductService, private authService: AuthenticationService) {
      this.username = authService.getUsername();
    }

    ngOnInit() {
        // get users from secure api end point
        this.productService.getProducts()
            .subscribe(
              products => {
                this.products = products;
              },
              error => {
                this.errormessage = error.message;
              });
    }

}
