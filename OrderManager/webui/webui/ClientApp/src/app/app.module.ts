import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { OrderComponent } from './order/order.component';
import { OrderEditComponent } from './order/order-edit.component';
import { AddressComponent } from './address/address.component';
import { OrderAddComponent } from './order/order-add.component';
import { AddressAddComponent } from './address/address-add.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    OrderComponent,
    OrderEditComponent,
    AddressComponent,
    OrderAddComponent,
    AddressAddComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'order-data', component: OrderComponent },
      { path: 'order-edit/:orderid', component: OrderEditComponent },
      { path: 'address-data', component: AddressComponent },
      { path: 'add-order', component: OrderAddComponent },
      { path: 'add-address', component: AddressAddComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
