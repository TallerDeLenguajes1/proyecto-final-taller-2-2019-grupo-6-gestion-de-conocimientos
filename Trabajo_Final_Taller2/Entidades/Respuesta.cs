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

        /// <summary>
        /// Genera una nueva notificacion y se la agrega al usuario que hizo la pregunta 
        /// sólo si es necesario generar una notificacion
        /// </summary>
        public void GenerarNotificacion()
        {
            // LaPregunta = SELECT de la pregunta 
            Pregunta LaPregunta = new Pregunta();
            if (LaPregunta.EmiteNotificacion() == true)
            {
                // Insertar notificacion en la base de datos
            }
        }
        public void RecibirLike()
        {
            Likes++;
            // UPDATE columna de likes en la base de datos
        }

        public Usuario GetUserRespuesta()
        {
            // SELECT del usuario que hizo esta respuesta
            return new Usuario(); //return provisorio
        }
        public Pregunta GetPregunta()
        {
            // SELECT de la pregunta a la que se respondio
            return new Pregunta(); //return provisorio
        }
    }
}
