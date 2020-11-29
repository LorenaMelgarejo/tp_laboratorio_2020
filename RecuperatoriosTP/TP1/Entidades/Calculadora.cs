using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        public double Operar(Numero num1, Numero num2, char operador)
        {
            double resultado = 0;
            string operadores; 
            operadores= ValidarOperador(operador);

            switch (operadores)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }
            return resultado;
        }


        /// <summary>
        /// valida los operadores y caso contrario retornara +
        /// </summary>
        /// <param name="operador"></param>


        private static string ValidarOperador(char operador)
        {
            while (operador == '+' || operador == '-' || operador == '*' || operador == '/')
            {
                return Char.ToString(operador);

            }
            return char.ToString('+');
        }
    }
}
