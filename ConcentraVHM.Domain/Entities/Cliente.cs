using System;
using System.ComponentModel.DataAnnotations;

namespace ConcentraVHM.Domain.Entities
{
	public class Cliente
	{
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [Key]
        public string Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public char TipoPersona { get; set; }


    }

    
}

