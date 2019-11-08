using System;

namespace Entidades
{
    public class Respuesta
    {
        public int IdRespuesta { get; set; }
        public int IdUserResp { get; set; }
        public int IdPregunta { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string UrlImagen { get; set; }
        public DateTime Fecha { get; set; }
        public int Likes { get; set; }
        public Usuario UserRespuesta {get;set;}
        public Pregunta LaPregunta {get;set;}

        /// <summary>
        /// Genera una nueva notificacion y se la agrega al usuario que hizo la pregunta 
        /// sólo si es necesario generar una notificacion
        /// </summary>
        public void GenerarNotificacion()
        {
            if (LaPregunta.EmiteNotificacion() == true)
            {
                Notificacion notif = new Notificacion();

                LaPregunta.User_Pregunta.AgregarNotificacion(notif);
                // Insertar notificacion en la base de datos
            }
        }
    }
}
