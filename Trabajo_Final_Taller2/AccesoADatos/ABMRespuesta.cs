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
                    resp.IdUserResp = reader.GetInt32(0);
                    resp.IdPregunta = reader.GetInt32(1);
                    resp.IdRespuesta = reader.GetInt32(2);
                    resp.Titulo = reader.GetString(3);
                    resp.Descripcion = reader.GetString(4);
                    if (reader[5] == DBNull.Value)
                    {
                        resp.UrlImagen = null;
                    }
                    else
                    {
                        resp.UrlImagen = reader.GetString(5);
                    }
                    resp.Fecha = reader.GetDateTime(6);
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
        /// Crea una nueva respuesta con imagen y la inserta en la base de datos
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
        /// Crea una nueva respuesta sin imagen y la inserta en la base de datos
        /// </summary>
        /// <param name="idUserResp"></param>
        /// <param name="idPregunta"></param>
        /// <param name="tituloResp"></param>
        /// <param name="descripcionResp"></param>
        static public void AltaRespuesta(int idUserResp, int idPregunta, string tituloResp, string descripcionResp)
        {
            // Realizar INSERT INTO en la tabla de respuestas
            try
            {
                //Hacer conexion a la base de datos
                Conexion_Desconexion.Connection();
                string query = @"INSERT INTO Respuestas(id_user,id_pregunta,titulo,descripcion) VALUES(@id_user,@id_pregunta,@titulo,@descripcion)";
                SqlCommand command = new SqlCommand(query, Conexion_Desconexion.Con);
                /*NOTA: placeholders.*/
                command.Parameters.AddWithValue("@id_user", idUserResp);
                command.Parameters.AddWithValue("@id_pregunta", idPregunta);
                command.Parameters.AddWithValue("@titulo", tituloResp);
                command.Parameters.AddWithValue("@descripcion", descripcionResp);
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
        /// Realiza un INSERT en la tabla likes
        /// con el id del user y el id de la respuesta
        /// </summary>
        /// <param name="idRespuesta"></param>
        /// <param name="likes"></param>
        static public void AltaLike(int idRespuesta, int idUser)
        {
            try
            {
                Conexion_Desconexion.Connection();
                string query = @"INSERT INTO Likes(id_respuesta, id_user) VALUES(@idResp, @idUser)";
                SqlCommand command = new SqlCommand(query, Conexion_Desconexion.Con);
                command.Parameters.AddWithValue("@idResp", idRespuesta);
                command.Parameters.AddWithValue("@idUser", idUser);
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
        /// Realiza un DELETE en la tabla likes
        /// con el id del user y el id de la respuesta
        /// </summary>
        /// <param name="idRespuesta"></param>
        /// <param name="likes"></param>
        static public void BajaLike(int idRespuesta, int idUser)
        {
            try
            {
                Conexion_Desconexion.Connection();
                string query = @"DELETE FROM Likes WHERE id_repsuesta= @idResp AND id_user = @idUser)";
                SqlCommand command = new SqlCommand(query, Conexion_Desconexion.Con);
                command.Parameters.AddWithValue("@idResp", idRespuesta);
                command.Parameters.AddWithValue("@idUser", idUser);
                command.ExecuteNonQuery();
                Conexion_Desconexion.Desconnect();
            }
            catch (Exception)
            {
                //Nloggear
                throw;
            }
        }

        static public List<int> GetIdsUsuariosLike(int idRespuesta)
        {
            List<int> IdsUsers = new List<int>();
            try { 
                Conexion_Desconexion.Connection();
                string query = @"SELECT id_user FROM Likes WHERE id_respuesta = @idRespuesta";
                SqlCommand command = new SqlCommand(query, Conexion_Desconexion.Con);
                command.Parameters.AddWithValue("@idRespuesta", idRespuesta);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    IdsUsers.Add(reader.GetInt32(0));
                }
                Conexion_Desconexion.Desconnect();

            }
            catch (Exception ex)
            {
                //Nloggear
                throw;
            }
            return IdsUsers;
        }
    }
}