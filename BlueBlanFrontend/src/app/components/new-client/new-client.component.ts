import { Component, OnInit } from '@angular/core';
import { client } from "../../model/client";
import { ClientService } from "../../services/client.service";
import { ToastrService } from 'ngx-toastr';
import { HttpErrorResponse } from '@angular/common/http';
import { FormGroup,  FormBuilder,  Validators } from '@angular/forms';

@Component({
  selector: 'app-new-client',
  templateUrl: './new-client.component.html',
  styleUrls: ['./new-client.component.css']
})
export class NewClientComponent implements OnInit {

  clientForm: FormGroup;
  model: client = new client();


  constructor(private service: ClientService,private toastr: ToastrService,
    private _fb: FormBuilder) 
    {
      this.createForm();
    }



  newClient()
  {
    this.model.name=this.clientForm.value.name;
    this.model.lastname=this.clientForm.value.lastname;
    console.log(this.model);
    this.service.newClientService(this.model).subscribe((res)=>{
      this.model= new client();
      console.log(res)
      this.toastr.success('Client create!', 'Success!');
    }, (err: HttpErrorResponse) => {

      if(err.status==400)
        this.toastr.warning('error sending data!', 'Error!');
      if(err.status==500)
        this.toastr.error('Internal Error!', 'Error!');
    });
    this.clientForm.setValue({name: '', lastname: ''});
  }


  createForm() {
    this.clientForm = this._fb.group({
       name: ['', Validators.required ],
       lastname: ['', Validators.required ]
    });
  }

  ngOnInit() {
  }

}
