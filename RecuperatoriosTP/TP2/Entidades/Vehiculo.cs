using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    /// La Clase debe ser Abstracta,
    /// ya que el sealed va impedir que hereden de ella
    public abstract class Vehiculo 
    {

        #region Enumerados

        public enum EMarca //El enumerado debe ser publico
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }

        public enum ETamanio//El enumerado debe ser publico
        {
            Chico, Mediano, Grande
        }

        #endregion

        #region Atributos

        EMarca marca;
        string chasis;
        ConsoleColor color;

        #endregion

        #region Constructores

        /// <summary>
        /// Falto declarar el constructor que reciba 3 parametros
        /// </summary>
        /// <param name="chasis"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>

        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.color = color;
            this.marca = marca;

        }


        #endregion

        #region Propiedades

        ///// <summary>
        ///// ReadOnly: Retornará el tamaño
        ///// </summary>
        protected abstract ETamanio Tamanio { get; } //set;

        #endregion

        #region Metodos

        ///// <summary>
        ///// Publica todos los datos del Vehiculo.
        ///// </summary>
        ///// <returns></returns>
        ///Debe ser virtual
        public virtual string Mostrar()
        {
            return (string)this;
        }

        public static explicit operator string(Vehiculo p)//el método debe ser público
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CHASIS: {0}\r\n",p.chasis);                   
            sb.AppendFormat("MARCA:  {0}\r\n",p.marca.ToString());         
            sb.AppendFormat("COLOR:  {0}\r\n",p.color.ToString());         
            sb.AppendLine("---------------------");

            return sb.ToString();//falto el Metodo ToString
        }

        ///// <summary>
        ///// Dos vehiculos son iguales si comparten el mismo chasis
        ///// </summary>
        ///// <param name="v1"></param>
        ///// <param name="v2"></param>
        ///// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        ///// <summary>
        ///// Dos vehiculos son distintos si su chasis es distinto
        ///// </summary>
        ///// <param name="v1"></param>
        ///// <param name="v2"></param>
        ///// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2); //Falto indicar el mdistinto
        }

        #endregion
    }
}
