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
        public DateTime FechaIngreso { get; set; }
        public string Password { get; set; }
        public List<Pregunta> Preguntas { get; set; }
        public List<Notificacion> Notificaciones { get; set; }
    }
}