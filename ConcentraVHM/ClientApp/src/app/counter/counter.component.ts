import { DatePipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { ClientePlaca } from '../../Models/ClientePlaca';;

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {

  public items: ClientePlaca[] = [];
  
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<ClientePlaca[]>(baseUrl + 'api/placas').subscribe(result => {
     this.items=result.map(item=> new ClientePlaca(item.cliente,item.valor,item.id,item.tipoAutoMovil,item.fecha));

      console.log(result);
    }, error => console.error(error));
  }

 

}


