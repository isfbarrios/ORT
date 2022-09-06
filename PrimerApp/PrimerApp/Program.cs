using System;

namespace PrimerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int seleccion = -1;
            while(seleccion != 0)
            {
                Console.Clear();
                Console.WriteLine("Acceda mediante el menu a la opcion deseada.");
                Console.WriteLine("1 ) Ejercicio 1\n2 ) Ejercicio 2\n3 ) Ejercicio 3\n4 ) Ejercicio 4\n5 ) Ejercicio 5\n0 ) Salir");

                int.TryParse(Console.ReadLine(), out seleccion);

                switch(seleccion)
                {
                    case 1:
                        //Ejercicio 1
                        EjercicioUno();
                        break;
                    case 2:
                        //Ejercicio 2
                        EjercicioDos();
                        break;
                    case 3:
                        //Ejercicio 3
                        EjercicioTres();
                        break;
                    case 4:
                        //Ejercicio 4
                        EjercicioCuatro();
                        break;
                    case 5:
                        //Ejercicio 3
                        EjercicioCinco();
                        break;
                    default:
                        //Salir
                        seleccion = 0;
                        break;
                }
            }
        }
        //Ejercicio Uno
        private static void EjercicioUno()
        {
            Console.WriteLine("Ejercicio Uno.");
            String nombre = "";
            String apellido = "";
            int edad = 0;

            Console.WriteLine("Ingrese su nombre:");
            nombre = Console.ReadLine();
            Console.WriteLine("Ingrese su apellido:");
            apellido = Console.ReadLine();
            Console.WriteLine("Ingrese su edad:");
            int.TryParse(Console.ReadLine(), out edad);

            Console.WriteLine($"Nombre: {nombre}.\n Apellido: {apellido}.\n Edad: {edad}");
        }
        //Ejercicio Dos
        private static void EjercicioDos()
        {
            Console.WriteLine("Ejercicio Dos.");
            int val1 = 0, val2 = 0;
            Console.WriteLine("Ingrese valor 1:");
            int.TryParse(Console.ReadLine(), out val1);
            Console.WriteLine("Ingrese valor 2:");
            int.TryParse(Console.ReadLine(), out val2);
            if (val1 > val2)
            {
                Console.WriteLine($"val1 es el mayor: {val1}");
            }
            else
            {
                if (val2 > val1)
                {
                    Console.WriteLine($"val2 es el mayor: {val2}");
                }
                else
                {
                    Console.WriteLine("Los números ingresados son iguales");
                }
            }
        }
        //Ejercicio Tres
        private static void EjercicioTres()
        {
            Console.WriteLine("Ejercicio Tres.");
            String texto = "";
            Console.WriteLine("Ingrese un texto para corroborar la cantidad de caracteres:");

            texto = Console.ReadLine().Trim();

            if (texto.Length > 0)
            {
                int cantidad = 0;
                for (int i = 0; i < texto.Length; i++)
                {
                    Console.WriteLine($"Letra: {texto[i]}");
                    cantidad++;
                }
                Console.WriteLine($"El texto tiene {cantidad} de caracteres.");
            }
        }
        //Ejercicio Cuatro
        private static void EjercicioCuatro()
        {
            Console.WriteLine("Ejercicio Cuatro.");
            int val1 = 0, val2 = 0;
            Console.WriteLine("Ingrese valor 1:");
            int.TryParse(Console.ReadLine(), out val1);
            Console.WriteLine("Ingrese valor 2:");
            int.TryParse(Console.ReadLine(), out val2);

            if (val1 == 0 || val2 == 0)
            {
                Console.WriteLine("Uno de los valores es cero. Intente nuevamente.");
            }
            else
            {
                Console.WriteLine($"Resultado de multiplicar ambos: {val1 * val2}");
            }
        }
        //Ejercicio Cinco
        private static void EjercicioCinco()
        {
            Console.WriteLine("Ejercicio Cinco.");
            int seleccion = -1;
            while (seleccion != 0)
            {
                int value1 = 0;
                int value2 = 0;
                Console.WriteLine("Ejercicio Cinco.");

                Console.WriteLine("Ingrese el primer valor.");
                int.TryParse(Console.ReadLine(), out value1);

                Console.WriteLine("Ingrese el segundo valor.");
                int.TryParse(Console.ReadLine(), out value2);

                Console.WriteLine("Ingrese el tipo de operación.");
                Console.WriteLine("1 ) Suma\n2 ) Resta\n3 ) Multiplicacion\n4 ) Division\n0 ) Salir");
                int.TryParse(Console.ReadLine(), out seleccion);
                switch (seleccion)
                {
                    case 1:
                        //Ejercicio 1
                        Console.WriteLine($"El resultado de la suma es {Suma(value1, value2)}");
                        break;
                    case 2:
                        //Ejercicio 2
                        Console.WriteLine($"El resultado de la resta es {Resta(value1, value2)}");
                        break;
                    case 3:
                        //Ejercicio 3
                        Console.WriteLine($"El resultado de la multiplicacion es {Multiplicacion(value1, value2)}");
                        break;
                    case 4:
                        //Ejercicio 4
                        Console.WriteLine($"El resultado de la division es {Division(value1, value2)}");
                        Division(value1, value2);
                        break;
                    default:
                        //Salir
                        seleccion = 0;
                        break;
                }
            }
        }
        private static int Suma(int a, int b)
        {
            return a + b;
        }
        private static int Resta(int a, int b)
        {
            return a - b;
        }
        private static int Multiplicacion(int a, int b)
        {
            return a * b;
        }
        private static int Division(int a, int b)
        {
            return a / b;
        }
    }
}
