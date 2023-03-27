import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { HttpClient } from '@angular/common/http';
import { Account } from './account';


@Injectable({
  providedIn: 'root'
})
export class AccountHubServiceService {

  constructor(private http:HttpClient) { }

  getAccounts():Observable<any>{
    let url =  "http://localhost:5223/accounts/getall";
    return this.http.get<any>(url); 
    
  }

}
