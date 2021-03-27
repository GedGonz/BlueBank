import { Injectable } from '@angular/core';
import {  HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from "../model/user";
import { authtoken } from "../model/auth-token";
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  TOKEN_NAME: string = 'jwt_token';
  uri: string = environment.API_URL ;
  constructor(private http: HttpClient) { }



  Login(_user: User){

    const url = `${this.uri}/login`;
    return this.http.post(url, _user);
  }
  getToken(): string {
    return localStorage.getItem(this.TOKEN_NAME);
  }

  setToken(token: string): void {
    localStorage.setItem(this.TOKEN_NAME, token);
  }

  logout() {
    localStorage.removeItem(this.TOKEN_NAME);
  }

}
