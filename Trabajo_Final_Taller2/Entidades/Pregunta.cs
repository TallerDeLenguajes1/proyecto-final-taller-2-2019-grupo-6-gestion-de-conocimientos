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

        public Pregunta()
        {
            Respuestas = new List<Respuesta>();
        }


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

            mesesTranscurridos = ((DateTime.Today.Year - fechaMasReciente.Year ) - 1) * 12;

            mesesTranscurridos += 12 - DateTime.Today.Month;

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

        public bool EmiteNotificacion()
        {
            if (Estado == "Activa" || Estado == "Inactiva")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AdmiteRespuesta()
        {
            if (Estado == "Activa" || Estado == "Inactiva" || Estado == "Suspendida")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Controla el estado de la pregunta y lo cambia si es necesario
        /// </summary>
        public void ChequearEstado()
        {
            if (Estado == "Activa")
            {
                if (this.GetMesesDesdeUltimaResp() >= 6)
                {
                    Estado = "Inactiva";
                }
            }
            else if (Estado == "Inactiva")
            {
                if (this.GetMesesDesdeUltimaResp() < 6)
                {
                    Estado = "Activa";
                }
            }
        }


        /// <summary>
        /// Retorna true si la pregunta pertenece al usuario especificado,
        /// false de lo contrario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool PerteneceAUsuario(Usuario user)
        {
            if (this.IdUserPregunta == user.IdUsuario)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EstaSolucionada()
        {
            return Estado == "Solucionada";
        }

        public string ToLongString()
        {
            return UserPregunta.ToString() + " ha preguntado " + "\"" + this.ToString() + "\"" + " el día " + Fecha.ToShortDateString() + " a las " + Fecha.ToShortTimeString();
        }

        /// <summary>
        /// Ordena la lista de respuestas por cantidad de likes y la respuesta solucion a la pregunta
        /// </summary>
        public void OrdenarRespuestas()
        {
            Respuestas.Sort(CompararRespuestas);
        }

        public int CompararRespuestas(Respuesta x, Respuesta y)
        {
            if (EstaSolucionada())
            {
                if (x == Solucion)
                {
                    // x es la solucion y tiene prioridad
                    return -1;
                }
                else if (y == Solucion)
                {
                    // y es la solucion y tiene prioridad
                    return 1;
                }
                else
                {
                    // x e y no son la solucion
                    return x.GetCantidadLikes().CompareTo(y.GetCantidadLikes()) * -1;
                }
            }

            return x.GetCantidadLikes().CompareTo(y.GetCantidadLikes()) * -1;
        }
    }
}