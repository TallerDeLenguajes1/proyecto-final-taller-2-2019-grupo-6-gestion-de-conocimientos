using Entidades;
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

            string query = @"SELECT * FROM Preguntas";

            //

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

            string query = @"SELECT * FROM Preguntas WHERE id_user = " + idUser.ToString();

            //
            return preguntasDeUser;
        }

        /// <summary>
        /// Elimina la pregunta con el id especificaco de la base de datos
        /// </summary>
        /// <param name="idPreg"></param>
        static public void BajaPregunta(int idPreg)
        {
            // Hacer un DELETE de la pregunta en la base de datos

            string query = @"DELETE FROM Preguntas WHERE id_pregunta = " + idPreg.ToString();
        }

        /// <summary>
        /// Inserta una nueva pregunta en la base de datos
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="tituloPreg"></param>
        /// <param name="descripcionPreg"></param>
        /// <param name="urlImagen"></param>
        static public void AltaPregunta(int idUser, string tituloPreg, string descripcionPreg, string urlImagen)
        {
            string query = @"INSERT INTO Preguntas(id_user, titulo, descripcion, url_imagen) VALUES(@id_user, @titulo, @descripcion, @url_imagen)";

            // Reemplazar parametros
        }
    }
}
