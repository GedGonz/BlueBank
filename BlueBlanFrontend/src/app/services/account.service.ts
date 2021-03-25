import { Injectable } from '@angular/core';
import {  HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { account } from "../model/account";
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

    let data={
      number:_account.Number,
      valueinit: _account.ValueInit,
      type: _account.Type,
      clientid: _account.ClientId
    }
    const url = `${this.uri}/account`;
    return this.http.post(url, data);
  }

}
