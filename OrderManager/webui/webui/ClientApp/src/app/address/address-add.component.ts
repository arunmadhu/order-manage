import { Component } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Address } from './address.component'

@Component({
  selector: 'address-add',
  templateUrl: './address-add.component.html'
})

export class AddressAddComponent {

  public newaddress: Address;

  constructor(private http: HttpClient) {
    this.newaddress = new Address();
  }

  public gotoSaveAddress() {

    console.log("this.newAddress" + this.newaddress);

    this.http.post('http://localhost:57386/api/order/saveaddress', this.newaddress).subscribe(
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
