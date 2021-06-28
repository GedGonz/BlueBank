import { Component, OnInit } from '@angular/core';
import { account } from "../../../model/account";
import { AccountService } from "../../../services/account.service";
import { ClientService } from "../../../services/client.service";
import { HttpErrorResponse } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { typemove } from "../../../model/typemove";
import { client } from 'src/app/model/client';
@Component({
  selector: 'app-consult-account',
  templateUrl: './consult-account.component.html',
  styleUrls: ['./consult-account.component.css']
})
export class ConsultAccountComponent implements OnInit {

  loading:boolean
  _typemove: typemove = new typemove();
  model: account = new account();
  modeclient:client =new  client();
  TotalComisgn:number;
  TotalWithDraw:number;
  
  constructor(private serviceAccount: AccountService,private serviceClient: ClientService,
    private toastr: ToastrService) {
    
   }


  getFindAccount(){
    this.loading=true;
    this.TotalComisgn=0.00;
    this.TotalWithDraw=0.00;

    this.serviceAccount.getAccount(this.model.number).subscribe( (resp: account) => {
      
      this.loading=false;
      this.model=resp;
      this.loadDataMove();
      
      this.serviceClient.findClient(this.model.clientid).subscribe((resp:client)=>{
        this.modeclient=resp;
      });

       }, (err: HttpErrorResponse) => {
        this.loading=false;
         if(err.status==404)
           this.toastr.warning('Account NotFound!', 'Infotmation!');
         if(err.status==505)
           this.toastr.error('Interal Error!', 'Error!');
       });
}

loadDataMove(){
  this.model.accountmoves.reduce((moves,val, index)=>{
    this.TotalComisgn += (val.typemove==this._typemove.consign)? Number(val.value):0;
    return null;
  },0);

  this.model.accountmoves.reduce((moves,val, index)=>{
    this.TotalWithDraw  += (val.typemove==this._typemove.withdraw)? Number(val.value):0;
    return null;
  },0);
}

  ngOnInit() {
      
  }

}
