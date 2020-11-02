using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public class Profesor: Universitario
    {
        #region ATRIBUTOS
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor de clase
        /// </summary>
        public Profesor() : base()
        {

        }

        /// <summary>
        /// Constructor de instancia privado
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
            //this.clasesDelDia = new Queue<Universidad.EClases>();
            //this._randomClases();
        }

        /// <summary>
        /// Constructor de instancia 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"> Argentino, Extranjero </param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();

        }
        #endregion

        #region METODOS
        /// <summary>
        /// Metodo privado donde asigna dos clases a un instructor
        /// </summary>
        private void _randomClases()
        {
            int catidad = Enum.GetNames(typeof(Universidad.EClases)).Length;

            for (int i = 0; i < 2; i++)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)(random.Next(catidad)));
            }
        }

        /// <summary>
        /// Muestra datos completos de la clase. Nombre completo, nacionalidad y su legajo.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Retorna nombre completo, su nacionalidad y las dos clases que de ese dia
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA: ");
            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Retorna nombre completo, nacionalidad, su legajo y las clases que da por dia
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Un profesor no es igual a una clase si este no la dicta
        /// </summary>
        /// <param name="i"> Profesor </param>
        /// <param name="clase"> Programacion, Laboratorio, Legislacion, SPD </param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Un profesor es igual a una clase si este la da en sus dias
        /// </summary>
        /// <param name="i"> Profesor </param>
        /// <param name="clase"> Programacion, Laboratorio, Legislacion, SPD </param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool rtn = false;
            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if (item == clase)
                {
                    rtn = true;
                    break;
                }
            }
            return rtn;
        }
        #endregion
    }
}
