import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { AuthService } from "../../services/auth.service";
import { authtoken } from "../../model/auth-token";
@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {

  constructor(private _authService: AuthService,private _route: Router) { }

  ngOnInit() {
  }

  
  logout() {
    this._authService.logout();
    this._route.navigateByUrl('/');
  }

}
