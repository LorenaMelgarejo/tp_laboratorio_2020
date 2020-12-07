using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Persona
    {
        private string nombre;
        private string apellido;
        private int dni;
        private string direccion;

        public Persona(string nombre, string apellido, int dni, string direccion)
        { }
    }
}
