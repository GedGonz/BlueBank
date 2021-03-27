import { Component, OnInit } from '@angular/core';
import { AccountService } from "../../services/account.service";
import { ToastrService } from 'ngx-toastr';
import { accountmove } from "../../model/accountmove";
import { typemove } from "../../model/typemove";
import { HttpErrorResponse } from '@angular/common/http';
import { FormGroup,  FormBuilder,  Validators } from '@angular/forms';

@Component({
  selector: 'app-new-move-withdraw',
  templateUrl: './new-move-withdraw.component.html',
  styleUrls: ['./new-move-withdraw.component.css']
})
export class NewMoveWithdrawComponent implements OnInit {


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

  this.model.number=this.movewithdrawForm.value.number;
  this.model.value=this.movewithdrawForm.value.value;
  this.model.typemove=this._typemove.withdraw
  console.log(this.model);
  this.serviceAccount.newMoveService(this.model).subscribe((res)=>{
    
    this.model=new accountmove();
    
    console.log(res)

    this.toastr.success('Moving created!', 'Success!');
  }, (err: HttpErrorResponse) => {
    if(err.status==400)
      this.toastr.warning(err.error, 'Error!');
    if(err.status==505)
      this.toastr.info('Interal Error!', 'Error!');
    console.log(err.status);
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
