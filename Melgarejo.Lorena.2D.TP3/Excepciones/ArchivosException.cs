using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Excepcion que controla si el el archivo es null
        /// </summary>
        /// <param name="e"> Excepcion </param>
        public ArchivosException(string message, Exception innerException)
        {

        }

        public ArchivosException(string message) : base(message)
        {

        }
    }
}
