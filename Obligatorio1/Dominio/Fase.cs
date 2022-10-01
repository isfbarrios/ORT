using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Fase
    {
        /*
        public static bool DefinirFaseGrupos()
        {
            bool retVal = false;
            int contador = 0, idFaseGrupo = 0;
            string grupo = "";
            List<Seleccion> seleccionesGrupo = new List<Seleccion>();
            foreach (Seleccion seleccion in Administradora.Instance.Selecciones)
            {
                //Recorro todas las selecciones, cada cuatro iteraciones, cargo el listado con estas cuatro en un determinado grupo
                if (contador == 3)
                {
                    contador = 0; //Vuelvo el contador a cero para un nuevo grupo.
                    idFaseGrupo++; //Incremento el id del grupo al que se deberá cargar el siguiente grupo de cuatro selecciones.
                    grupo = GetFaseGupo(idFaseGrupo);
                    seleccionesGrupo = new List<Seleccion>();
                }
                seleccionesGrupo.Add(seleccion);
                //Si ya tengo los cuatro integrantes, lo agrego al dictionary
                if (seleccionesGrupo.Count == 4)
                {
                    Administradora.Instance.SeleccionesPorGrupo.Add(grupo, seleccionesGrupo);
                }
            }
            return retVal;
        }
        */
        private static string GetFaseGupo(int id)
        {
            String[] grupos = { "A", "B", "C", "D", "E", "F", "G", "H", "I" };
            return grupos[id];
        }
    }
}
