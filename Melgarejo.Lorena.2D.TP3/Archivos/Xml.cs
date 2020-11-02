using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Excepciones;
using System.Xml;

namespace Archivos
{
    public class Xml<T> : IArchivo<T> 
    {
        #region METODOS
        /// <summary>
        /// Guarda en formato serializado .xml cualquier tipo de clase.
        /// </summary>
        /// <param name="archivo"> Parth del archivo</param>
        /// <param name="datos"> Cualquier tipo de dato a guardar</param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer((typeof(T)));

                    ser.Serialize(writer, datos);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new    ArchivosException("Archivos Exception", ex);
            }
        }

        /// <summary>
        /// Lee archivo serializado .xml y retorna el tipo de clase en salida por parametro.
        /// </summary>
        /// <param name="archivo"> Path del archivo </param>
        /// <param name="datos"> Salida de cualquier tipo de dato leido </param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));

                    datos = (T)ser.Deserialize(reader);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException("Archivos Exception", ex);
            }

        }
        #endregion
    }
}
