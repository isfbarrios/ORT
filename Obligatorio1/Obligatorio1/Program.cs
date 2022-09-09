using System;
using System.Collections.Generic;

namespace Dominio
{
    class Program
    {
        static void Main(string[] args)
        {
            int seleccion = -1;
            while (seleccion != 0)
            {
                Console.WriteLine("Acceda mediante el menu a la opcion deseada.\n\n" +
                    "1 ) Crear cliente.\n" +
                    "2 ) Mostrar clientes.\n" +
                    "3 ) Salir");

                int.TryParse(Console.ReadLine(), out seleccion);

                switch (seleccion)
                {
                    case 1:
                        //Ejercicio 1
                        break;
                    case 2:
                        //Ejercicio 2
                        break;
                    default:
                        //Salir
                        seleccion = 0;
                        break;
                }
            }
        }
    }
}
