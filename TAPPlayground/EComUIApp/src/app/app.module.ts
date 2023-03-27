import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { Account } from './account/account';
import { AccountModule } from './account/account.module';
import { RouterModule, Routes } from '@angular/router';
import { MembershipModule } from './membership/membership.module';
<<<<<<< HEAD
import {AppComponent} from './app.component';
=======
import { SuppliersModule } from './suppliers/suppliers.module';
>>>>>>> f8c513a02366b87a8cf8ebe2bac2909b2b361984

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
    AccountModule, 
    MembershipModule,
    SuppliersModule,
    RouterModule.forRoot(routes)

  ],
  providers: [],
  bootstrap: [AppComponent] //Root Component
})
export class AppModule { } //Root Module

//What do you mean by Angular Module ?
//it is like namespace  or package
//it consist of
//Basic building blocks:
// components, services, directives, pipes, decorators
// interface,classes
