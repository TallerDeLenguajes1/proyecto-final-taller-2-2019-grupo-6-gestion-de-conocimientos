using System;

namespace entidades
{
    public abstract class usuario
    {
        string apellido { get; set; }
        string nombre { get; set; }
        string pais { get; set; }
        string email { get; set; }
        string password { get; set; }
        bool suspendido { get; set; }

        public void verNotificacion()
        {
        
        }
        public void crearPregunta(string titulo, string descripcion, string url_imagen)
        {
            
        }
        public void crearPregunta(string titulo, string descripcion)
        {

        }
        public void crearRespuesta(/*pregunta,*/string titulo, string drescipcion, string url_imagen)
        {

        }
        public void crearRespuesta(/*pregunta,*/string titulo, string drescipcion)
        {

        }
        public void agregarNotificacion(/*notificacion*/)
        {

        }
        public void getNotificacion()
        {

        }
        public void borrarNotificacion(/*notificacion*/)
        {

        }
        public void darLike(/*pregunta*/)
        {

        }
        public void banear()
        {

        }
    }
}
