import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';

import { HttpClient } from '@angular/common/http';
import { Airplane } from '../models/airplane';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';

@Injectable({
  providedIn: 'root'
})
export class AirplaneService extends BaseService {

  constructor(private http: HttpClient) { super(); }

  obterTodos(): Observable<Airplane[]> {
    return this.http
        .get<Airplane[]>(this.UrlService + 'GetAllAirplane')
        .catch(super.serviceError);
  }

  obterAirplane(id: string): Observable<Airplane> {
      return this.http
          .get<Airplane>(this.UrlService + 'FindAirplane/' + id)
          .catch(super.serviceError);
  }

  registrarAirplane(airplane: Airplane): Observable<Airplane> {
    const response = this.http
        .post(this.UrlService + 'InsertAirplane', airplane)
        .map(super.extractData)
        .catch(super.serviceError);

    return response;
  }

  atualizarAirplane(airplane: Airplane): Observable<Airplane> {
    const response = this.http
        .put(this.UrlService + 'UpdateAirplane', airplane)
        .map(super.extractData)
        .catch((super.serviceError));
    return response;
  }

  excluirAirplane(id: string): Observable<Airplane> {
    const response = this.http
        .delete(this.UrlService + 'Airplane/' + id)
        .map(super.extractData)
        .catch((super.serviceError));
    return response;
  }

}
