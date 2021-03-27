import { Component, OnInit } from '@angular/core';
import { User } from "../../model/user";
import { AuthService } from "../../services/auth.service";
import { authtoken } from "../../model/auth-token";
import { HttpErrorResponse } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { Router } from "@angular/router";
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {


  mode: User =new User();

  constructor(private _authService: AuthService,private toastr: ToastrService,private _route: Router) { }
  

  login(){

    this._authService.Login(this.mode).subscribe((resp:authtoken)=>{
    this._authService.setToken(resp.token);
      console.log(resp);
      this._route.navigateByUrl("/accounts");
    }, (err: HttpErrorResponse) => {
      if(err.status==401)
        this.toastr.info('User Unauthorized!', 'Infotmation!');
      if(err.status==404)
        this.toastr.info('User NotFound!', 'Infotmation!');
      if(err.status==500)
        this.toastr.error('Internal Error!', 'Error!');
      console.log(err.status);
    });

  }

  logout() {
    this._authService.logout();
    this._route.navigateByUrl('/login');
  }


  ngOnInit() {
  }

}
