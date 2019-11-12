using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    /// <summary>
    /// Clase helper para manejar el acceso a la base de datos
    /// </summary>
    static public class HelperABM
    {

        /// <summary>
        /// Carga la lista de preguntas al objeto usuario 
        /// </summary>
        /// <param name="user"></param>
        static public void CargarListaPreguntas(Usuario user)
        {
            user.Preguntas = ABMPregunta.GetPreguntas(user);
        }

        /// <summary>
        /// Carga la lista de notificaciones al objeto usuario 
        /// </summary>
        /// <param name="user"></param>
        static public void CargarListaNotificaciones(Usuario user)
        {
            user.Notificaciones = ABMNotificacion.GetNotificaciones(user);
        }


        /// <summary>
        /// Carga la lista de respuestas al objeto pregunta 
        /// </summary>
        /// <param name="preg"></param>
        static public void CargarListaRespuestas(Pregunta preg)
        {
            preg.Respuestas = ABMRespuesta.GetRespuestas(preg);
        }


        /// <summary>
        /// Carga la referencia a usuario al objeto respuesta
        /// </summary>
        public static void CargarUser(Respuesta resp)
        {
            resp.UserRespuesta = ABMUsuario.GetUsuario(resp.IdUserResp);
        }
    }
}
