import { Component, OnInit } from '@angular/core';
import { AccountService } from "../../services/account.service";
import { ToastrService } from 'ngx-toastr';
import { accountmove } from "../../model/accountmove";
import { typemove } from "../../model/typemove";
import { HttpErrorResponse } from '@angular/common/http';
@Component({
  selector: 'app-new-move-consign',
  templateUrl: './new-move-consign.component.html',
  styleUrls: ['./new-move-consign.component.css']
})
export class NewMoveConsignComponent implements OnInit {

  
  model: accountmove = new accountmove();
  _typemove:typemove = new  typemove();

  constructor(private toastr: ToastrService,
    private serviceAccount: AccountService) { }

    
newMoveConsign()
{
  console.log(this.model);

  this.model.typemove=this._typemove.consign

  this.serviceAccount.newMoveService(this.model).subscribe((res)=>{
    
    this.model=new accountmove();
    
    console.log(res)

    this.toastr.success('Moving created!', 'Success!');
  }, (err: HttpErrorResponse) => {

    if(err.status==505)
      this.toastr.info('Interal Error!', 'Error!');
    console.log(err.status);
  });

}


  ngOnInit() {
  }

}
