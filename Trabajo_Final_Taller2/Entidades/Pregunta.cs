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
        public DateTime Fecha { get; set; }
        public string UrlImagen { get; set; }
        public string Descripcion { get; set; }
        public string Titulo { get; set; }
        public List<Respuesta> Respuestas { get; set; }
        public Usuario UserPregunta { get; set; }
        public string Estado { get; set; }

        public int GetMesesDesdeUltimaResp()
        {
            // Consulta en base de datos para obtener la respuesta mas reciente
            int Meses;
            int DiasUltimaResp;
            float PorcentajeDias;
            //Tomo la cantidad de dias que hay en el mes actual en el año actual
            int DiasHoy = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
            //Tomo la fecha de la ultima respuesta cargada
            DateTime ultimaResp = Respuestas.Last().Fecha;
            //Tomo la cantidad de dias que hay en el mes de la ultima respuesta
            DiasUltimaResp = DateTime.DaysInMonth(ultimaResp.Year, ultimaResp.Month);
            //Calculo la diferenicia entre los meses
            Meses = Math.Abs(12 * (DateTime.Today.Year - ultimaResp.Year) + DateTime.Today.Month - ultimaResp.Month) - 1;
            //Calculo el porcentaje de los dias entre los dos meses
            PorcentajeDias = ((DiasHoy - DateTime.Today.Day) / DiasHoy) + (ultimaResp.day / DiasUltimaResp);
            return Meses + PorcentajeDias;
        }
    }
}