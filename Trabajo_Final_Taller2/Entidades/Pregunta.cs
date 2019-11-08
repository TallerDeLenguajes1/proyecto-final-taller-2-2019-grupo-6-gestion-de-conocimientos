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
        public DateTime Fecha { get; set; }
        public string UrlImagen { get; set; }
        public string Descripcion { get; set; }
        public string Titulo { get; set; }


        public Estado GetEstado()
        {
            // SELECT columna de estado en la base de datos
            return Activa.GetInstancia(); //return provisorio
        }

        /// <summary>
        /// Devuelte true si la pregunta admite nuevas respuestas
        /// </summary>
        /// <returns></returns>
        public bool AdmiteRespuesta()
        {

            return GetEstado().AdmiteRespuesta();
        }

        /// <summary>
        /// Devuelte true si una respuesta a la pregunta debe emitir notificacion
        /// </summary>
        /// <returns></returns>
        public bool EmiteNotificacion()
        {
            return GetEstado().EmiteNotificacion();
        }

        /// <summary>
        /// Agrega la respuesta a la lista de respuestas de la pregunta y cambia su estado si lo requiere
        /// </summary>
        /// <param name="respuesta"></param>
        public void RecibirRespuesta(Respuesta respuesta)
        {
            // INSERT INTO tabla Respuestas la nueva respuesta
            GetEstado().RecibirRespuesta(this);
        }

        /// <summary>
        /// Setea la solucion de la pregunta y cambia el estado a Solucionada
        /// </summary>
        /// <param name="respuesta"></param>
        public void MarcarConSolucion(Respuesta respuesta)
        {
            //  INSERT INTO tabla respuestas la nueva solucion
            GetEstado().MarcarConSolucion(this);
        }

        /// <summary>
        /// Chequea si se debe cambiar el estado segun el tiempo transcurrido desde la ultima respuesta
        /// </summary>
        public void ChequearEstadoSegunUltimaResp()
        {
            GetEstado().ChequearEstadoSegunUltimaResp(this);
        }

        /// <summary>
        /// Cambia el estado de la pregunta a Suspendida
        /// </summary>
        public void SuspenderPregunta()
        {
            GetEstado().SuspenderPregunta(this);
        }

        /// <summary>
        /// Devuelve el nombre del tipo de estado de la pregunta
        /// </summary>
        /// <returns></returns>
        public string GetTipoEstado()
        {
            return GetEstado().GetTipoEstado();
        }

        /// <summary>
        /// Devuelve la diferencia en meses entre el dia actual y la fecha de la ultima respuesta recibida
        /// </summary>
        /// <returns></returns>
        public int GetMesesDesdeUltimaResp()
        {
            // Consulta en base de datos para obtener la respuesta mas reciente
            int Meses;
            int DiasUltimaResp;
            float PorcentajeDias;
            //Tomo la cantidad de dias que hay en el mes actual en el año actual
            int DiasHoy = DateTime.DaysInMonth(DateTime.Today.Year,DateTime.Today.Month);
            //Tomo la fecha de la ultima respuesta cargada
            DateTime ultimaResp = Respuestas.Last().Fecha;
            //Tomo la cantidad de dias que hay en el mes de la ultima respuesta
            DiasUltimaResp = DateTime.DaysInMonth(ultimaResp.Year,ultimaResp.Month);
            //Calculo la diferenicia entre los meses
            Meses = Math.Abs(12*(DateTime.Today.Year - ultimaResp.Year) + DateTime.Today.Month - ultimaResp.Month) - 1;
            //Calculo el porcentaje de los dias entre los dos meses
            PorcentajeDias = ((DiasHoy - DateTime.Today.Day) / DiasHoy) + (ultimaResp.day / DiasUltimaResp);
            return Meses + PorcentajeDias;
        }

        /// <summary>
        /// Setea el estado de la pregunta
        /// </summary>
        /// <param name="estado"></param>
        public void SetEstado(Estado estado)
        {
            // Update de estado de esta pregunta en la base de datos
        }

        /// <summary>
        /// Ordena la lista de respuestas según la cantidad de likes
        /// </summary>
        public void OrdenarRespuestas()
        {
            // SELECT de respuestas en la base de datos con ORDER BY fecha
        }

        /// <summary>
        /// Agrega un tag a la lista de tags de la pregunta
        /// </summary>
        /// <param name="tag"></param>
        public void AgregarTag(string tag)
        {
            // Insert en la base de datos
        }

        public List<string> GetTags()
        {
            // SELECT de tags en la base de datos
            return new List<string>(); // return provisorio
        }
    }
}
