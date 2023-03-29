import { Component } from '@angular/core';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent {

  employee:any;
  receiveEmployee($event:any){
    this.employee=$event.employee;
  }
  
}
