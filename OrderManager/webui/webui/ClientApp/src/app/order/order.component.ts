import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from "@angular/router";

@Component({
  selector: 'app-order-data',
  templateUrl: './order.component.html'
})
export class OrderComponent {
  public availableOrders: Orders[];
  public orderId: number;

  constructor(http: HttpClient, private router: Router) {
    http.get<Orders[]>('http://localhost:57386/api/order/getallorders').subscribe(result => {
      this.availableOrders = result;
      console.log(this.availableOrders);
    }, error => console.error(error));
  }

  public gotoOrderDetails(id) {
    var url = `/order-edit/${id}`;
    this.orderId = id;
    this.router.navigateByUrl(url).then((e) => {
    });
  }

  public gotoAddOrder() {
    this.router.navigateByUrl(`/add-order`).then((e) => {
    });
  }
}

export class Orders {
  orderId: number;
  orderNumber: string;
  customerName: string;
  totalPrice: number;

  address: OrderAddress[];
}

export interface OrderAddress {
  addressId: number;
  addressLine1: string;
  addressLine2: string;
  state: string;
  pincode: string;
  inOrder: boolean;
}
