import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from '../product';
import { ProductHubService } from '../producthub.service';

@Component({
  selector: 'insert',
  templateUrl: './insert.component.html',
  styleUrls: ['./insert.component.css']
})
export class InsertComponent {
  product: Product = {
    productId:0,
    productTitle: '',
    description: '',
    stockAvailable: 0,
    unitPrice: 0,
    imageUrl: '',
    categoryId: 0,
    supplierId: 0
  };
  status: boolean | undefined;
  

  constructor(private svc: ProductHubService,private router:Router) { }

 
  insertProduct() {
    console.log(this.product)
    this.svc.insertProduct(this.product).subscribe((response) => {
      this.status = response;
      console.log(response);
      if(response)
      {
        window.location.reload();
        alert("record Inserted successfully")
      }
      else{
        alert("Error while Inserting record")
      }
    })
  }
}
