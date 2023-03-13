using System;
namespace ConcentraVHM.Domain.Entities
{
	public class Placa
	{
        public int Valor { get; set; }
        public int Id { get; set; }
        public TipoAutoMovil TipoAutoMovil { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }


    }
}

