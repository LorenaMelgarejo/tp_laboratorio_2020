using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;


        #region Propiedades

        /// <summary>
        ///  asignará un valor al atributo número
        /// </summary>
        private string SetNumero
        {

            set { this.numero = this.ValidarNumero(value); }
        }
        #endregion


        #region Construtores

        /// <summary>
        /// constructor por defecto que inicializa numero en 0
        /// </summary>

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {

            this.SetNumero = strNumero;
        }

        #endregion


        #region Metodos

        public string BinarioDecimal(string binario)
        {

            int exponente = binario.Length - 1;
            int num_decimal = 0;

            if (EsBinario(binario))
            {

                for (int i = 0; i < binario.Length; i++)
                {

                    if (int.Parse(binario.Substring(i, 1)) == 1)
                    {
                        num_decimal = num_decimal + int.Parse(System.Math.Pow(2, double.Parse(exponente.ToString())).ToString());
                    }

                    exponente--;
                }
            }
                return num_decimal.ToString();            
        }


        public string DecimalBinario(double numero)
        {
            string bin = "";

            if (numero > 0)
            {
                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        bin = "0" + bin;
                    }
                    else
                    {
                        bin = "1" + bin;
                    }
                    numero = (int)numero / 2;
                }
            }
            else if (numero == 0)
            {
                bin = "0";
            }
            return bin;
        }


        public string DecimalBinario(string numero)
        {

            string cadena = "";

            cadena = this.DecimalBinario(Convert.ToDouble(numero));

            return cadena;

        }


        private bool EsBinario(string binario)
        {
            bool retorno = false;
            foreach (char i in binario)
            {
                if (i == '1' || i == '0')
                    retorno = true;
                else
                    retorno = false;
            }
            return retorno;
        }


        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {

            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }

        /// <summary>
        /// valida que el valor recibido sea numérico
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns> retornará en formato double</returns>

        private double ValidarNumero(string strNumero)
        {
            double valor;

            if (double.TryParse(strNumero, out valor))
            {
                return valor;
            }

            else
            {
                return 0;
            }

        }
        #endregion
    }
}
