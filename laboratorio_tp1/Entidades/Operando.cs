using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        /// <summary>
        /// contructor por defecto inicializa el atributo en 0
        /// </summary>
        public Operando()
        {
            this.numero = 0;
        }

        /// <summary>
        /// contrutor  que setea el numero recibido al atributo
        /// </summary>
        /// <param name="numero">numero a setear</param>
        public Operando(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// contructor que setea el numero de tipo sting al atributo numero
        /// </summary>
        /// <param name="numeroStr">numero a setear</param>
        public Operando(string numeroStr)
        {
            this.Numero = numeroStr;
        }

        /// <summary>
        /// Propiedad que setea el valor recibido en el atributo Numero
        /// </summary>
        private string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

        /// <summary>
        /// valida que el operando recibido sea un numero
        /// </summary>
        /// <param name="numeroStr">numero a validar</param>
        /// <returns></returns>Retorna 0 en caso de que el numero recibido no sea de tipo numerico, si este es correcto lo parsea double y lo devuelve
        public double ValidarOperando(string numeroStr)
        {
            double retorno = 0;

            double.TryParse(numeroStr, out retorno);
            
            return retorno;
        }

        /// <summary>
        /// valido que lo recibido sea binario
        /// </summary>
        /// <param name="binario">numero a validar</param>
        /// <returns></returns>retorna true en caso de que si sea binario, de lo contrario retornara false
        private bool esBinario(string binario)
        {
            for(int i=0; i< binario.Length; i++)
            {
                if(binario[i] != '1' && binario[i] !='0')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// reaiza el cambio de binario a decimal
        /// </summary>
        /// <param name="binario">numero binario a convertir a decimal </param>
        /// <returns></returns>retorna el numero convertido a decimal
        public string BinarioDecimal(string binario)
        {
            string retorno = null;
            double exponente = binario.Length - 1;
            double acumulador = 0;
            if(binario is not null  && esBinario(binario))
            {
                for(int i = 0; i < (binario.Length-1); i--)
                {
                    if(binario[i] == '1')
                    {
                        acumulador += Math.Pow(i, exponente);
                    }
                    exponente--;        
                }
                retorno = acumulador.ToString();
            }
            else
            {
                return "Valor invalido";
            }
            return retorno;
        }

        /// <summary>
        /// realiza la conversion de un numero decimal a binarion
        /// </summary>
        /// <param name="numero">numero a convertir</param>
        /// <returns></returns>retorno el numero convertido a binario
        public string DecimalBinario(string numero)
        {
            return DecimalBinario(double.Parse(numero));
        }

        /// <summary>
        /// realiza la conversion de un numero decimal a binarion
        /// </summary>
        /// <param name="numero">numero a convertir</param>
        /// <returns></returns>retorno el numero convertido a binario
        public string DecimalBinario(double numero)
        {
            string numeroBinario = "";
            int auxNumero = (int)numero;

            if(auxNumero > 0)
            {
                while(auxNumero > 0)
                {
                    if(auxNumero % 2 == 0)
                    {
                        numeroBinario = '0' + numeroBinario;
                    }
                    else
                    {
                       numeroBinario = '1' + numeroBinario;
                    }
                    auxNumero = auxNumero / 2;
                }      
            }
            else
            {
                return "Valor invalido";
            }
            return numeroBinario;
        }

        /// <summary>
        /// sobrecarga del operador para que se pueda restar 2 numeros del tipo operando
        /// </summary>
        /// <param name="n1">objeto del tipo operando1</param>
        /// <param name="n2">objeto del tipo operando2</param>
        /// <returns></returns> retorno resultado de la operacion
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        ///  Sobrecarga del operador + para que pueda sumar dos objetos de tipo Operando.
        /// </summary>
        /// <param name="n1">Objeto de tipo Operando.</param>
        /// <param name="n2">Objeto de tipo Operando</param>
        /// <returns>Retorna el resultado de la suma entre estos dos.</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador * para que pueda multiplicar dos objetos de tipo Operando
        /// </summary>
        /// <param name="n1">objeto del tipo operando1</param>
        /// <param name="n2">objto del tipo operando2</param>
        /// <returns></returns> retorna el resultado de la multiplicacion de lso 2
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        ///  Sobrecarga del operador / para que pueda dividir dos objetos de tipo Operando.
        /// </summary>
        /// <param name="n1">Objeto de tipo Operando.</param>
        /// <param name="n2">Objeto de tipo Operando</param>
        /// <returns>Retorna el resultado de la division entre estos dos.</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            if(n2.numero == 0)
            {
                return double.MinValue;
            }
            return n1.numero / n2.numero;
        }
        
    }
}
