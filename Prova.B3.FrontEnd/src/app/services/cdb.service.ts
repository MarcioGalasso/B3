import { Injectable } from '@angular/core';
import {CdbCalulado} from '../interfaces/cdbCalulado';
import {Cdb} from '../interfaces/cdb';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs'

@Injectable({
  providedIn: 'root'
})
export class CdbService {

  private readonly PATH = 'https://localhost:7251/Cdb/Calcular';
  constructor(private httpClient : HttpClient) { }

  calcularAsync(cdb : Cdb): Observable<CdbCalulado> {

    return this.httpClient.post<CdbCalulado>(this.PATH,cdb, { headers : {
      'Content-Type' : 'application/json'
  }})
  }
}
