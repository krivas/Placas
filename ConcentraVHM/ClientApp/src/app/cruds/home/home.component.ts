import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit , Inject} from '@angular/core';
import {NgForm} from '@angular/forms';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { ClienteService } from '../../../Services/ClientService';
import { Cliente } from '../../../Models/Cliente';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit{
 
items:Cliente[]=[];
  displayError: string = "";
  cliente: Cliente = {  nombre: "", apellido: "", cedula: "", fechaNacimiento: "" ,tipoPersona:undefined};
  
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
          this.cleanForm();
          form.resetForm();
          this.loadItems();
        }, error => {
          console.error(error);
          this.displayError = error.error;
        });
    }
    
  }
  cleanForm()
  {
    this.cliente = {  nombre: "", apellido: "", cedula: "", fechaNacimiento: "",tipoPersona:undefined};
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
   
    const date=cliente.fechaNacimiento;
    const dateSubstring = date.substring(0, date.indexOf('T'));
    this.cliente={  nombre: cliente.nombre, apellido: cliente.apellido, cedula: cliente.cedula, fechaNacimiento: dateSubstring ,tipoPersona:cliente.tipoPersona};
  }

  editarCliente(form: NgForm)
  {
    if (form.valid) {
      this.clientService.updateCliente(this.cliente)
        .subscribe(response => {
          console.log(response);
          this.cleanForm();
          form.resetForm();
          this.loadItems();
        }, error => {
          console.error(error);
          this.displayError = error.error;
        });
     }
  }
}




