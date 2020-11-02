using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;


namespace Clases_Instanciables
{
    public class Jornada
    {
        #region ATRIBUTOS
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Propiedad de lectura y escritura 
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura 
        /// </summary>
        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        /// <summary>
        /// propiedad de lectura y escritura 
        /// </summary>
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor de instancia privado
        /// </summary>
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="clase"> Programacion, Laboratorio, Legislacion, SPD </param>
        /// <param name="instructor"> Profesor </param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Metodo de clase que garda en formato .txt la lista de Jornada que recibe como parametro
        /// </summary>
        /// <param name="jornada"> Lista del tipo Jornada a guardar</param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {

            try
            {
                Texto tex = new Texto();
                string file_name = AppDomain.CurrentDomain.BaseDirectory + "\\Jornada.txt";
                return tex.Guardar(file_name, jornada.ToString());
            }
            catch (Exception ex)
            {
                throw new ArchivosException("Archivos Exception", ex);
            }
        }

        /// <summary>
        /// Metodo de clase que lee un archivo txt 
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            Texto auxTexto = new Texto();
            string path = AppDomain.CurrentDomain.BaseDirectory;

            if (!auxTexto.Leer(path + @"Jornada.txt", out string retorno))
            {
                retorno = null;
            }

            return retorno.ToString();
        }

        /// <summary>
        /// Metodo de clase donde una Jornada no es igual a un alumno si este no este no cursa la clase de la Jornada
        /// </summary>
        /// <param name="j"> Jornada </param>
        /// <param name="a"> Alumno </param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Metodo de clase, una Jornada es igual a un alumno si pertenece a la clase 
        /// </summary>
        /// <param name="j"> Jornada </param>
        /// <param name="a"> Alumno </param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return a == j.Clase;
        }

        /// <summary>
        /// Metodo de clase que añade a un alumno a la jornada si este no esta en ella
        /// </summary>
        /// <param name="j"> Jornada </param>
        /// <param name="a"> Alumno </param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            foreach (Alumno item in j.Alumnos)
            {
                if (j != a)
                {
                    j.Alumnos.Add(a);
                }
            }
            return j;
        }

        /// <summary>
        /// Retorna toda la información de la Jornada con todos sus alumnos y su información personal
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            if (this.Alumnos.Count > 0)
            {
                sb.Append("\nJORNADA:\n");
                sb.AppendFormat("CLASE DE: {0}. POR {1}", this.Clase.ToString(), this.Instructor.ToString());
                sb.AppendLine("ALUMNOS: ");

                foreach (Alumno item in this.Alumnos)
                {
                    sb.AppendFormat("{0}\n", item.ToString());
                }

                sb.AppendLine("<------------------------------------------------->\n");
            }

            return sb.ToString();
        }
        #endregion
    }
}
