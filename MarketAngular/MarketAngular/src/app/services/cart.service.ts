import { Injectable } from '@angular/core';
import { Airplane } from '../models/airplane';
import { CartItem } from '../models/cartItem';
import { CartItems } from '../models/cartItems';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor() { }

  addToCart(airplane:Airplane){
    let item = CartItems.find(a=>a.airplane.airplaneId===airplane.airplaneId);
    if(item){
        item.quantity += 1;
    }else{
      let cartItem = new CartItem();
      cartItem.airplane = airplane;
      cartItem.quantity = 1;
      CartItems.push(cartItem)
    }
  }

  list():CartItem[]{

    return CartItems;
  }

  removeFromCart(airplane:Airplane){
    let item:CartItem = CartItems.find(a=>a.airplane.airplaneId===airplane.airplaneId);
    CartItems.splice(CartItems.indexOf(item),1)


  }

}
