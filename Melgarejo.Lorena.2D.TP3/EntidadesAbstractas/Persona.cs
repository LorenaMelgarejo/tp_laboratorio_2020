using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region ATRIBUTOS
        public enum ENacionalidad { Argentino, Extranjero }

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion  
        #region PROPIEDADES
        /// <summary>
        /// Propiedad de lectura y escritura del atributo privado apellido
        /// </summary>
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = ValidarNombreApellido(value); }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo privado dni
        public int DNI
        {
            get { return this.dni; }
            set { this.dni = ValidarDni(this.nacionalidad, value); }
        }

        /// <summary>
        /// Propiedad de lectura y escritura 
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo privado nombre
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = ValidarNombreApellido(value); }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo privado dni
        /// </summary>
        public string StringToDNI
        {
            set { this.dni = ValidarDni(this.Nacionalidad, value); }
        }
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona()
        {

        }

        /// <summary>
        /// Inicializa la clase Persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        ///inicializa el dni
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }


        #endregion

        #region METODOS
        /// <summary>
        /// Retorna nombre completo y su nacionalidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.Apellido, this.Nombre);
            sb.AppendLine("NACIONALIDAD: " + this.nacionalidad);

            return sb.ToString();
        }

        /// <summary>
        /// Valida el rango del DNI dependiendo su nacionalidad
        /// </summary>
        /// <param name="nacionalidad"> Argentino, Extranjero </param>
        /// <param name="dato"> DNI formato int </param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {

            if (dato >= 1 && dato <= 89999999)
            {
                if (nacionalidad == ENacionalidad.Argentino)
                {
                    return dato;
                }
                throw new NacionalidadInvalidaException();
            }
            else if (dato >= 90000000 && dato <= 99999999)
            {
                if (nacionalidad == ENacionalidad.Extranjero)
                {
                    return dato;
                }
                throw new NacionalidadInvalidaException();
            }
            else
            {
                throw new NacionalidadInvalidaException("Numero Fuera de rango");
            }
        }

        /// <summary>
        /// Valida el rango del DNI dependiendo su nacionalidad
        /// </summary>
        /// <param name="nacionalidad"> Argentino, Extranjero  </param>
        /// <param name="dato"> DNI formato string </param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            try
            {
                int numDni = int.Parse(dato);
                return this.ValidarDni(nacionalidad, numDni);
            }
            catch (FormatException)
            {

                throw new DniInvalidoException("La cadena ingresada tiene caracteres que no corresponden a un numero de Dni");
            }
        }

        /// <summary>
        /// Valida si es correcto el tipo de dato para nombre y apellido
        /// </summary>
        /// <param name="dato"> Nombre/Apellido </param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            if (!string.IsNullOrWhiteSpace(dato))
            {
                Regex rx = new Regex(@"[^A-Za-z\s]");
                if (!rx.IsMatch(dato))
                {
                    return dato;
                }
            }
            return null;
        }
        #endregion
    }
}
