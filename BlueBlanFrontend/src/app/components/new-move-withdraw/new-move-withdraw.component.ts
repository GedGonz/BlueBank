import { Component, OnInit } from '@angular/core';
import { AccountService } from "../../services/account.service";
import { ToastrService } from 'ngx-toastr';
import { accountmove } from "../../model/accountmove";
import { typemove } from "../../model/typemove";
import { HttpErrorResponse } from '@angular/common/http';
import { FormGroup,  FormBuilder,  Validators } from '@angular/forms';
import { response } from 'src/app/model/response';

@Component({
  selector: 'app-new-move-withdraw',
  templateUrl: './new-move-withdraw.component.html',
  styleUrls: ['./new-move-withdraw.component.css']
})
export class NewMoveWithdrawComponent implements OnInit {

  loading:boolean;
  movewithdrawForm: FormGroup;
  model: accountmove = new accountmove();
  _typemove:typemove = new  typemove();

  constructor(private toastr: ToastrService,
    private serviceAccount: AccountService,
    private _fb: FormBuilder) { 
      this.createForm();
    }

    
newMoveConsign()
{
  this.loading=true;
  this.model.number=this.movewithdrawForm.value.number;
  this.model.value=this.movewithdrawForm.value.value;
  this.model.typemove=this._typemove.withdraw

  this.serviceAccount.newMoveService(this.model).subscribe((res: response)=>{
    this.loading=false;
    this.model=new accountmove();
    
    this.toastr.success(res.message, 'Success!');
  }, (err: HttpErrorResponse) => {
    this.loading=false;
    if(err.status==400)
      this.toastr.warning(err.error, 'Error!');
    if(err.status==505)
      this.toastr.error('Interal Error!', 'Error!');
    if(err.status==0 && err.ok===false)
      this.toastr.warning('Impossible to connect to the server!', 'Waringi!');
  });

}

createForm() {
  this.movewithdrawForm = this._fb.group({
    number: ['', Validators.required ],
    value: ['', Validators.required ]
  });
}


  ngOnInit() {
  }

}
