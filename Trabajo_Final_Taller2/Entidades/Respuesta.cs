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

        public int GetLikes()
        {
            return 0;
        }
        public void GenerarNotificacion()
        {

        }
        public Pregunta GetPregunta()
        {

        }
        public Usuario GetUserResp()
        {

        }
        public int GetIdRespuesta()
        {

        }
    }
}
