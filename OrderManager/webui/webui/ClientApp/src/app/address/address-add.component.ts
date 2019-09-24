import { Component } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Address } from './address.component'

@Component({
  selector: 'address-add',
  templateUrl: './address-add.component.html'
})

export class AddressAddComponent {

  public newaddress: Address;
  public flashMessage: string;

  constructor(private http: HttpClient) {
    this.newaddress = new Address();
    this.flashMessage = "";
  }

  public gotoSaveAddress() {

    this.flashMessage = "Saving new address.....";

    this.http.post('http://localhost:57386/api/order/saveaddress', this.newaddress).subscribe(
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
