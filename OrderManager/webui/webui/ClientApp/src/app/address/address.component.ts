import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from "@angular/router";

@Component({
  selector: 'app-address-data',
  templateUrl: './address.component.html'
})

export class AddressComponent {

  private availableAddress: Address[];

  constructor(http: HttpClient, private router: Router) {
    http.get<Address[]>('http://localhost:57386/api/order/getalladdress').subscribe(result => {
      this.availableAddress = result;
    }, error => console.error(error));
  }

  public gotoAddAddress() {
    this.router.navigateByUrl(`/add-address`).then((e) => {
    });
  }
}

export class Address {
  addressId: number;
  addressLine1: string;
  addressLine2: string;
  state: string;
  pincode: number;
}
