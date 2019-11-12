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
        /// Obtiene las notificaciones correspondientes del usuario 
        /// </summary>
        /// <param name="id_user"></param>
        /// <returns></returns>
        static public List<Notificacion> GetNotificaciones(Usuario user)
        {
            List<Notificacion> notificaciones = new List<Notificacion>();

            int id_user = user.IdUsuario;

            // Realizar consulta en la tabla de notificaciones usando id_user

            return notificaciones;
        }
    }
}
