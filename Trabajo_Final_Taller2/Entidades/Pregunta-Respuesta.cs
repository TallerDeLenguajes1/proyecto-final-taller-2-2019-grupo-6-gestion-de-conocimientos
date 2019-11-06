using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pregunta
    {
        List<string> Tags { get; set; }
        int IdSolucion { get; set; }
        DateTime Fecha { get; set; }
        string UrlImagen { get; set; }
        string Descripcion { get; set; }
        string Titulo { get; set; }
        int IdPregunta { get; set; }
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
        int IdRespuesta { get; set; }
        string Titulo { get; set; }
        string Descripcion { get; set; }
        string UrlImagen { get; set; }
        DateTime Fecha { get; set; }
        int Likes { get; set; }

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
