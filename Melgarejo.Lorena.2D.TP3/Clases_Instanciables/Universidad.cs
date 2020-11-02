using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Universidad
    {
        #region ATRIBUTOS
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region PROPIEDADES

        /// <summary>
        /// Propiedad de lectura y escritura donde retorna la posicion del elemento a agregar o insertar dependiendo su uso
        /// </summary>
        /// <param name="i"> Posicion donde insertar o tomar la clase almacenada </param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get { return this.jornada.ElementAt(i); }
            set { this.jornada.Insert(i, value); }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo privado alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo privado instructores
        /// </summary>
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo privado jornada
        /// </summary>
        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Constructor de clase que inicializa las listas
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Metodo de clase que guarda la informacion de la clase Universidad en un archivo .xml, retorna true si fue correcta
        /// </summary>
        /// <param name="uni"> Universidad </param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {

            try
            {
                Xml<Universidad> auxArchivo = new Xml<Universidad>();
                string file_name = AppDomain.CurrentDomain.BaseDirectory + "\\Universidad.xml";
                return auxArchivo.Guardar(file_name, uni);
            }
            catch (Exception ex)
            {
                throw new ArchivosException("Archivos Exception", ex);
            }
        }

        /// <summary>
        /// Metodo de clase para leer un archivo .xml y retorna su informacion
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            try
            {
                Xml<Universidad> auxArchivo = new Xml<Universidad>();
                string path = AppDomain.CurrentDomain.BaseDirectory;

                if (!auxArchivo.Leer(path + @"Universidad.xml", out Universidad rtn))
                {
                    rtn = null;
                }

                return rtn.ToString();
            }
            catch (Exception ex)
            {
                throw new ArchivosException("Archivos Exception", ex);
            }
        }

        /// <summary>
        /// Metodo de clase privado que muestra la informacion de la clase Universidad recibida como parametro
        /// </summary>
        /// <param name="uni"> Universidad </param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada item in uni.Jornadas)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Una Universidad no es igual a un alumno si este no esta dado de alta en ella
        /// </summary>
        /// <param name="g"> Universidad </param>
        /// <param name="a"> Alumno </param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Una Universidad no es igul a un profesor si este no esta en la lista de Instructores de dicha Universidad
        /// </summary>
        /// <param name="g"> Universidad </param>
        /// <param name="i"> Profesor </param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Retorna un Profesor, una Universidad no es igual a una clase si no hay profesores para esa catedra.
        /// Retorna el primero profesor que no pueda darla
        /// </summary>
        /// <param name="u"> Universidad </param>
        /// <param name="clase"> Programacion, Laboratorio, Legislacion, SPD </param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor aux = null;

            foreach (Profesor item in u.Instructores)
            {
                if (item != clase)
                {
                    aux = item;
                    break;
                }
            }
            return aux;
        }

        /// <summary>
        /// Retorna una Universidad, donde asigna todos los alumnos que cursen esa clase y los agrega a la jornada correspondiente
        /// </summary>
        /// <param name="g"> Universidad </param>
        /// <param name="clase"> Programacion, Laboratorio, Legislacion, SPD </param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor unProfesor = (g == clase);
            Jornada nuevaJornada = new Jornada(clase, unProfesor);

            foreach (Alumno item in g.alumnos)
            {
                if (item == clase)
                {
                    nuevaJornada.Alumnos.Add(item);
                }
            }
            g.Jornadas.Add(nuevaJornada);

            return g;
        }

        /// <summary>
        /// Agrega a Alumno si este ya no se encuentra en dicha Universidad recibida como parametro
        /// </summary>
        /// <param name="u"> Universidad </param>
        /// <param name="a"> Alumno </param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            bool flag = false;

            foreach (Alumno item in u.Alumnos)
            {
                if (a == item)
                {
                    flag = true;
                    throw new AlumnoRepetidoException();
                }
            }
            if (!flag)
            {
                u.Alumnos.Add(a);
            }

            return u;
        }

        /// <summary>
        /// Agrega un Profesor a la Universidad recibida como parametro si este no se encuentra en ella
        /// </summary>
        /// <param name="g"> Universidad </param>
        /// <param name="i"> Profesor </param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            bool flag = false;

            foreach (Profesor item in g.Instructores)
            {
                if (i == item)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                g.Instructores.Add(i);
            }
            return g;
        }

        /// <summary>
        /// Agrega a Alumno en Universidad que recibe como parametro si este ya no se encuentra dentro
        /// </summary>
        /// <param name="g"> Universidad </param>
        /// <param name="a"> Alumno </param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno item in g.Alumnos)
            {
                if (item == a)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Una Universidad es igual a un Profesor si este no se encuentra en ella
        /// </summary>
        /// <param name="g"> Universidad </param>
        /// <param name="i"> Profesor </param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor item in g.Instructores)
            {
                if (item.Equals(i))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Retorna un profesor para la clase recibida como parametro
        /// </summary>
        /// <param name="u"> Universidad </param>
        /// <param name="clase"> Programacion, Laboratorio, Legislacion, SPD  </param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.Instructores)
            {
                if (item == clase)
                {
                    return item;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Retorna toda la informacion de la Universidad recibida como parametro
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        #endregion
    }
}
