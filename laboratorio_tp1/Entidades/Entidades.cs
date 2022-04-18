using System;

namespace Entidades
{
    public class Calculadora
    {
        private static char ValidarOperando(char operador)
        {
            char retorno = operador;

            if(operador != '-' || operador != '+' || operador != '/' || operador != '*')
            {
                retorno =  '+';
            }
            return retorno;
        }
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
