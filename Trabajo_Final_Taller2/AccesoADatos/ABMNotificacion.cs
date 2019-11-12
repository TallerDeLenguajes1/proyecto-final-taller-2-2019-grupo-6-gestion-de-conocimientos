using Entidades;
using System;
using System.Collections.Generic;
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

            // Realizar consulta en la tabla de notificaciones usando idUser

            string query = @"SELECT * FROM Notificaciones WHERE id_user = " + idUser.ToString();

            //
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
