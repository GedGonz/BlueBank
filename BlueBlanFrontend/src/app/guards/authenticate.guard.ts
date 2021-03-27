import { Injectable } from '@angular/core';
import {  CanActivate } from '@angular/router';
import { AuthService } from "../services/auth.service";
import {  Router } from "@angular/router";
@Injectable({
  providedIn: 'root'
})
export class AuthenticateGuard implements CanActivate {
  
  constructor(
    private router: Router, 
    private authService: AuthService) {}

  canActivate() {
  
    if (this.authService.getToken()) {
      return true;
    }

    this.router.navigate(['/']);
    return false;
  }
}
