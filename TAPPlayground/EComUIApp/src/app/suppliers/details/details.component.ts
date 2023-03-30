import { Component, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Supplier } from '../supplier';
import { SupplierhubService } from '../supplierhub.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent {
  @Input() supplier:Supplier | undefined;
  supplierId: any;
  sub:any;
  status: boolean | undefined;



  constructor(private svc:SupplierhubService,private router:Router,private route:ActivatedRoute){}

  ngOnInit(): void {
   this.sub=this.route.paramMap.subscribe((params)=>{
    console.log(params);  
    this.supplierId=params.get('id');
  })
  }

  receiveSupplier($event: any) {
    console.log("event catched")
    this.supplier = $event.supplier;
  }
   
  deleteSupplier(supplierId:number) {
    this.svc.delete(this.supplierId).subscribe((response) => {
    //   this.status = response;
    //   this.router.navigate(['/suppliers']);
    //   console.log(response);
    // })
    if(response){
      alert("Supplier deleted Successfully")
      this.router.navigate(['/suppliers']);
     }
     else{
      alert("Error while deleting Product  ")
     }
    })
  }

  onSelectUpdate(supplierId:any){
    this.router.navigate(['/suppliers-update',supplierId]);
   }
 
}
