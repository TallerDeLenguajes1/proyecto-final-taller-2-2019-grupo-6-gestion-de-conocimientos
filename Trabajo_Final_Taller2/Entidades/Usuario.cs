using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        int IdUsuario { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        string PaisOrigen { get; set; }
        string Email { get; set; }
        string Contraseña { get; set; }
        bool Suspendido { get; set; }

        public void VerNotificaciones()
        {
        }
        public void CrearPregunta(string titulo,string descripcion, string urlImagen)
        {

        }
        public void CrearPregunta(string titulo, string descripcion)
        {

        }
        public void CrearRespuesta(Pregunta pregunta, string titulo, string descripcion, string urlImagen)
        {

        }
        public void CrearRespuesta(Pregunta pregunta, string titulo, string descripcion)
        {

        }
        public void AgregarNotificacion(Notificacion notificacion)
        {

        }
        public List<Notificacion> GetNotificaciones()
        {

        }
        public void BorrarNotificacion(Notificacion notificacion)
        {

        }
        public void Like(Pregunta pregunta)
        {

        }
        public void BanHammer()
        {

        }
    }
}
