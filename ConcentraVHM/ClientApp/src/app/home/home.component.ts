import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit , Inject} from '@angular/core';
import {NgForm} from '@angular/forms';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { ClienteService } from '../../Services/ClientService';
import { Cliente } from '../../Models/Cliente';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit{
 
items:Cliente[]=[];
  displayError: string = "";
  cliente: Cliente = {  nombre: "", apellido: "", cedula: "", fechaNacimiento: undefined ,tipoPersona:undefined};
  
  constructor(private clientService:ClienteService) {
  
  }
  ngOnInit(): void {
     this.loadItems();
  } 

  loadItems(): void {
   this.clientService.getClientes().subscribe(result => {
      this.items=result;
    }, error => console.error(error));
  }

  submit(form: NgForm): void {
    this.displayError = "";
    console.log(this.cliente);
    console.log(form);

    if (form.valid) {
      this.clientService.addCliente(this.cliente)
        .subscribe(response => {
          console.log(response);
          this.cliente = {  nombre: "", apellido: "", cedula: "", fechaNacimiento: undefined ,tipoPersona:undefined};
          form.resetForm();
          this.loadItems();
        }, error => {
          console.error(error);
          this.displayError = error.message;
        });
    }
    
  }
  delete(cliente: Cliente, index: number) {
    this.clientService.deleteCliente(cliente.cedula)
      .subscribe(
        response => {
          console.log('Response:', response);
          this.items.splice(index,1);
        },
        error => {
          console.error('Error body:', error.error);
        }
      );
  }
  edit(cliente: Cliente) {
    this.cliente=cliente;
    this.cliente.fechaNacimiento=undefined;
  }

}




