using System;
using System.Collections.Generic;
using Dominio;

namespace Obligatorio1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Precarga de datos obligatoria.
            Administradora.PreLoad();
            
            //Simulación del Login.
            //Se asume que las credenciales serán: mail (usuario) y password (contraseña).
            Program.Login();

            if (Administradora.session_user != "" & Administradora.session_pass != "")
            {
                //Construccion del menú
                int seleccion = -1;
                while (seleccion != 0)
                {
                    Console.WriteLine("Acceda mediante el menu a la opcion deseada.\n\n" +
                        "1 ) Alta Periodista.\n" +
                        "2 ) Listar Jugadores expulsados.\n" +
                        "3 ) Crear Reseña.\n" +
                        "4 ) Asignar valor de referencia para categorías.\n" +
                        "5 ) Buscar jugador por su Id.\n" +
                        "6 ) Listar partidos donde partició un jugador.\n" +
                        "7 ) Listar partidos disputados.\n" +
                        "0 ) Salir");

                    int.TryParse(Console.ReadLine(), out seleccion);
                    //Ejecuto las acciones según corresponda
                    Program.OpcionesDeMenu(seleccion);
                }
            } 
        }

        private static void OpcionesDeMenu(int seleccion)
        {
            switch (seleccion)
            {
                case 1:
                    Console.Clear();
                    //Alta Periodista
                    Console.WriteLine(AltaPeriodista());
                    break;
                case 2:
                    Console.Clear();
                    //Listar Periodistas
                    Console.WriteLine(ListarJugadoresExpulsados());
                    break;
                case 3:
                    Console.Clear();
                    //Alta Reseña
                    //CrearResena();
                    break;
                case 4:
                    Console.Clear();
                    //Modificar valor referencia categoría
                    //AsignarReferenciaCategoria();
                    break;
                case 5:
                    Console.Clear();
                    //Buscar jugador por su Id
                    BuscarJugador();
                    break;
                case 6:
                    Console.Clear();
                    //Buscar jugador por su Id y listo los partidos del mismo
                    ListarPartidosJugador(BuscarJugador());
                    break;
                case 7:
                    Console.Clear();
                    //Lista los partidos disputados
                    ListarPartidos();
                    break;
                default:
                    seleccion = 0; //Salir
                    break;
            }
        }
        public static bool ListarPartidos()
        {
            bool retVal = Administradora.Instance.Partidos.Count > 0 ? true : false;

            Console.WriteLine("\n" + (retVal ? "Listado de partidos disputados." : "No se encontraron registros de partidos disputados.") + "\n");

            if (retVal)
            {
                foreach (Partido partido in Administradora.Instance.Partidos)
                {
                    Console.WriteLine($"{partido.ToString()}.\n");
                }
            }
            return retVal;
        }
        private static Jugador BuscarJugador()
        {
            string id = "";
            string[] descripciones = { "Id" };
            Jugador jugador = null;

            Console.WriteLine($"Ingrese un nuevo {descripciones[0]}:");

            bool datosValidos = false;
            do
            {
                datosValidos = SolicitarDatos(ref id, descripciones[0]);
            }
            while (!datosValidos);

            if (id.Length > 0)
            {
                try
                {
                    jugador = Jugador.GetJugador(id);

                }
                catch (Exception) {}
            }

            if (jugador.Id == int.Parse(id)) Console.WriteLine($"\n{jugador.ToString()}.\n");
            else Console.WriteLine("\nNo se pudo encontrar un jugador con ese Id.\n");

            return jugador;
        }
        private static bool ListarPartidosJugador(Jugador jugador)
        {
            List<Partido> partidos = Jugador.GetPartidos(jugador);
            string msg = "";
            bool retVal = partidos.Count > 0 ? true : false;
            
            if (partidos.Count > 0)
            {
                foreach (Partido partido in partidos)
                {
                    msg += $"{partido.ToString()}.\n";
                }
            }
            else msg = "\nEl jugador no partició en ningún partido hasta el momento.\n";

            Console.WriteLine(msg);
            
            return retVal;
        }
        //private static bool AsignarReferenciaCategoria()
        //{
        //    bool retVal = false;
        //    string valorReferencia = "";
        //    string[] descripciones = { "Valor Referencia" };

        //    Console.WriteLine($"Ingrese un nuevo {descripciones[0]}:");

        //    bool datosValidos = false;
        //    //Solicito el nuevo valor hasta que el resultado sea correcto (datosValidos = Tue).
        //    do
        //    {
        //        datosValidos = SolicitarDatos(ref valorReferencia, descripciones[0]);
        //    }
        //    while (!datosValidos);
        //    if (valorReferencia.Length != 0)
        //    {
        //        //Guardo el nuevo valor dado que es un dato estático, si se actualiza, retorno TRUE.
        //        retVal = (Categoria.setMinimoParaVip(valorReferencia));
        //    }
        //    return retVal;
        //}
        //private static bool CrearResena()
        //{
        //    bool retVal = false;
        //    string titulo = "", contenido = "";
        //    string[] descripciones = { "Título", "Contenido" };

        //    Console.WriteLine("\nPara crear una nueva reseña, complete los siguientes datos:\n");

        //    //Recorrida según cantidad de campos a completar (titulo, contenido).
        //    for (int i = 0; i < descripciones.Length; i++)
        //    {
        //        bool datosValidos = false;
        //        //Por cada uno solicito los datos hasta que el resultado sea correcto (datosValidos = Tue).
        //        do
        //        {
        //            switch (i)
        //            {
        //                case 0:
        //                    datosValidos = SolicitarDatos(ref titulo, descripciones[i]);
        //                    break;
        //                case 1:
        //                    datosValidos = SolicitarDatos(ref contenido, descripciones[i]);
        //                    break;
        //            }
        //        }
        //        while (!datosValidos);
        //    }
        //    if (titulo.Length != 0 && contenido.Length != 0)
        //    {
        //        //Debo obtener el id de periodista al menos, o ver como generar el objeto correspondiente para que quede asociado
        //        Resena resena = new Resena(new Periodista(), new Partido(), titulo, contenido);
        //        Console.WriteLine($"\nSe creó la Reseña: {resena.ToString()}.\n");
        //        retVal = Resena.AltaResena(resena);
        //    }
        //    return retVal;
        //}

        private static string ListarJugadoresExpulsados()
        {
            string retVal = "\nNo se registraron expulsiones hasta el momento.\n";
            List<Jugador> jugadoresExpulsados = Jugador.GetJugadoresExpulsados();
           
            if (jugadoresExpulsados.Count != 0)
            {
                retVal = "\nListado de jugadores con al menos una expulsión.\n";
               
                foreach (Jugador jugador in jugadoresExpulsados)
                {
                    Console.WriteLine($"{jugador.ToString()}.");
                }
            }

            return retVal;
        }
        private static string AltaPeriodista()
        {
            string retVal = "\nNo se pudo dar de alta. Intente nuevamente.\n";
            string nombre = "", mail = "", password = "";
            string[] descripciones = {"Nombre", "Mail", "Password"};

            Console.WriteLine("\nPara dar de alta un nuevo periodista, complete los siguientes datos:\n");

            //Recorrida según cantidad de campos a completar (nombre, mail y password).
            for (int i = 0; i < descripciones.Length; i++)
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
                            datosValidos = SolicitarDatos(ref mail, descripciones[i]);
                            break;
                        case 2:
                            datosValidos = SolicitarDatos(ref password, descripciones[i]);
                            break;
                    }
                }
                while (!datosValidos);
            }
            //Si los campos son validos, creo el objeto Periodista y lo paso a Periodista.AltaPeriodista() para el control especificado por la letra.

            if (nombre.Length != 0 && mail.Length != 0 && password.Length != 0)
            {
                Periodista periodista = new Periodista(nombre, mail, password);

                if (Periodista.AltaPeriodista(periodista)) retVal = $"\nSe creó el Periodista: {periodista.ToString()}.\n";
            }
            return retVal;
        }

        private static bool Login()
        {
            bool retVal = false;
            string user = "", pass = "";
            string[] descripciones = { "Usuario", "Contraseña" };

            Console.WriteLine("\nIngrese sus credenciales para acceder al sistema.\n");

            //Recorrida según cantidad de campos a completar (nombre, apellido, mail y password).
            for (int i = 0; i < descripciones.Length; i++)
            {
                bool datosValidos = false;
                //Por cada uno solicito los datos hasta que el resultado sea correcto (datosValidos = Tue).
                do
                {
                    switch (i)
                    {
                        case 0:
                            datosValidos = SolicitarDatos(ref user, descripciones[i]);
                            break;
                        case 1:
                            datosValidos = SolicitarDatos(ref pass, descripciones[i]);
                            break;
                    }
                }
                while (!datosValidos);
            }
            //Si los campos son validos, almaceno las credenciales en las variables de la sesión.
            if (user.Length != 0 && pass.Length != 0)
            {
                Administradora.session_user = user;
                Administradora.session_pass = pass;

                Console.WriteLine("\nAcceso al sistema.\n");
                retVal = true;
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
