
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HRModuleModule } from './hrmodule/hrmodule.module';
import { HttpClientModule} from '@angular/common/http';
import { TransactionModule } from './transaction/transaction.module';
import { AccountModule } from './account/account.module';
import { RouterModule, Routes } from '@angular/router';
import { MembershipModule } from './membership/membership.module';
import { SuppliersModule } from './suppliers/suppliers.module';
import { CustomerModule } from './customer/customer.module';
import { PaymentModule } from './payment/payment.module';
import { ProductsModule } from './product/products.module';
import { ShipperModule } from './shipper/shipper.module';
import { AppComponent } from './app.component';
import { DatePipe } from '@angular/common';
import { Employee } from './hrmodule/Employee';
import { OrderModule } from './order/order.module';


//metadata
//decorator

const routes: Routes = [

]
@NgModule({
  declarations: [
  AppComponent

  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    DatePipe,
    AccountModule, 
    MembershipModule,
    ShipperModule,
    SuppliersModule,
    OrderModule,
    CustomerModule,
    RouterModule.forRoot(routes),
    DatePipe,
    TransactionModule,
    ProductsModule,
    HRModuleModule,
    PaymentModule,
<<<<<<< HEAD
    OrderModule
=======
>>>>>>> 6b7d552baab0249cb53018057cc9aab557fa1444

  
  ],
  providers: [DatePipe],

  bootstrap: [AppComponent] //Root Component
})
export class AppModule { } //Root Module

//What do you mean by Angular Module ?
//it is like namespace  or package
//it consist of
//Basic building blocks:
// components, services, directives, pipes, decorators
// interface,classes
