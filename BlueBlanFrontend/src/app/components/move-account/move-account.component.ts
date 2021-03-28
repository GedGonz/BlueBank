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
   }

  ngOnInit() {
    this.accounts=new account();
  }

}
