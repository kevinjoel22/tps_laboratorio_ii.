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

        //contructores
        public Operando()
        {
            this.numero = 0;
        }

        public Operando(double numero)
        {
            this.numero = numero;
        }

        public Operando(string numeroStr)
        {
            this.Numero = numeroStr;
        }
        private string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

        public double ValidarOperando(string numeroStr)
        {
            double retorno = 0;

            double.TryParse(numeroStr, out retorno);
            
            return retorno;
        }

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

        public string DecimalBinario(string numero)
        {
            return DecimalBinario(double.Parse(numero));
        }

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

        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
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
