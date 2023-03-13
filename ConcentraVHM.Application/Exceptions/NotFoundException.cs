using System;
namespace ConcentraVHM.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name,object key) : base($"{name} ({key}) no se encontro ")
        {
        }
    }
}

