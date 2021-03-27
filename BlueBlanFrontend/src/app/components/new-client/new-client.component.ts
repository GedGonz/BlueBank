import { Component, OnInit } from '@angular/core';
import { client } from "../../model/client";
import { ClientService } from "../../services/client.service";
import { ToastrService } from 'ngx-toastr';
import { HttpErrorResponse } from '@angular/common/http';
@Component({
  selector: 'app-new-client',
  templateUrl: './new-client.component.html',
  styleUrls: ['./new-client.component.css']
})
export class NewClientComponent implements OnInit {


  model: client = new client();


  constructor(private service: ClientService,private toastr: ToastrService) { }



  newClient()
  {
    console.log(this.model);
    this.service.newClientService(this.model).subscribe((res)=>{
      this.model= new client();
      console.log(res)
      this.toastr.success('Client create!', 'Success!');
    }, (err: HttpErrorResponse) => {

      if(err.status==404)
        this.toastr.info('Client NotFound!', 'Infotmation!');
      if(err.status==500)
        this.toastr.error('Internal Error!', 'Error!');

    });
  }



  ngOnInit() {
  }

}
