using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public class Notificacion
    {
        public int IdUserPregunta { get; set; }
        public int IdPregunta { get; set; }
        public int IdNotificacion { get; set; }
        public Usuario UsuarioPregunta { get; set; }
        public Pregunta PreguntaNotif { get; set; }

        public override string ToString()
        {
            return PreguntaNotif.Titulo + " nueva respuesta el " + PreguntaNotif.FechaDeUltimaRespuesta().ToShortDateString();
        }
    }
}
