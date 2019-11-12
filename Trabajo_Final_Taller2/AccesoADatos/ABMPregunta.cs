﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public class ABMPregunta
    {
        /// <summary>
        /// Selecciona todas las preguntas en la base de datos
        /// </summary>
        /// <returns></returns>
        static public List<Pregunta> GetPreguntas()
        {
            List<Pregunta> preguntas = new List<Pregunta>();

            // Hacer consulta en la base de datos y cargar la lista

            return preguntas;
        }

        /// <summary>
        /// Selecciona las preguntas del usuario con el id especificado
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        static public List<Pregunta> GetPreguntas(int idUser)
        {
            List<Pregunta> preguntasDeUser = new List<Pregunta>();

            // Hacer consulta en la base de datos usando el idUser y cargar la lista

            return preguntasDeUser;
        }

        /// <summary>
        /// Elimina la pregunta con el id especificaco de la base de datos
        /// </summary>
        /// <param name="idPreg"></param>
        static public void BajaPregunta(int idPreg)
        {
            // Hacer un DELETE de la pregunta en la base de datos
        }
    }
}
