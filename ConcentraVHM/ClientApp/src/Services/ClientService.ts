import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cliente } from '../Models/Cliente';;

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  apiUrl = 'http://localhost:44494/api/clientes';

  constructor(private http: HttpClient) { }

  getClientes(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(this.apiUrl);
  }

  addCliente(cliente: Cliente): Observable<Cliente> {
    return this.http.post<Cliente>(this.apiUrl, cliente);
  }

  updateCliente(cliente: Cliente): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/${cliente.cedula}`, cliente);
  }

  deleteCliente(cedula: string): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/${cedula}`);
  }
}
