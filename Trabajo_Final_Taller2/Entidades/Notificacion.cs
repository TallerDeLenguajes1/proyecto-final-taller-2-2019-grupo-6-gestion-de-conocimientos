using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Notificacion
    {
        public int IdUserPregunta { get; set; }
        public int IdRespuesta { get; set; }

        public Usuario GetUserPregunta()
        {
            // Select del usuario que recibe la notificacion
            return new Usuario(); // return provisorio
        }
        public Respuesta GetRespuesta()
        {
            // Select de la respuesta recibida
            return new Respuesta(); // return provisorio
        }
    }
}
