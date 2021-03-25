import { Component, OnInit } from '@angular/core';
import { account } from "../../model/account";
import { AccountService } from "../../services/account.service";

import { HttpErrorResponse } from '@angular/common/http';
@Component({
  selector: 'app-consult-account',
  templateUrl: './consult-account.component.html',
  styleUrls: ['./consult-account.component.css']
})
export class ConsultAccountComponent implements OnInit {

  
  model: account = new account();
  courrent:string;
  constructor(private serviceAccount: AccountService) {
    
   }


  getFindAccount(){
console.log(this.model.Number);
    this.serviceAccount.getAccount('3b7ec7d0-cdb4-49d5-6d1d-08d8eee5290c',this.model.Number).subscribe( (resp: account) => {
    
      this.model=resp;

      console.log(this.model);
       }, (err: HttpErrorResponse) => {
         console.log(err);
       });
}

  ngOnInit() {
      
  }

}
