import { Component, OnInit } from '@angular/core';
import { account } from "../../model/account";
import { client } from "../../model/client";
import { ClientService } from "../../services/client.service";
import { AccountService } from "../../services/account.service";
import { ToastrService } from 'ngx-toastr';
import { HttpErrorResponse } from '@angular/common/http';
import { FormGroup,  FormBuilder,  Validators } from '@angular/forms';

@Component({
  selector: 'app-new-account',
  templateUrl: './new-account.component.html',
  styleUrls: ['./new-account.component.css']
})
export class NewAccountComponent implements OnInit {

  accountForm: FormGroup;
  model: account = new account();
  clients: client[] = [];

  constructor(private serviceClient: ClientService,
              private toastr: ToastrService,
              private serviceAccount: AccountService,
              private _fb: FormBuilder) { 

    this.getAllClients();
    this.createForm();
  }


  getAllClients(){

    this.serviceClient.getClient().subscribe( (resp: client[]) => {

      this.clients= resp;
 
       console.log('Clientes'+ JSON.stringify(this.clients));

       }, (err: HttpErrorResponse) => {
        if(err.status==401)
        this.toastr.info('User Unauthorized!', 'Infotmation!');
        if(err.status==404)
          this.toastr.info('Clients NotFound!', 'Infotmation!');
        if(err.status==500)
          this.toastr.error('Internal Error!', 'Error!');
        console.log(err.status);
       });
}


newAccount()
{
  
  this.model.number=this.accountForm.value.number;
  this.model.valueinit=this.accountForm.value.valueinit;
  this.model.clientid=this.accountForm.value.clientid;

  console.log(this.model);
  this.serviceAccount.newAccountService(this.model).subscribe((res)=>{
    this.model= new account();
    console.log(res)
    this.toastr.success('Account create!', 'Success!');
  }, (err: HttpErrorResponse) => {

      if(err.status==400)
        this.toastr.warning('error sending data!', 'Error!');
      if(err.status==500)
        this.toastr.error('Internal Error!', 'Error!');
    });
    this.accountForm.setValue({number: '', valueinit: '',clientid:''});
}


createForm() {
  this.accountForm = this._fb.group({
    number: ['', Validators.required ],
    valueinit: ['', Validators.required ],    
    clientid: ['', Validators.required ]
  });
}

  ngOnInit() {
  }

}
