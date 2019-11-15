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
                ABMUsuario.GetUsuario(r.IdUserResp); // Cargar usuario que hizo la respuesta
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

        /// <summary>
        /// Crea una nueva pregunta en la base de datos y recarga la lista de preguntas del usuario
        /// </summary>
        /// <param name="userPregunta"></param>
        /// <param name="tituloPreg"></param>
        /// <param name="descripcionPreg"></param>
        /// <param name="urlImagen"></param>
        public static void HacerPregunta(Usuario userPregunta, string tituloPreg, string descripcionPreg, string urlImagen)
        {
            // Alta en base de datos
            ABMPregunta.AltaPregunta(userPregunta.IdUsuario, tituloPreg, descripcionPreg, urlImagen);

            // Recarga la lista de preguntas
            CargarListaPreguntas(userPregunta);
        }

        /// <summary>
        /// Crea una nueva respuesta en la base de datos y una notificacion si es necesaria, 
        /// y recarga la lista de respuestas de la pregunta
        /// </summary>
        /// <param name="userRespuesta"></param>
        /// <param name="preg"></param>
        /// <param name="idPregunta"></param>
        /// <param name="tituloResp"></param>
        /// <param name="descripcionResp"></param>
        /// <param name="urlImg"></param>
        public static void ResponderPregunta(Usuario userRespuesta, Pregunta preg, int idPregunta, string tituloResp, string descripcionResp, string urlImg)
        {
            ABMRespuesta.AltaRespuesta(userRespuesta.IdUsuario, preg.IdPregunta, tituloResp, descripcionResp, urlImg);

            CargarListaRespuestas(preg);
        }

        /// <summary>
        /// Actualiza el valor de los likes en la base de datos
        /// y en la respuesta
        /// </summary>
        /// <param name="userLike"></param>
        /// <param name="resp"></param>
        public static void DarLike(Usuario userLike, Respuesta resp)
        {
            ABMRespuesta.UpdateLikes(resp.IdRespuesta, resp.Likes + 1);
            resp.Likes++;
        }

        /// <summary>
        /// Elimina una pregunta de la base de datos
        /// y la quita de la lista de preguntas del usuario
        /// </summary>
        /// <param name="preg"></param>
        public static void EliminarPregunta(Pregunta preg)
        {
            ABMPregunta.BajaPregunta(preg.IdPregunta);
            preg.UserPregunta.Preguntas.Remove(preg);
        }

        /// <summary>
        /// Elimina una respuesta de la base de datos
        /// y la quita de la lista de respuestas de la pregunta
        /// </summary>
        /// <param name="resp"></param>
        public static void EliminarRespuesta(Respuesta resp)
        {
            ABMRespuesta.BajaRespuesta(resp.IdRespuesta);
            resp.PregRespuesta.Respuestas.Remove(resp);
        }

        /// <summary>
        /// Elimina una notificacion de la base de datos 
        /// y la quita de la lista de notificaciones del usuario
        /// </summary>
        /// <param name="notif"></param>
        public static void EliminarNotificacion(Notificacion notif)
        {
            ABMNotificacion.BajaNotificacion(notif.IdNotificacion);
            notif.UsuarioPregunta.Notificaciones.Remove(notif);
        }


        /// <summary>
        /// Elimina al usuario de la base de datos
        /// </summary>
        /// <param name="user"></param>
        public static void EliminarCuenta(Usuario user)
        {
            ABMUsuario.BajaUsuario(user.IdUsuario);
        }

        /// <summary>
        /// Actualiza la base de datos en la pregunta
        /// con la respuesta seleccionada
        /// y vincula la referencia a la solucion en la pregunta
        /// </summary>
        /// <param name="resp"></param>
        /// <param name="preg"></param>
        public static void SolucionarPregunta(Respuesta resp, Pregunta preg)
        {
            ABMPregunta.UpdateSolucionPregunta(preg.IdPregunta, resp.IdRespuesta);
            preg.Solucion = resp;
            preg.IdSolucion = resp.IdRespuesta;
        }
    }
}
