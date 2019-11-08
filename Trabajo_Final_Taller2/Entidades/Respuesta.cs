using System;

namespace Entidades
{
    public class Respuesta
    {
        public int IdRespuesta { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string UrlImagen { get; set; }
        public DateTime Fecha { get; set; }
        public int Likes { get; set; }
        public Usuario usuario {get;set;}
        public Pregunta pregunta {get;set;}

        public int GetLikes()
        {
            return Likes;
        }
        public void GenerarNotificacion()
        {
            if (pregunta.EmiteNotificacion == true)
            {
                Notificacion notif = new Notificacion();
            }
        }
        public int GetIdRespuesta()
        {
            return IdRespuesta;
        }
    }
}
