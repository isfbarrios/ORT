﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    class Administradora
    {
        private static Administradora instance;

        private static List<Pais> paises = new List<Pais>();
        private static List<Seleccion> selecciones = new List<Seleccion>();
        private static List<Jugador> jugadores = new List<Jugador>();
        private static List<Partido> partidos = new List<Partido>();
        private static List<Periodista> periodistas = new List<Periodista>();
        private static List<Resultado> resultados = new List<Resultado>();
        private static List<Resena> resenas = new List<Resena>();

        private static int paisId;
        private static int seleccionId;
        private static int jugadorId;
        private static int partidoId;
        private static int resultadoId;
        private static int resenaId;

        public int PaisId
        {
            get
            {
                return Administradora.paisId++;
            }
        }

        private Administradora() { }

        public static Administradora Instance
        {
            get
            {
                if (instance == null) instance = new Administradora();
                return instance;
            }
        }
        public List<Pais> Paises { get; }
        public List<Seleccion> Selecciones { get; }
        public List<Jugador> Jugadores { get; }
        public List<Partido> Partidos { get; }
        public List<Resultado> Resultados { get; }
        public List<Resena> Resenas { get; }
        public List<Periodista> Periodistas { get; }

    }
}
