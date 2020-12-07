using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    interface IArchivo<T>
    {
        void GenerarTicket(T info);
    }
}
