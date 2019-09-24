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

  constructor(private http: HttpClient, private route: ActivatedRoute, @Inject('BASE_URL') baseUrl: string) {

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

    this.http.post('http://localhost:57386/api/order/saveorderaddress', model).subscribe(
      result => {
      },
      error => {
        //this.loading = false;
        //this.flashMessage.show('We were not able to handle your request. Please try later.', { cssClass: 'alert-danger', timeout: 5000 });
      },
      () => {
        //this.loading = false;
        //this.flashMessage.show('Data updated successfully...', { cssClass: 'alert-success', timeout: 5000 });
      }
    );
  }
}

interface OrderAddModel {
  orderId: number;
  addressIds: string[];
}


