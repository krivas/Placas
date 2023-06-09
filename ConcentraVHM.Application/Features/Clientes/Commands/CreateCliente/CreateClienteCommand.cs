﻿using System;
using MediatR;

namespace ConcentraVHM.Application.Features.Clientes.Commands.CreateCliente
{
	public class CreateClienteCommand:IRequest<string>
	{
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string FechaNacimiento { get; set; }
        public char TipoPersona { get; set; }
    }

}

