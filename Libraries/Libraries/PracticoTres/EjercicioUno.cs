using System;
using System.Collections.Generic;
using System.Text;

namespace Libraries.PracticoTres
{
    class EjercicioUno
    {
        static List<Cliente> clientes = new List<Cliente>();
        static void Main(string[] args)
        {
            int seleccion = -1;
            while (seleccion != 0)
            {
                Console.WriteLine("Acceda mediante el menu a la opcion deseada.");
                Console.WriteLine("1 ) Crear cliente\n2 ) Mostrar clientes\n3 ) Salir");

                int.TryParse(Console.ReadLine(), out seleccion);

                switch (seleccion)
                {
                    case 1:
                        //Ejercicio 1
                        EjercicioUno.CrearCliente();
                        break;
                    case 2:
                        //Ejercicio 2
                        EjercicioUno.MostrarClientes();
                        break;
                    default:
                        //Salir
                        seleccion = 0;
                        break;
                }   
            }
        }
        public static void MostrarClientes()
        {
            foreach (Cliente cli in clientes)
            {
                Console.WriteLine($"Se creo el Cliente:" +
                    $"Nombre: {cli.Nombre} " +
                    $"Documento: {cli.Documento} " +
                    $"moneda: {cli.Cuenta.Moneda.ToString()} ");
            }
        }

        public static String CrearCliente()
        {
            String retVal = "No se pudo crear el cliente";
            Cliente cliente = new Cliente();
            String nombre = "";
            int documento = 0;
            String codigoMoneda = "";
            CodigoIso moneda = CodigoIso.NONE;

            Console.WriteLine("Debe crear una nueva cuenta. " +
                "\n" +
                "Para comenzar, ingrese su nombre completo.");

            nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el documento.");

            int.TryParse(Console.ReadLine(), out documento);

            Console.WriteLine("Ingrese la moneda.");

            codigoMoneda = Console.ReadLine();

            switch (codigoMoneda)
            {
                case "ARG":
                    moneda = CodigoIso.ARS;
                    break;
                case "USD":
                    moneda = CodigoIso.USD;
                    break;
                case "UYU":
                    moneda = CodigoIso.UYU;
                    break;
            }

            if (documento != 0 && nombre.Length > 0)
            {
                cliente = new Cliente(documento, nombre, moneda);
                EjercicioUno.clientes.Add(cliente);
                retVal = "Se creo el cliente con exito";
            }

            return retVal;
        }
    }
}
