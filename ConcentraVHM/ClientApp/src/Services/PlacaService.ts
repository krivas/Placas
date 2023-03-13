import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cliente } from './cliente';

@Injectable({
  providedIn: 'root'
})
export class PlacasService {

  apiUrl = 'http://localhost:44494/api/placa';

  constructor(private http: HttpClient) { }

  getClientesPlacas(): Observable<Cliente[]> {
    return this.http.get<ClientePlaca[]>(this.apiUrl);
  }

  addPlaca(cliente: Cliente): Observable<Cliente> {
    return this.http.post<Cliente>(this.apiUrl, cliente);
  }

  updatePlaca(cliente: Cliente): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/${cliente.cedula}`, cliente);
  }

  deletePlaca(cedula: string): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/${cedula}`);
  }
}

