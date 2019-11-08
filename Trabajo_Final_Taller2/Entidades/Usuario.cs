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
        public DateTime FechaIngreso { get; set; }

        public void CrearPregunta(string titulo, string descripcion, string urlImagen)
        {
            // Insert nueva pregunta en base de datos
            // AccesoADatos.ABMPregunta.cargarPregunta(IdUsuario, titulo, descripcion, urlImagen, "activa");
        }
        public void CrearRespuesta(Pregunta pregunta, string titulo, string descripcion, string urlImagen)
        {
            // Insert nueva respuesta en base de datos
            // AccesoADatos.ABMRespuesta.cargarRespuesta(IdUsuario, pregunta.id_pregunta, titulo, descripcion, urlImagen);
        }
        public List<Pregunta> GetPreguntas()
        {
            // SELECT de preguntas de este usuario en la base de datos
            return new List<Pregunta>();
        }
        public List<Respuesta> GetRespuestas()
        {
            // SELECT de respuestas de este usuario en la base de datos
            return new List<Respuesta>();
        }
        public void AgregarNotificacion(Notificacion notificacion)
        {
            // Insert into?
            // La clase respuesta ya se ocupa de la insercion en la base de datos
            // No haria falta en esta clase
            // AccesoADatos.ABMNotificacion.cargarNotificacion(/*todo*/);
        }
        public List<Notificacion> GetNotificaciones()
        {
            // SELECT de notificaciones de este usuario en la base de datos
            // AccesoADatos.ABMNotificacion.getNotificaciones(IdUsuario);
            return new List<Notificacion>();
        }
        public void BorrarNotificacion(Notificacion notificacion)
        {
            // DELETE de notificacion en la base de datos
            // AccesoADatos.ABMNotificacion.borrarNotificacion(/*todo*/);
        }
        public void Like(Respuesta Respuesta)
        {
            // UPDATE likes de la respuesta en la base de datos
            // 
        }
        public void BanHammer()
        {
            // DELETE del usuario en la base de datos
            // AccesoADatos.ABMUsuario.borrarUsuario(IdUsuario);
            //salir de vista
        }
    }
}