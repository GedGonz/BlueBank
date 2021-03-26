import { Injectable } from '@angular/core';
import {  HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { account } from "../model/account";
import { accountmove } from '../model/accountmove';
import { typemove } from "../model/typemove";
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  uri: string = environment.API_URL ;
  constructor(private http: HttpClient) { }


  getAccount(_id: string,_numberAccount: string): Observable<account> {
    const url = `${this.uri}/account/${_id}/${_numberAccount}`;

    return this.http.get<account>(url);
  }

  newAccountService(_account: account){

    const url = `${this.uri}/account`;
    return this.http.post(url, _account);
  }

  newMoveService(_accountmove: accountmove){

    console.log(_accountmove);
    const url = `${this.uri}/account/Move/${_accountmove.number}`;
    
    return this.http.post(url, _accountmove);
  }
}
