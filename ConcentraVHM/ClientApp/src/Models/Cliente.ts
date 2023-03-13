export class Cliente {
  nombre: string;
  apellido: string;
  cedula: string;
  fechaNacimiento?: Date;
  tipoPersona?: string;

  constructor(nombre: string, apellido: string, cedula: string, fechaNacimiento?: Date, tipoPersona?: string) {
    this.nombre = nombre;
    this.apellido = apellido;
    this.cedula = cedula;
    this.fechaNacimiento = fechaNacimiento;
    this.tipoPersona = tipoPersona;
  }

}
