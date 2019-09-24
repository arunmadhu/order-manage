import { Component } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Orders } from './order.component'

@Component({
  selector: 'order-add',
  templateUrl: './order-add.component.html'
})

export class OrderAddComponent {

  public newOrder: Orders;
  public flashMessage: string;

  constructor(private http: HttpClient) {
    this.newOrder = new Orders();
    this.flashMessage = "";
  }

  public gotoSaveOrder() {

    this.flashMessage = "Saving new order.....";

    this.http.post('http://localhost:57386/api/order/saveorder', this.newOrder).subscribe(
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
