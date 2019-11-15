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
            try 
	        {
                //Hago la conexion a la base de datos
                Conexion_Desconexion.Connection();
                //Armo el query para seleccionar todas las respuestas segun el id
                string query = @"SELECT * FROM Respuestas WHERE id_pregunta = @idPreg";
                //Armo el command con el query y la conexion
                SqlCommand command = new SqlCommand(query,Conexion_Desconexion.Con);
                //Paso como parametro codificado el id de la pregunta
                command.Parameters.AddWithValue("@idPreg",idPregunta);
                //Ejecuto un reader que va a tomar toda la informacion de la tabla correspondiendo a la condicion impuesta en el query
                SqlDataReader reader = command.ExecuteReader();
                //Mientras voy leyendo los datos, los tomo y armo una respuesta que luego agrego a la lista de respuestas
                while (reader.Read())
                {
                    Respuesta resp = new Respuesta();
                    resp.IdUserResp = reader.GetInt16(0);
                    resp.IdPregunta = reader.GetInt16(1);
                    resp.IdRespuesta = reader.GetInt16(2);
                    resp.Titulo = reader.GetString(3);
                    resp.Descripcion = reader.GetString(4);
                    resp.UrlImagen = reader.GetString(5);
                    resp.Fecha = reader.GetDateTime(6);
                    resp.Likes = reader.GetInt16(7);
                    respuestas.Add(resp);
            	}
                //Cierro la conexion a la Bd
                Conexion_Desconexion.Desconnect();
	        }
	        catch (Exception)
	        {
                //Nloggear
		        throw;
	        }
            //Finalmente devuelvo la lista de respuestas
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
        
        /// <summary>
        /// Elimina una respuesta de la base de datos
        /// </summary>
        static public void BajaRespuesta(int idRespuesta)
        {
            try
	        {	    
                //Conecto a la base de datos
                Conexion_Desconexion.Connection();
                //Tomo la cadena sql para hacer el Delete
	            string query = @"DELETE FROM Respuestas WHERE id_respuesta = @idResp";
                //Armo el command con mi query y la conexion
                SqlCommand command = new SqlCommand(query,Conexion_Desconexion.Con);
                //Paso como parametro codificado el id de la respuesta
                command.Parameters.AddWithValue("@idResp",idRespuesta);
                //Ejecuto el Delete y cierro la conexion
                command.ExecuteNonQuery();
                Conexion_Desconexion.Desconnect();
	        }
	        catch (Exception)
	        {
                //Nloggear
          		throw;
	        }
            

        }

        /// <summary>
        /// Realiza un UPDATE de los likes de la respuesta con el id especificado
        /// </summary>
        /// <param name="idRespuesta"></param>
        /// <param name="likes"></param>
        static public void UpdateLikes(int idRespuesta,int likes)
        {
            // TO DO
        }


    }
}