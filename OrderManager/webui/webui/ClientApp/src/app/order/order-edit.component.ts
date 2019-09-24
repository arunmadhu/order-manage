import { Component, Inject,Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { Orders, OrderAddress } from './order.component';

@Component({
  selector: 'order-edit',
  templateUrl: './order-edit.component.html'
})

export class OrderEditComponent {

  id: number;
  private selOrder: Orders;
  private allAddress: OrderAddress[];
  public flashMessage: string;

  constructor(private http: HttpClient, private route: ActivatedRoute, @Inject('BASE_URL') baseUrl: string) {

    this.flashMessage = "";

    this.route.params.subscribe(params => {
      this.id = +params['orderid'];
    });

    http.get<Orders>('http://localhost:57386/api/order/getorder/' + this.id).subscribe(result => {
      this.selOrder = result;
    }, error => console.error(error));

    http.get<OrderAddress[]>('http://localhost:57386/api/order/getaddressbyorder/' + this.id).subscribe(result => {
      this.allAddress = result;
    }, error => console.error(error));
  }

  public saveChange() {

    let checkedAddress = this.allAddress.reduce((acc, eachgroup) => {
      if (eachgroup.inOrder) {
        acc.push(eachgroup.addressId);
      }
      return acc;
    }, []).join(",");

    var model: OrderAddModel = {
      addressIds : checkedAddress.split(","),
      orderId : this.id
    };

    this.flashMessage = "Updating order.....";

    this.http.post('http://localhost:57386/api/order/saveorderaddress', model).subscribe(
      result => {
      },
      error => {
        this.flashMessage = "We were not able to handle your request. Please try later.";
      },
      () => {
        this.flashMessage = "Data updated successfully...";
      }
    );
  }
}

interface OrderAddModel {
  orderId: number;
  addressIds: string[];
}


