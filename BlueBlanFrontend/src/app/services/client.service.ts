import { Injectable } from '@angular/core';
import {  HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { client } from "../model/client";
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  uri: string = environment.API_URL ;
  constructor(private http: HttpClient) { }


  
  newClientService(_client: client){

    const url = `${this.uri}/client`;
    return this.http.post(url, _client);
  }

  getClient(): Observable<client[]> {
    const url =  `${this.uri}/client`;
    return this.http.get<client[]>(url);
  }
}
