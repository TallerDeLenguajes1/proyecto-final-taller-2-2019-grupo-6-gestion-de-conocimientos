using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AccesoADatos
{
    public class ControlDatos
    {
        /// <summary>
        /// Verifica por medio de una expresión regular que el email ingresado sea correcto
        /// </summary>
        /// <param name="email"></param>
        /// <returns>True si es correcto - False si es incorrecto</returns>
        public static bool Verificaremail(string email)
        {
            //Tomo un bool para guardar el resultado
            bool Save;
            //Armo la expresión regular del email
            string ExpRegEmail = @"(([a-z]|[A-Z])|[0-9])+?@([a-z]|[A-Z])+?.(com)+$";
            //Si el email ingresado es correcto entonces Save = true
            Save = Regex.IsMatch(email, ExpRegEmail);
            //Retorno save
            return Save;
        }
    }
}
