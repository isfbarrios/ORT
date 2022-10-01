using System;
using System.Collections.Generic;
using Dominio;

namespace Obligatorio1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Precarga de datos
            Administradora.PreLoad();
            int seleccion = -1;
            //Construccion del menú
            while (seleccion != 0)
            {
                Console.WriteLine("Acceda mediante el menu a la opcion deseada.\n\n" +
                    "1 ) Alta Periodista.\n" +
                    "2 ) Listar Periodistas.\n" +
                    "3 ) Crear Reseña.\n" +
                    "4 ) Asignar valor de referencia para categorías.\n" +
                    "0 ) Salir");

                int.TryParse(Console.ReadLine(), out seleccion);
                //Ejecuto las acciones según corresponda
                Program.OpcionesDeMenu(seleccion);
            }
        }

        private static void OpcionesDeMenu(int seleccion)
        {
            switch (seleccion)
            {
                case 1:
                    bool caseOne = Program.AltaPeriodista();
                    if (!caseOne) Console.WriteLine("No se pudo dar de alta. Intente nuevamente.");
                    else Console.WriteLine("Alta de periodista exitosa.");
                    break;
                case 2:
                    Program.ListarPeriodistas();
                    break;
                case 3:
                    Program.CrearResena();
                    break;
                case 4:

                    break;
                default:
                    seleccion = 0; //Salir
                    break;
            }
        }
        private static bool AsignarReferenciaCategoria()
        {
            bool retVal = false;
            string valorReferencia = "";
            string[] descripciones = { "Valor Referencia" };

            Console.WriteLine($"Ingrese un nuevo {descripciones[0]}:");

            bool datosValidos = false;
            //Solicito el nuevo valor hasta que el resultado sea correcto (datosValidos = Tue).
            do
            {
                datosValidos = SolicitarDatos(ref valorReferencia, descripciones[0]);
            }
            while (!datosValidos);
            if (valorReferencia.Length != 0)
            {
                //Guardo el nuevo valor dado que es un dato estático, si se actualiza, retorno TRUE.
                retVal = (Categoria.setMinimoParaVip(valorReferencia));
            }
            return retVal;
        }
        private static bool CrearResena()
        {
            bool retVal = false;
            string titulo = "", contenido = "";
            string[] descripciones = { "Título", "Contenido" };

            Console.WriteLine("Para crear una nueva reseña, complete los siguientes datos:");

            //Recorrida según cantidad de campos a completar (titulo, contenido).
            for (int i = 0; i <= 1; i++)
            {
                bool datosValidos = false;
                //Por cada uno solicito los datos hasta que el resultado sea correcto (datosValidos = Tue).
                do
                {
                    switch (i)
                    {
                        case 0:
                            datosValidos = SolicitarDatos(ref titulo, descripciones[i]);
                            break;
                        case 1:
                            datosValidos = SolicitarDatos(ref contenido, descripciones[i]);
                            break;
                    }
                }
                while (!datosValidos);
            }
            if (titulo.Length != 0 && contenido.Length != 0)
            {
                //Debo obtener el id de periodista al menos, o ver como generar el objeto correspondiente para que quede asociado
                retVal = Resena.AltaResena(new Resena(new Periodista(), new Partido(), titulo, contenido));
            }
            return retVal;
        }

        private static bool ListarPeriodistas()
        {
            bool retVal = false;

            return retVal;
        }

        private static bool AltaPeriodista()
        {
            bool retVal = false;
            string nombre = "", apellido = "", mail = "", password = "";
            string[] descripciones = {"Nombre", "Apellido", "Mail", "Password"};

            Console.WriteLine("Para dar de alta un nuevo periodista, complete los siguientes datos:");

            //Recorrida según cantidad de campos a completar (nombre, apellido, mail y password).
            for (int i = 0; i <= 3; i++)
            {
                bool datosValidos = false;
                //Por cada uno solicito los datos hasta que el resultado sea correcto (datosValidos = Tue).
                do
                {
                    switch (i)
                    {
                        case 0:
                            datosValidos = SolicitarDatos(ref nombre, descripciones[i]);
                            break;
                        case 1:
                            datosValidos = SolicitarDatos(ref apellido, descripciones[i]);
                            break;
                        case 2:
                            datosValidos = SolicitarDatos(ref mail, descripciones[i]);
                            break;
                        case 3:
                            datosValidos = SolicitarDatos(ref password, descripciones[i]);
                            break;
                    }
                }
                while (!datosValidos);
            }
            //Si los campos son validos, creo el objeto Periodista y lo paso a Periodista.AltaPeriodista() para el control especificado por la letra.

            if (nombre.Length != 0 && apellido.Length != 0 && mail.Length != 0 && password.Length != 0)
            {
                retVal = Periodista.AltaPeriodista(new Periodista(nombre, apellido, mail, password));
            }
            return retVal;
        }

        /// <summary>
        /// Método para solicitar los datos al usuario
        /// </summary>
        private static bool SolicitarDatos(ref string contenedor, string descripcion)
        {
            bool retVal = false;
            do
            {
                Console.WriteLine($"Ingrese {descripcion}:");
                contenedor = Console.ReadLine().Trim();

                if (contenedor.Length == 0) Console.WriteLine($"{descripcion} no puede quedar vacío. Intente nuevamente.");
                else retVal = true;
            }
            while (contenedor.Length == 0);

            return retVal;
        }
    }
}
