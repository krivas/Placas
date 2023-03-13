using System;
using ConcentraVHM.Domain.Entities;

namespace ConcentraVHM.Domain.DTOs
{
	public class PlacaDto
	{
        public int Valor { get; set; }
        public int Id { get; set; }
        public char TipoAutoMovil { get; set; }
        public string Cedula { get; set; }
        public Cliente Cliente { get; set; }
        public string Fecha { get; set; }

    }
}

