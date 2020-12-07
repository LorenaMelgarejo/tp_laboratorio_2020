using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empleado: Persona
    {
        
        private int  idEmpleado;

        public Empleado(int idEmpleado,string nombre,string apellido,int dni, string direccion):base(nombre,apellido,dni,direccion)
        {
            this.idEmpleado = idEmpleado;
        }
    }
}
