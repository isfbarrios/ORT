using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    class Utils
    {
        public static DateTime iniDate = new DateTime(2022, 11, 20);
        public static DateTime endDate = new DateTime(2022, 12, 18);
        public static Random gen;
        
        public static DateTime RandomDate()
        {
            Utils.gen = new Random();
            return Utils.iniDate.AddDays(new Random().Next(29)).AddHours(gen.Next(0, 24)).AddMinutes(gen.Next(0, 60)).AddSeconds(gen.Next(0, 60));
        }
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
                string retStr = a.Substring(i, (i + 1));
                if (retStr.IndexOf(b) >= 0) count++;
            }
            return count;
        }
        /// <summary>
        /// Remplaza todas las coincidencias del array { ".", ",", "-", "_", " ", ";" } en el String 'a'.
        /// </summary>
        public static string CharReplace(string a, string b)
        {
            string[] chars = { ".", ",", "-", "_", " ", ";" };
            return CharReplace(a, chars, b);
        }
        /// <summary>
        /// Remplaza todas las coincidencias del caracter 'b' en el String 'a'.
        /// Recibe como parametro un array de Strings con todos los caracteres a reemplazar
        /// </summary>
        public static string CharReplace(string a, string[] chars, string b)
        {
            string retVal = a;
            foreach (string c in chars)
            {
                retVal = CharReplace(retVal, c, b);

            }
            return retVal;
        }
        /// <summary>
        /// Remplaza todas las coincidencias del caracter 'b' en el String 'a', con el caracter 'c'.
        /// </summary>
        public static string CharReplace(string a, string b, string c)
        {
            string retVal = "";
            for (int i = 0; i < a.Length; i++)
            {
                retVal += (a[i] == b[0]) ? c : a[i].ToString();
            }
            return retVal;
        }
        /// <summary>
        /// Valida que un String sea igual o mayor al segundo parámetro.
        /// </summary>
        public static bool ValidLength(string a, int b)
        {
            if (a.Length >= b) return true;
            return false;
        }
        /// <summary>
        /// Retorna TRUE si un mail es valido.
        /// </summary>
        public static bool ValidMail(String a)
        {
            return (a.Length > 0 && a.IndexOf("@") > 0 && !a.StartsWith("@") && !a.EndsWith("@"));
        }
        public static int autoIncrementoId(List<Object> lista)
        {
            int retVal = 1;
            retVal = lista.Count > 0 ? lista.Count : retVal;
            return retVal;
        }
    }
}
