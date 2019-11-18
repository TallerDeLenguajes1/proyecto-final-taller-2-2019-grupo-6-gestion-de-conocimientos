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
        public int IdUserPregunta { get; set; }
        public int IdSolucion { get; set; }
        public Respuesta Solucion { get; set; }
        public DateTime Fecha { get; set; }
        public string UrlImagen { get; set; }
        public string Descripcion { get; set; }
        public string Titulo { get; set; }
        public List<Respuesta> Respuestas { get; set; }
        public Usuario UserPregunta { get; set; }
        public string Estado { get; set; }

        /// <summary>
        /// Calcula los meses transcurridos desde la ultima respuesta a esta pregunta
        /// , o los meses desde que se hizo la pregunta si no tiene respuestas
        /// </summary>
        /// <returns></returns>
        public int GetMesesDesdeUltimaResp()
        {
            int mesesTranscurridos = 0;
            DateTime fechaMasReciente = FechaDeUltimaRespuesta();

            // Calcular los meses transcurridos

            mesesTranscurridos = ((fechaMasReciente.Year - this.Fecha.Year) - 1) * 12;

            mesesTranscurridos += 12 - this.Fecha.Month;

            mesesTranscurridos += fechaMasReciente.Month;

            return mesesTranscurridos;
        }

        /// <summary>
        /// Obtiene la fecha de la respuesta mas reciente,
        /// o la fecha de la pregunta si no tiene respuestas
        /// </summary>
        /// <returns></returns>
        public DateTime FechaDeUltimaRespuesta()
        {
            DateTime fechaMasReciente = this.Fecha;
            foreach (var resp in Respuestas)
            {
                if (resp.Fecha > fechaMasReciente)
                {
                    fechaMasReciente = resp.Fecha;
                }
            }
            return fechaMasReciente;
        }


        public override string ToString()
        {
            return Titulo;
        }
    }
}