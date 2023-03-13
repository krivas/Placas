using System;
namespace ConcentraVHM.Domain.Entities
{
	public class TipoAutoMovil
	{
		public int Id { get; set; }
		public char Tipo { get; set; }
        public string Descripcion { get; set; }
        public int Valor { get; set; }
    }
}

