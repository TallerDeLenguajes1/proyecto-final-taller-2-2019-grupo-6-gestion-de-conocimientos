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
    public class ABMNotificacion
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Obtiene las notificaciones correspondientes del usuario con el id especificado
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        static public List<Notificacion> GetNotificaciones(int idUser)
        {
            List<Notificacion> notificaciones = new List<Notificacion>();
            try
            {
                //Hago la conexion a la base de datos
                Conexion_Desconexion.Connection();
                //Armo el query para seleccionar todas las notificaciones segun el id
                string query = @"SELECT * FROM Notificaciones WHERE id_user = @idUser";
                //Armo el command con el query y la conexion
                SqlCommand command = new SqlCommand(query, Conexion_Desconexion.Con);
                //Paso como parametro codificado el id del usuario
                command.Parameters.AddWithValue("@idUser", idUser);
                //Ejecuto un reader que va a tomar toda la informacion de la tabla correspondiendo a la condicion impuesta en el query
                SqlDataReader reader = command.ExecuteReader();
                //Mientras voy leyendo los datos, los tomo y armo una notificacion que luego agrego a la lista de notificaciones
                while (reader.Read())
                {
                    Notificacion notif = new Notificacion();
                    notif.IdUserPregunta = reader.GetInt32(0);
                    notif.IdPregunta = reader.GetInt32(1);
                    notif.IdNotificacion = reader.GetInt32(2);
                    notificaciones.Add(notif);
                }
                //Cierro la conexion a la Bd
                Conexion_Desconexion.Desconnect();
            }
            catch (Exception ex)
            {
                // Log del error
                string error = "Error en ABMNotificacion GetNotificaciones";
                error += "\n--------------------\n";
                error += ex.ToString();
                error += "\n--------------------\n";
                logger.Error(error);
                throw;
            }
            //Finalmente devuelvo la lista de notificaciones
            return notificaciones;
        }

        /// <summary>
        /// Inserta una nueva notificacion en la base de datos
        /// </summary>
        /// <param name="idUserPregunta"></param>
        /// <param name="idPregunta"></param>
        static public void AltaNotificacion(int idUserPregunta, int idPregunta)
        {
            try
            {
                //Hago la conexion a la Bd
                Conexion_Desconexion.Connection();
                //Armo el query para el command
                string query = @"INSERT INTO Notificaciones(id_user, id_pregunta) VALUES(@id_user, @id_pregunta)";
                //Armo mi command con el query y la conexion
                SqlCommand command = new SqlCommand(query, Conexion_Desconexion.Con);
                //Paso los ids codificados por parametro
                command.Parameters.AddWithValue("@id_user",idUserPregunta);
                command.Parameters.AddWithValue("@id_pregunta", idPregunta);
                //Ejecuto el query
                command.ExecuteNonQuery();
                //Desconecto la base de datos
                Conexion_Desconexion.Desconnect();
            }
            catch (Exception ex)
            {
                // Log del error
                string error = "Error en ABMNotificacion AltaNotificacion";
                error += "\n--------------------\n";
                error += ex.ToString();
                error += "\n--------------------\n";
                logger.Error(error);
                throw;
            }

        }


        /// <summary>
        /// Elimina de la base de datos la notificacion con el id especificado
        /// </summary>
        /// <param name="idNotificacion"></param>
        static public void BajaNotificacion(int idNotificacion)
        {
            try
            {
                //Hago la conexion a la Bd
                Conexion_Desconexion.Connection();
                //Armo el query
                string query = @"DELETE FROM Notificaciones WHERE id_notificacion = @idNotif";
                //Genero el command
                SqlCommand command = new SqlCommand(query, Conexion_Desconexion.Con);
                //Paso el id de la notif como parametro
                command.Parameters.AddWithValue("idNotif",idNotificacion);
                //Ejecuto el query
                command.ExecuteNonQuery();
                //Cierro la conexion a la Bd
                Conexion_Desconexion.Desconnect();

            }
            catch (Exception ex)
            {
                // Log del error
                string error = "Error en ABMNotificacion BajaNotificacion";
                error += "\n--------------------\n";
                error += ex.ToString();
                error += "\n--------------------\n";
                logger.Error(error);
                throw;
            }
        }
    }
}
