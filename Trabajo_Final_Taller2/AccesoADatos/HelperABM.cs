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
            user.Preguntas = ABMPregunta.GetPreguntas(user.IdUsuario);

            // Asignar la referencia al user para cada una de sus preguntas
            // y cargar sus listas de respuestas
            foreach (Pregunta p in user.Preguntas)
            {
                p.UserPregunta = user;
                CargarListaRespuestas(p);
            }
        }

        /// <summary>
        /// Carga la lista de notificaciones al objeto usuario 
        /// </summary>
        /// <param name="user"></param>
        static public void CargarListaNotificaciones(Usuario user)
        {
            user.Notificaciones = ABMNotificacion.GetNotificaciones(user.IdUsuario);

            // Asignar la referencia al user y las preguntas para cada una de sus notificaciones
            foreach (Notificacion n in user.Notificaciones)
            {
                n.UsuarioPregunta = user;
                n.PreguntaNotif = user.Preguntas.First(p => p.IdPregunta == n.IdPregunta);
            }
        }


        /// <summary>
        /// Carga la lista de respuestas al objeto pregunta 
        /// </summary>
        /// <param name="preg"></param>
        static public void CargarListaRespuestas(Pregunta preg)
        {
            preg.Respuestas = ABMRespuesta.GetRespuestas(preg.IdPregunta);

            // Asignar la referencia a la pregunta para cada una de sus respuestas
            foreach (Respuesta r in preg.Respuestas)
            {
                r.PregRespuesta = preg;
            }
        }


        /// <summary>
        /// Carga la referencia a usuario al objeto respuesta
        /// </summary>
        public static void CargarUser(Respuesta resp)
        {
            resp.UserRespuesta = ABMUsuario.GetUsuario(resp.IdUserResp);
        }


        /// <summary>
        /// Devuelve un usuario con datos y listas cargadas, 
        /// o null si la contraseña y el email no coinciden, 
        /// o no existe el usuario
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static Usuario LoguearUsuario(string email, string password)
        {
            // Chequear si existe el usuario en la base de datos
            if (ABMUsuario.ExisteUser(email))
            {
                return null;
            }
            else
            {
                Usuario user = ABMUsuario.GetUsuario(email);

                // Chequear si coincide la contraseña del usuario
                if (user.Password != password)
                {
                    return null;
                }
                else
                {
                    CargarListaPreguntas(user);
                    CargarListaNotificaciones(user);
                    return user;
                }
            }
        }

        public static void HacerPregunta(Usuario userPregunta, string tituloPreg, string descripcionPreg, string urlImagen)
        {
            // TO DO
        }

        public static void ResponderPregunta(Usuario userRespuesta, Pregunta preg, int idPregunta, string tituloResp, string descripcionResp, string urlImg)
        {
            // TO DO
        }

        public static void DarLike(Usuario userLike, Respuesta resp)
        {
            // TO DO
        }

        public static void EliminarPregunta(Pregunta preg)
        {
            // TO DO
        }

        public static void EliminarRespuesta(Respuesta resp)
        {
            // TO DO
        }

        public static void EliminarNotificacion(Notificacion notif)
        {
            // TO DO
        }

        public static void EliminarCuenta(Usuario user)
        {
            // TO DO
        }

        public static void SolucionarPregunta(Respuesta resp, Pregunta preg)
        {
            // TO DO
        }
    }
}
