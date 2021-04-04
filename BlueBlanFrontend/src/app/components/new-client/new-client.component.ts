import { Component, OnInit } from '@angular/core';
import { client } from "../../model/client";
import { ClientService } from "../../services/client.service";
import { ToastrService } from 'ngx-toastr';
import { HttpErrorResponse } from '@angular/common/http';
import { FormGroup,  FormBuilder,  Validators } from '@angular/forms';
import { response } from 'src/app/model/response';

@Component({
  selector: 'app-new-client',
  templateUrl: './new-client.component.html',
  styleUrls: ['./new-client.component.css']
})
export class NewClientComponent implements OnInit {

  loading:boolean;
  clientForm: FormGroup;
  model: client = new client();


  constructor(private service: ClientService,private toastr: ToastrService,
    private _fb: FormBuilder) 
    {
      this.createForm();
    }



  newClient()
  {
    this.loading=true;
    this.model.name=this.clientForm.value.name;
    this.model.lastname=this.clientForm.value.lastname;

    this.service.newClientService(this.model).subscribe((res: response)=>{
      this.model= new client();
      this.loading=false;
      this.toastr.success(res.message, 'Success!');
    }, (err: HttpErrorResponse) => {
      this.loading=false;
      if(err.status==400)
        this.toastr.warning('error sending data!', 'Error!');
      if(err.status==500)
        this.toastr.error('Internal Error!', 'Error!');
      if(err.status==0 && err.ok===false)
        this.toastr.warning('Impossible to connect to the server!', 'Waringi!');
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
