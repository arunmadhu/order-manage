import { Component } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Orders } from './order.component'

@Component({
  selector: 'order-add',
  templateUrl: './order-add.component.html'
})

export class OrderAddComponent {

  public newOrder: Orders;

  constructor(private http: HttpClient) {
    this.newOrder = new Orders();
  }

  public gotoSaveOrder() {

    this.http.post('http://localhost:57386/api/order/saveorder', this.newOrder).subscribe(
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
