using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string PaisOrigen { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public List<Pregunta> preguntas { get; set; }
        public List<Respuesta> respuestas { get; set; }
        public List<Notificacion> notificaciones { get; set; }


        public void CrearPregunta(string titulo, string descripcion, string urlImagen)
        {
            AccesoADatos.ABMPregunta.cargarPregunta(IdUsuario, titulo, descripcion, urlImagen, "activa");
        }
        public void CrearPregunta(string titulo, string descripcion)
        {
            AccesoADatos.ABMPregunta.cargarPregunta(IdUsuario, titulo, descripcion, "activa");
        }
        public void CrearRespuesta(Pregunta pregunta, string titulo, string descripcion, string urlImagen)
        {
            AccesoADatos.ABMRespuesta.cargarRespuesta(IdUsuario, pregunta.id_pregunta, titulo, descripcion, urlImagen);
        }
        public void CrearRespuesta(Pregunta pregunta, string titulo, string descripcion)
        {
            AccesoADatos.ABMPregunta.cargarRespuesta(IdUsuario, pregunta.id_pregunta, titulo, descripcion);
        }
        public void AgregarNotificacion(Notificacion notificacion)
        {
            AccesoADatos.ABMNotificacion.cargarNotificacion(/*todo*/);
        }
        public List<Notificacion> GetNotificaciones()
        {

            AccesoADatos.ABMNotificacion.getNotificaciones(IdUsuario);
        }
        public void BorrarNotificacion(Notificacion notificacion)
        {
            AccesoADatos.ABMNotificacion.borrarNotificacion(/*todo*/);
        }
        public void Like(Respuesta Respuesta)
        {
            respuesta.likes++;
        }
        public void BanHammer()
        {
            AccesoADatos.ABMUsuario.borrarUsuario(IdUsuario);
            //salir de vista
        }
    }
}