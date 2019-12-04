using Entidades;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public class ABMPregunta
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Selecciona todas las preguntas en la base de datos
        /// </summary>
        /// <returns></returns>
        static public List<Pregunta> GetPreguntas()
        {
            List<Pregunta> preguntas = new List<Pregunta>();
            try
            {
                //Me conecto a la Bd
                Conexion_Desconexion.Connection();
                //Armo el query
                string query = @"SELECT * FROM Preguntas";
                //Armo el command con el query y conexion
                SqlCommand command = new SqlCommand(query, Conexion_Desconexion.Con);
                //Creo un reader que ejecute el query
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //Armo una nueva pregunta con los datos que toma el reader y la cargo a la lista
                    Pregunta preg = new Pregunta();
                    preg.IdUserPregunta = reader.GetInt32(0);
                    preg.IdPregunta = reader.GetInt32(1);
                    if (reader[2] == DBNull.Value)
                    {
                        preg.IdSolucion = -1;
                    }
                    else
                    {
                        preg.IdSolucion = reader.GetInt32(2);
                    }
                    preg.Titulo = reader.GetString(3);
                    preg.Descripcion = reader.GetString(4);
                    if (reader[5] == DBNull.Value)
                    {
                        preg.UrlImagen = null;
                    }
                    else
                    {
                        preg.UrlImagen = reader.GetString(5);
                    }
                    preg.Fecha = reader.GetDateTime(6);
                    preg.Estado = reader.GetString(7);
                    preguntas.Add(preg);
                }
                //Cierro la conexion a la Bd
                Conexion_Desconexion.Desconnect();
            }
            catch (Exception ex)
            {
                // Log del error
                string error = "Error en ABMPregunta GetPreguntas (todas las preguntas del sistema)";
                error += "\n--------------------\n";
                error += ex.ToString();
                error += "\n--------------------\n";
                logger.Error(error);
                throw;
            }
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
            try
            {
                //Hago la conexion a la Bd
                Conexion_Desconexion.Connection();
                //Armo el query
                string query = @"SELECT * FROM Preguntas WHERE id_user = @idUser";
                //Armo el command con el query y la conexion 
                SqlCommand command = new SqlCommand(query, Conexion_Desconexion.Con);
                //Paso el id del usuario por parametro
                command.Parameters.AddWithValue("@idUser", idUser);
                //Armo un reader que ejecute el query
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //Armo una nueva pregunta con los datos que toma el reader y la cargo a la lista
                    Pregunta preg = new Pregunta();
                    preg.IdUserPregunta = reader.GetInt32(0);
                    preg.IdPregunta = reader.GetInt32(1);
                    //Si el valor del campo solucion es nulo, tomo id solucion como -1
                    if (reader[2] == DBNull.Value)
                    {
                        preg.IdSolucion = -1;
                    }
                    else
                    {
                        preg.IdSolucion = reader.GetInt32(2);
                    }
                    preg.Titulo = reader.GetString(3);
                    preg.Descripcion = reader.GetString(4);
                    if (reader[5] == DBNull.Value)
                    {
                        preg.UrlImagen = null;
                    }
                    else
                    {
                        preg.UrlImagen = reader.GetString(5);
                    }
                    preg.Fecha = reader.GetDateTime(6);
                    preg.Estado = reader.GetString(7);
                    preguntasDeUser.Add(preg);
                }
                //Cierro la conexion a la Bd
                Conexion_Desconexion.Desconnect();
            }
            catch (Exception ex)
            {
                // Log del error
                string error = "Error en ABMPregunta GetPreguntas con id (todas las preguntas de un user)";
                error += "\n--------------------\n";
                error += ex.ToString();
                error += "\n--------------------\n";
                logger.Error(error);

                throw;
            }
            return preguntasDeUser;
        }

        /// <summary>
        /// Elimina la pregunta con el id especificaco de la base de datos
        /// </summary>
        /// <param name="idPreg"></param>
        static public void BajaPregunta(int idPregunta)
        {
            try
            {
                //Hago la conexion a la Bd
                Conexion_Desconexion.Connection();
                //Armo el query
                string query = @"DELETE FROM Preguntas WHERE id_pregunta = @idPreg";
                //Armo el command con el query y la conexion
                SqlCommand command = new SqlCommand(query, Conexion_Desconexion.Con);
                //Paso el id de la pregunta por parametro
                command.Parameters.AddWithValue("@idPreg", idPregunta);
                //Ejecuto el query con el command
                command.ExecuteNonQuery();
                //Cierro la conexion a la Bd
                Conexion_Desconexion.Desconnect();
            }
            catch (Exception ex)
            {
                // Log del error
                string error = "Error en ABMPregunta BajaPregunta";
                error += "\n--------------------\n";
                error += ex.ToString();
                error += "\n--------------------\n";
                logger.Error(error);
                throw;
            }
        }

        /// <summary>
        /// Inserta una nueva pregunta con imagen en la base de datos
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="tituloPreg"></param>
        /// <param name="descripcionPreg"></param>
        /// <param name="urlImagen"></param>
        static public void AltaPregunta(int idUser, string tituloPreg, string descripcionPreg, string urlImagen)
        {
            try
            {
                //Conecto a la Bd
                Conexion_Desconexion.Connection();
                //Armo el query
                string query = @"INSERT INTO Preguntas(id_user, titulo, descripcion, url_imagen) VALUES(@id_user, @titulo, @descripcion, @url_imagen)";
                //Armo el command con el query y la conexion
                SqlCommand command = new SqlCommand(query, Conexion_Desconexion.Con);
                //Paso todos los valores por parametros
                command.Parameters.AddWithValue("@id_user", idUser);
                command.Parameters.AddWithValue("@titulo", tituloPreg);
                command.Parameters.AddWithValue("@descripcion", descripcionPreg);
                command.Parameters.AddWithValue("@url_imagen", urlImagen);
                //Ejecuto el comando
                command.ExecuteNonQuery();
                //Cierro la conexion a la Bd
                Conexion_Desconexion.Desconnect();
            }
            catch (Exception ex)
            {
                // Log del error
                string error = "Error en ABMPregunta AltaPregunta con imagen";
                error += "\n--------------------\n";
                error += ex.ToString();
                error += "\n--------------------\n";
                logger.Error(error);
                throw;
            }
        }
        /// <summary>
        /// Inserta una nueva pregunta sin imagen en la base de datos
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="tituloPreg"></param>
        /// <param name="descripcionPreg"></param>
        static public void AltaPregunta(int idUser, string tituloPreg, string descripcionPreg)
        {
            try
            {
                //Conecto a la Bd
                Conexion_Desconexion.Connection();
                //Armo el query
                string query = @"INSERT INTO Preguntas(id_user, titulo, descripcion) VALUES(@id_user, @titulo, @descripcion)";
                //Armo el command con el query y la conexion
                SqlCommand command = new SqlCommand(query, Conexion_Desconexion.Con);
                //Paso todos los valores por parametros
                command.Parameters.AddWithValue("@id_user", idUser);
                command.Parameters.AddWithValue("@titulo", tituloPreg);
                command.Parameters.AddWithValue("@descripcion", descripcionPreg);
                //Ejecuto el comando
                command.ExecuteNonQuery();
                //Cierro la conexion a la Bd
                Conexion_Desconexion.Desconnect();
            }
            catch (Exception ex)
            {
                // Log del error
                string error = "Error en ABMPregunta AltaPregunta sin imagen";
                error += "\n--------------------\n";
                error += ex.ToString();
                error += "\n--------------------\n";
                logger.Error(error);
                throw;
            }
        }

        /// <summary>
        /// Realiza un UPDATE del campo solucion de la pregunta especificada
        /// con el id de la respuesta especificada
        /// </summary>
        /// <param name="idPregunta"></param>
        /// <param name="idRespuesta"></param>
        static public void UpdateSolucionPregunta(int idPregunta, int idRespuesta)
        {
            try
            {
                //Conecto a la Bd
                Conexion_Desconexion.Connection();
                //Armo el query
                string query = @"UPDATE Preguntas SET id_solucion = @idRespuesta, estado = 'Solucionada' WHERE id_pregunta = @idPregunta";
                //Armo el command con el query y la conexion
                SqlCommand command = new SqlCommand(query, Conexion_Desconexion.Con);
                //Paso todos los valores por parametros
                command.Parameters.AddWithValue("@idRespuesta", idRespuesta);
                command.Parameters.AddWithValue("@idPregunta", idPregunta);
                //Ejecuto el comando
                command.ExecuteNonQuery();
                //Cierro la conexion a la Bd
                Conexion_Desconexion.Desconnect();
            }
            catch (Exception ex)
            {
                // Log del error
                string error = "Error en ABMPregunta UpdateSolucionPregunta";
                error += "\n--------------------\n";
                error += ex.ToString();
                error += "\n--------------------\n";
                logger.Error(error);

                throw;
            }
        }

        static public void ActualizarEstado(int idPregunta, string nuevoEstado)
        {
            try
            {
                //Conecto a la Bd
                Conexion_Desconexion.Connection();
                //Armo el query
                string query = @"UPDATE Preguntas SET estado = @nuevoEstado WHERE id_pregunta = @idPregunta";
                //Armo el command con el query y la conexion
                SqlCommand command = new SqlCommand(query, Conexion_Desconexion.Con);
                //Paso todos los valores por parametros
                command.Parameters.AddWithValue("@nuevoEstado", nuevoEstado);
                command.Parameters.AddWithValue("@idPregunta", idPregunta);
                //Ejecuto el comando
                command.ExecuteNonQuery();
                //Cierro la conexion a la Bd
                Conexion_Desconexion.Desconnect();
            }
            catch (Exception ex)
            {
                // Log del error
                string error = "Error en ABMPregunta ActualizarEstado";
                error += "\n--------------------\n";
                error += ex.ToString();
                error += "\n--------------------\n";
                logger.Error(error);

                throw;
            }
        }
    }
}
