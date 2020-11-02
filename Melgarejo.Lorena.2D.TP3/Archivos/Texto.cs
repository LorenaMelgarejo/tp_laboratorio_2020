using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        ///sobreescribe sobre un archivo de texto 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo))
                {
                    writer.WriteLine(datos);

                    return true;
                }
            }
            catch (Exception ex)
            {

                throw new ArchivosException("Archivos Exception", ex);
            }

        }

        /// <summary>
        /// lee los datos de un archivo txt y los devuelve en string
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (StreamReader read = new StreamReader(archivo))
                {
                    datos = " ";
                    datos = read.ReadToEnd();
                    return true;
                }
            }
            catch (Exception e)
            {

                throw new ArchivosException("Archivos Exception", e);
            }
        }
    }
}
