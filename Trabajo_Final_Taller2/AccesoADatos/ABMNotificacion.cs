using Entidades;
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
                    //Completar los campos y agregar a la Bd
                }
                //Cierro la conexion a la Bd
                Conexion_Desconexion.Desconnect();
            }
            catch (Exception)
            {
                //Nloggear
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

            string query = @"INSERT INTO Notificaciones(id_user, id_pregunta) VALUES(@id_user, @id_pregunta)";


            // Reemplazar parametros

        }


        /// <summary>
        /// Elimina de la base de datos la notificacion con el id especificado
        /// </summary>
        /// <param name="idNotificacion"></param>
        static public void BajaNotificacion(int idNotificacion)
        {
            string query = @"DELETE FROM Notificaciones WHERE id_notificacion = " + idNotificacion.ToString();
        }
    }
}
