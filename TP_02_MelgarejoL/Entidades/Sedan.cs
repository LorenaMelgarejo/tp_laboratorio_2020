using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        public enum ETipo { CuatroPuertas, CincoPuertas }

        ETipo tipo;

        public Sedan( EMarca marca, string chasis, ConsoleColor color):base(chasis, marca, color)
        {

        }

        ///// <summary>
        ///// Por defecto, TIPO será CuatroPuertas
        ///// </summary>
        ///// <param name="marca"></param>
        ///// <param name="chasis"></param>
        ///// <param name="color"></param>

        public Sedan(EMarca marca, string chasis, ConsoleColor color,ETipo tipo):this(marca, chasis, color)
        {
            tipo = ETipo.CuatroPuertas;
        }
        ///// <summary>
        ///// Sedan son 'Mediano'
        ///// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano; //debe retornar un mediano
            }
        }

        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TAMAÑO :  "+ this.Tamanio);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
