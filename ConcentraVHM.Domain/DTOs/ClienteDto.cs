using System;
namespace ConcentraVHM.Domain.DTOs
{
	public class ClienteDto
	{
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Id { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public char TipoPersona { get; set; }
    }
}

