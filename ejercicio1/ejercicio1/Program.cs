using System;

/*Ingresar 5 números por consola, guardándolos en una variable escalar. Luego calcular y mostrar: el valor máximo,
 el valor mínimo y el promedio*/
namespace ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero;
            int maximo = int.MaxValue;
            int minimo = int.MinValue;
            int acum = 0;
            int promedio;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Ingrese un numero: ");
                numero = int.Parse(Console.ReadLine());
                acum += numero;

               if (numero > 0)
                {
                    if(minimo < numero)
                    {
                        minimo = numero;
                    }

                    if(maximo > numero)
                    {
                        maximo = numero;
                    }
                }
            }
            promedio = acum / 5;
            Console.WriteLine("promedio es:"+promedio);
            Console.WriteLine("el maximo es:"+ minimo);
            Console.WriteLine("El minimo es: "+maximo);
        }
    }
}
