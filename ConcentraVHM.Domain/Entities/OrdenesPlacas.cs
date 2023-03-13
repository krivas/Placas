using System;
namespace ConcentraVHM.Domain.Entities
{
	public class OrdenesPlacas
	{
		public int Id{ get; set; }
        public int Total { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
    }
}

