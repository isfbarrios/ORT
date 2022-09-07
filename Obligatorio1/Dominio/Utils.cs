using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    class Utils
    {
        /// <summary>
        /// Retorna True el caracter 'b' aparece al menos una vez en 'a'.
        /// </summary>
        public static bool CharInclude(String a, String b)
        {
            return a.IndexOf(b) > 0 ? true : false;
        }
        /// <summary>
        /// Retorna la cantidad de veces que se repite el caracter 'b' en 'a'.
        /// </summary>
        public static int CharCount(String a, String b)
        {
            int count = 0;
            for (int i = 0; i <= a.Length; i++)
            {
                String retStr = a.Substring(i, (i + 1));
                if (retStr.IndexOf(b) >= 0) count++;
            }
            return count;
        }
        /// <summary>
        /// Remplaza todas las coincidencias del array { ".", ",", "-", "_", " ", ";" } en el String 'a'.
        /// </summary>
        public static String CharReplace(String a, String b)
        {
            String[] chars = { ".", ",", "-", "_", " ", ";" };
            return CharReplace(a, chars, b);
        }
        /// <summary>
        /// Remplaza todas las coincidencias del caracter 'b' en el String 'a'.
        /// Recibe como parametro un array de Strings con todos los caracteres a reemplazar
        /// </summary>
        public static String CharReplace(String a, String[] chars, String b)
        {
            String retVal = a;
            foreach (String c in chars)
            {
                retVal = CharReplace(retVal, c, b);

            }
            return retVal;
        }
        /// <summary>
        /// Remplaza todas las coincidencias del caracter 'b' en el String 'a', con el caracter 'c'.
        /// </summary>
        public static String CharReplace(String a, String b, String c)
        {
            String retVal = "";
            for (int i = 0; i < a.Length; i++)
            {
                retVal += (a[i] == b[0]) ? c : a[i].ToString();
            }
            return retVal;
        }
        /// <summary>
        /// Valida que un String sea igual o mayor al segundo parámetro.
        /// </summary>
        public static bool ValidLength(String a, int b)
        {
            if (a.Length >= b) return true;
            return false;
        }
    }
}
