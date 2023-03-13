using System;
namespace ConcentraVHM.Application.Exceptions
{
    public class ExistsException : Exception
    {
        public ExistsException(string name,object key) : base($"Se encontro el mismo {name} ({key})")
        {
        }
    }
}

