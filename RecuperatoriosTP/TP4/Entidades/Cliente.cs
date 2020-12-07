using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente: Persona
    {
        private int idCliente;

        public Cliente(int idCliente, string nombre,string apellido,int dni,string direccion):base(nombre,apellido,dni,direccion)
        {
            this.idCliente = idCliente ;
        }
        
    }
}
