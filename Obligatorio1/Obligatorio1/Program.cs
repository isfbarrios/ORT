using System;
using System.Collections.Generic;

namespace Dominio
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime fecha = DateTime.Parse("19/11/2022");

           bool ValidarFechaDePartido()
            {
                bool retVal = false;
                DateTime dateFrom = Convert.ToDateTime("20/11/2022");
                DateTime dateTo = Convert.ToDateTime("18/12/2022");

                if (fecha >= dateFrom && fecha <= dateTo)
                {
                    retVal = true;
                }
                return retVal;
            }

            Console.WriteLine($"La fecha{(ValidarFechaDePartido() ? "" : " no")} se encuentre en el rango.");

            /*
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
            */
        }
    }
}
