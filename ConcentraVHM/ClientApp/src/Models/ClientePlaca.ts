import { Cliente } from "./Cliente";

export class ClientePlaca {
  cliente: Cliente;
  valor: number;
  id: number;
  tipoAutoMovil: string;
  fecha: string;

  constructor(
    cliente: Cliente,
    valor: number,
    id: number,
    tipoAutoMovil: string,
    fecha: string
  ) {
    this.cliente = cliente,
      this.valor = valor;
    this.id = id;
    this.tipoAutoMovil = tipoAutoMovil;
    this.fecha = fecha;
  }
}
