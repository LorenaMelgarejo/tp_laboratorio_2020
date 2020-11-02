using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;

namespace Clases_Instanciables
{
    public class Alumno: Universitario
    {
        #region ATRIBUTOS

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor de instancia
        /// </summary>
        public Alumno() : base()
        {

        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"> Argentino, Extranjero</param>
        /// <param name="claseQueToma"> Programacion, Laboratorio, Legislacion, SPD </param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma, EEstadoCuenta.Deudor)
        {

        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"> Argentino, Extranjero</param>
        /// <param name="claseQueToma"> Programacion, Laboratorio, Legislacion, SPD </param>
        /// <param name="estadoCuenta"> AlDia, Deudor, Becado </param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.estadoCuenta = estadoCuenta;
            this.claseQueToma = claseQueToma;
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Muestra los datos completos 
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            sb.AppendLine("Estado de cuenta: " + this.estadoCuenta);

            return sb.ToString();
        }

        /// <summary>
        /// Un alumno es diferente a una clase cuando no esta en ella
        /// </summary>
        /// <param name="a"> Alumno </param>
        /// <param name="clase"> Programacion, Laboratorio, Legislacion, SPD </param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma != clase;

        }

        /// <summary>
        /// Un alumno es igual a una clase si su clase es la misma y su estado no es deudor
        /// </summary>
        /// <param name="a"> Alumno </param>
        /// <param name="clase"> Programacion, Laboratorio, Legislacion, SPD</param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a.estadoCuenta != EEstadoCuenta.Deudor && a.claseQueToma == clase)
            {
                return true;
            }
            return false;

        }

        /// <summary>
        /// Retorna la clase que toma
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return string.Format("TOMA CLASE DE {0}\n", this.claseQueToma.ToString());
        }

        /// <summary>
        /// Muestra los 
        /// datos completos 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
