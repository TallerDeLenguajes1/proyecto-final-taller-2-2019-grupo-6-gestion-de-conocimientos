using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pregunta
    {
        public int IdPregunta { get; set; }
        public int IdSolucion { get; set; }
        public int IdUserPregunta { get; set; }
        public List<string> Tags { get; set; }
        public DateTime Fecha { get; set; }
        public string UrlImagen { get; set; }
        public string Descripcion { get; set; }
        public string Titulo { get; set; }
        public Usuario User_Pregunta { get; set; }
        public List<Respuesta> Respuestas { get; set; }
        public Respuesta Solucion { get; set; }
        public Estado ElEstado { get; set; }

        /// <summary>
        /// Construye una Pregunta Activa con el dia actual y Solucion en null
        /// </summary>
        public Pregunta()
        {
            Solucion = null;
            ElEstado = Activa.GetInstancia();
            Fecha = DateTime.Today;
            Respuestas = new List<Respuesta>();
        }

        /// <summary>
        /// Devuelte true si la pregunta admite nuevas respuestas
        /// </summary>
        /// <returns></returns>
        public bool AdmiteRespuesta()
        {
            return ElEstado.AdmiteRespuesta();
        }

        /// <summary>
        /// Devuelte true si una respuesta a la pregunta debe emitir notificacion
        /// </summary>
        /// <returns></returns>
        public bool EmiteNotificacion()
        {
            return ElEstado.EmiteNotificacion();
        }

        /// <summary>
        /// Agrega la respuesta a la lista de respuestas de la pregunta y cambia su estado si lo requiere
        /// </summary>
        /// <param name="respuesta"></param>
        public void RecibirRespuesta(Respuesta respuesta)
        {
            Respuestas.Add(respuesta);
            ElEstado.RecibirRespuesta(this);
        }

        /// <summary>
        /// Setea la solucion de la pregunta y cambia el estado a Solucionada
        /// </summary>
        /// <param name="respuesta"></param>
        public void MarcarSolucionada(Respuesta respuesta)
        {
            Solucion = respuesta;
            ElEstado.MarcarConSolucion(this);
        }

        /// <summary>
        /// Chequea si se debe cambiar el estado segun el tiempo transcurrido desde la ultima respuesta
        /// </summary>
        public void ChequearEstadoSegunUltimaResp()
        {
            ElEstado.ChequearEstadoSegunUltimaResp(this);
        }

        /// <summary>
        /// Cambia el estado de la pregunta a Suspendida
        /// </summary>
        public void SuspenderPregunta()
        {
            ElEstado.SuspenderPregunta(this);
        }

        /// <summary>
        /// Devuelve el nombre del tipo de estado de la pregunta
        /// </summary>
        /// <returns></returns>
        public string GetTipoEstado()
        {
            return ElEstado.GetTipoEstado();
        }

        /// <summary>
        /// Devuelve la diferencia en meses entre el dia actual y la fecha de la ultima respuesta recibida
        /// </summary>
        /// <returns></returns>
        public int GetMesesDesdeUltimaResp()
        {
            // Hacer codigo para calcular diferencia en meses
            return 0;
        }

        /// <summary>
        /// Setea el estado de la pregunta
        /// </summary>
        /// <param name="estado"></param>
        public void SetEstado(Estado estado)
        {
            ElEstado = estado;
            // Update en la base de datos
        }

        /// <summary>
        /// Ordena la lista de respuestas según la cantidad de likes
        /// </summary>
        public void OrdenarRespuestas()
        {
            // Hacer un sort de la lista de Respuestas
            // O bien que se haga con SQL
        }

        /// <summary>
        /// Agrega un tag a la lista de tags de la pregunta
        /// </summary>
        /// <param name="tag"></param>
        public void AgregarTag(string tag)
        {
            Tags.Add(tag);
            // Insert en la base de datos
        }
    }
}
