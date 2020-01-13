import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';

import { HttpClient } from '@angular/common/http';
import { Passager } from '../models/passager';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';

@Injectable({
  providedIn: 'root'
})
export class PassagerService extends BaseService {

  constructor(private http: HttpClient) { super(); }

  obterTodos(): Observable<Passager[]> {
    return this.http
        .get<Passager[]>(this.UrlService + 'GetAllPassager')
        .catch(super.serviceError);
  }

  obterPassager(id: string): Observable<Passager> {
    return this.http
        .get<Passager>(this.UrlService + 'FindPassager/' + id)
        .catch(super.serviceError);
  }

  obterPassagersByAirplane(id: string): Observable<Passager[]> {
    return this.http
        .get<Passager[]>(this.UrlService + 'GetAllByAirplane/' + id)
        .catch(super.serviceError);
  }

  registrarPassager(airplane: Passager): Observable<Passager> {
    const response = this.http
        .post(this.UrlService + 'InsertPassager', airplane)
        .map(super.extractData)
        .catch(super.serviceError);

    return response;
  }

  atualizarPassager(airplane: Passager): Observable<Passager> {
    const response = this.http
        .put(this.UrlService + 'UpdatePassager', airplane)
        .map(super.extractData)
        .catch((super.serviceError));
    return response;
  }

  excluirPassager(id: string): Observable<Passager> {
    const response = this.http
        .delete(this.UrlService + 'Passager/' + id)
        .map(super.extractData)
        .catch((super.serviceError));
    return response;
  }

}
