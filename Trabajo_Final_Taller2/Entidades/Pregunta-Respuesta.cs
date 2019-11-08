using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pregunta
    {
        public List<string> Tags { get; set; }
        public int IdSolucion { get; set; }
        public DateTime Fecha { get; set; }
        public string UrlImagen { get; set; }
        public string Descripcion { get; set; }
        public string Titulo { get; set; }
        public int IdPregunta { get; set; }
        
        Estado estado;

        public Usuario GetUserPregunta()
        {

        }
        public List<Respuesta> GetRespuestas()
        {

        }
        public bool AdmiteRespuesta()
        {

        }
        public bool EmiteNotificacion()
        {

        }
        public void RecibirRespuesta(Respuesta respuesta)
        {

        }
        public void MarcarSolucionada(Respuesta respuesta)
        {

        }
        public void ChequearEstadoSegunUltimaResp()
        {

        }
        public void SuspenderPregunta()
        {

        }
        public string GetTipoEstado()
        {

        }
        public int GetMesesDesdeUltimaPreg()
        {

        }
        public void SetEstado(Estado estado)
        {
            this.estado = estado;
        }
        public void OrdenarRespuestas()
        {

        }
        public void AgregarTag(string tag)
        {

        }
    }
    public class Respuesta
    {
        public int IdRespuesta { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string UrlImagen { get; set; }
        public DateTime Fecha { get; set; }
        public int Likes { get; set; }

        public int GetLikes()
        {
            return 0;
        }
        public void GenerarNotificacion()
        {

        }
        public Pregunta GetPregunta()
        {

        }
        public Usuario GetUserResp()
        {

        }
        public int GetIdRespuesta()
        {

        }
    }
}
