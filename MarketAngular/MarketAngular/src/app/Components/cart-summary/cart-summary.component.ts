import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Airplane } from 'src/app/models/airplane';
import { CartItem } from 'src/app/models/cartItem';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-cart-summary',
  templateUrl: './cart-summary.component.html',
  styleUrls: ['./cart-summary.component.css']
})
export class CartSummaryComponent implements OnInit {

  cartItems: CartItem[];

  constructor(private cartServive: CartService,private toasterServive:ToastrService) { }

  ngOnInit(): void {
    this.getCart();
  }

  getCart() {
    this.cartItems = this.cartServive.list();
  }

  removeFromCart(airplane:Airplane){
    this.cartServive.removeFromCart(airplane);
    this.toasterServive.error("Silindi",airplane.airplaneName+" sepetten çıkarıldı")
  }

}
