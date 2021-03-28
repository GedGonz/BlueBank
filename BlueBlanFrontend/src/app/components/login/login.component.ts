import { Component, OnInit } from '@angular/core';
import { User } from '../../model/user';
import { AuthService } from "../../services/auth.service";
import { authtoken } from "../../model/auth-token";
import { HttpErrorResponse } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { Router } from "@angular/router";
import { FormGroup,  FormBuilder,  Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  model: User =new User();

  constructor(private _authService: AuthService,private toastr: ToastrService,
    private _route: Router, private _fb: FormBuilder) 
  {
    this.createForm();
  }
  

  login(){

    this.model.username=this.loginForm.value.user;
    this.model.password=this.loginForm.value.password;


    this._authService.Login(this.model).subscribe((resp:authtoken)=>{
    this._authService.setToken(resp.token);

      this._route.navigateByUrl("/accounts");
    }, (err: HttpErrorResponse) => {
      if(err.status==401)
        this.toastr.info('User Unauthorized!', 'Infotmation!');
      if(err.status==404)
        this.toastr.info('User NotFound!', 'Infotmation!');
      if(err.status==500)
        this.toastr.error('Internal Error!', 'Error!');

    });


  }

  logout() {
    this._authService.logout();
    this._route.navigateByUrl('/login');
  }


  createForm() {
    this.loginForm = this._fb.group({
       user: ['', Validators.required ],
       password: ['', Validators.required ]
    });
  }

  ngOnInit() {
  }

}
