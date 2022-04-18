using System;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// valido que el usuario haya ingresado un correctamente de lo contrario retornara +
        /// </summary>
        /// <param name="operador"> operador a validar </param>
        /// <returns></returns> retorna + en el caso de que sea incorrecto
        private static char ValidarOperando(char operador)
        {
            char retorno = operador;

            if(operador != '-' || operador != '+' || operador != '/' || operador != '*')
            {
                retorno =  '+';
            }
            return retorno;
        }

        /// <summary>
        /// realiza la operacion con los 2 numeros
        /// </summary>
        /// <param name="num1">numero a utilizar en la operacion</param>
        /// <param name="num2">numero a utilizar en la operacion</param>
        /// <param name="operador">operador que se utiliza para realizar el calculo</param>
        /// <returns></returns>retorno el resultado de la operacion
        public static double Operador(Operando num1, Operando num2, char operador)
        {
            double retorno = 0;
            
            switch (operador)
            {
                case '+':
                    retorno = num1 + num2;
                    break;
                case '-':
                    retorno = num1 - num2;
                    break;
                case '/':                   
                        retorno = num1 / num2;                                 
                    break;
                case '*':
                    retorno = num1* num2;
                    break;
            }
            return retorno;
        }
    }
}
