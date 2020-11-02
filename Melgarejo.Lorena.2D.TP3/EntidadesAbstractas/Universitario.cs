using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario:Persona
    {
        #region PARAMETROS

        private int legajo;

        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        public Universitario() : base()
        {

        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"> Argentino, Extranjero </param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region METODOS

        /// <summary>
        /// Compara si son del mismo tipo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj.GetType() == typeof(Universitario) && this == (Universitario)obj);
        }

        /// <summary>
        /// Muestra los datos completos de la clase, nombre completo, nacionalidad y su legajo.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Legajo Numero: " + this.legajo);

            return sb.ToString();
        }

        /// <summary>
        /// Dos universitarios son diferentes si tienen legajo y DNI diferentes
        /// </summary>
        /// <param name="pg1"> Universitario 1</param>
        /// <param name="pg2"> Universitario 2</param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Dos Universitarios son iguales si comparten el mismo legajo o mismo DNI
        /// </summary>
        /// <param name="pg1"> Universitario 1 </param>
        /// <param name="pg2"> Universitario 2 </param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
            if (pg1.Equals(pg2))
            {
                if (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Implementacion en sus herencias
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        #endregion
    }
}
