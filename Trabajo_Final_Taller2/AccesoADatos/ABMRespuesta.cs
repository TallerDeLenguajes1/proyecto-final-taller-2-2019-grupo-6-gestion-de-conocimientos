using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AccesoADatos
{
    public class ABMRespuesta
    {
        /// <summary>
        /// Selecciona las respuestas de la pregunta con el id especificado
        /// </summary>
        /// <param name="idPregunta"></param>
        /// <returns></returns>
        public static List<Respuesta> GetRespuestas(int idPregunta)
        {
            List<Respuesta> respuestas = new List<Respuesta>();

            // Hacer consulta en la base de datos para obtener las respuestas de la pregunta

            string query = @"SELECT * FROM Respuestas WHERE id_pregunta = " + idPregunta.ToString();

            //
            return respuestas;
        }


        /// <summary>
        /// Crea una nueva respuesta y la inserta en la base de datos
        /// </summary>
        /// <param name="idUserResp"></param>
        /// <param name="idPregunta"></param>
        /// <param name="tituloResp"></param>
        /// <param name="descripcionResp"></param>
        /// <param name="urlImg"></param>
        static public void AltaRespuesta(int idUserResp, int idPregunta, string tituloResp, string descripcionResp, string urlImg)
        {
            // Realizar INSERT INTO en la tabla de respuestas

            try
            {
                //Hacer conexion a la base de datos
                Conexion_Desconexion.Connection();
                string query = @"INSERT INTO Respuestas(id_user,id_pregunta,titulo,descripcion,url_imagen) VALUES(@id_user,@id_pregunta,@titulo,@descripcion,@url_imagen)";
                SqlCommand command = new SqlCommand(query, Conexion_Desconexion.Con);
                /*NOTA: placeholders.*/
                command.Parameters.AddWithValue("@id_user", idUserResp);
                command.Parameters.AddWithValue("@id_pregunta", idPregunta);
                command.Parameters.AddWithValue("@titulo", tituloResp);
                command.Parameters.AddWithValue("@descripcion", descripcionResp);
                command.Parameters.AddWithValue("@url_imagen", urlImg);
                command.ExecuteNonQuery();
                //Desconectar
                Conexion_Desconexion.Desconnect();
            }
            catch (Exception ex)
            {
                //Nloggear
                throw;
            }
        }

        static public void BajaRespuesta(int idRespuesta)
        {
            string query = @"DELETE FROM Respuestas WHERE id_respuesta = " + idRespuesta.ToString();

        }
    }
}