import { Component, OnInit } from '@angular/core';
import { AccountService } from "../../services/account.service";
import { ToastrService } from 'ngx-toastr';
import { accountmove } from "../../model/accountmove";
import { typemove } from "../../model/typemove";
import { HttpErrorResponse } from '@angular/common/http';
import { FormGroup,  FormBuilder,  Validators } from '@angular/forms';
import { response } from 'src/app/model/response';

@Component({
  selector: 'app-new-move-consign',
  templateUrl: './new-move-consign.component.html',
  styleUrls: ['./new-move-consign.component.css']
})
export class NewMoveConsignComponent implements OnInit {

  loading:boolean;
  moveconsignForm: FormGroup;
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
  this.model.number=this.moveconsignForm.value.number;
  this.model.value=this.moveconsignForm.value.value;
  this.model.typemove=this._typemove.consign

  this.serviceAccount.newMoveService(this.model).subscribe((res:response)=>{
    this.loading=false;
    this.model=new accountmove();

    this.toastr.success(res.message, 'Success!');
  }, (err: HttpErrorResponse) => {
    this.loading=false;
    if(err.status==400)
        this.toastr.warning(err.error, 'Error!');
    if(err.status==500)
      this.toastr.error('Internal Error!', 'Error!');
    if(err.status==0 && err.ok===false)
      this.toastr.warning('Impossible to connect to the server!', 'Waringi!');
  });
  this.moveconsignForm.setValue({number: '', value: ''});
}

createForm() {
  this.moveconsignForm = this._fb.group({
    number: ['', Validators.required ],
    value: ['', Validators.required ]
  });
}

  ngOnInit() {
  }

}
