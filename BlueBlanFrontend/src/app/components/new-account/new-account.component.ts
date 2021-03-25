import { Component, OnInit } from '@angular/core';
import { account } from "../../model/account";
import { client } from "../../model/client";
import { ClientService } from "../../services/client.service";
import { AccountService } from "../../services/account.service";
import { ToastrService } from 'ngx-toastr';
import { HttpErrorResponse } from '@angular/common/http';
@Component({
  selector: 'app-new-account',
  templateUrl: './new-account.component.html',
  styleUrls: ['./new-account.component.css']
})
export class NewAccountComponent implements OnInit {

  
  model: account = new account();
  clients: client[] = [];

  constructor(private serviceClient: ClientService,
              private toastr: ToastrService,
              private serviceAccount: AccountService) { 

    this.getAllClients();
  }


  getAllClients(){

    this.serviceClient.getClient().subscribe( (resp: client[]) => {

      this.clients= resp;
 
       console.log('Clientes'+ JSON.stringify(this.clients));

       }, (err: HttpErrorResponse) => {
         console.log(err);
       });
}


newAccount()
{
  console.log(this.model);
  this.serviceAccount.newAccountService(this.model).subscribe((res)=>{
    this.model= new account();
    console.log(res)
    this.toastr.success('Account create!', 'Success!');
  })
}

  ngOnInit() {
  }

}
