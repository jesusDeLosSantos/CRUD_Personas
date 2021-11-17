using System;

namespace Entities
{
    public class clsPersona
    {
        public string Nombre { get; }

        public string Apellidos { get; }

        public clsPersona(string nombre, string apellidos)
        {
            this.Nombre = nombre;
            this.Apellidos= apellidos;
        }
    }
}
