import { Component, OnInit,Input } from '@angular/core';
import { account } from "../../model/account";
@Component({
  selector: 'app-move-account',
  templateUrl: './move-account.component.html',
  styleUrls: ['./move-account.component.css']
})
export class MoveAccountComponent implements OnInit {


  @Input()
  accounts: account;

  constructor() {
    console.log('valor accounts: ',this.accounts);
   }

  ngOnInit() {
    console.log('valor accounts: ',this.accounts);
    this.accounts=new account();
  }

}
