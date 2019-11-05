using System;
using System.Collections.Generic;
using System.Text;

namespace entidades
{
    /// <summary>
    /// 
    /// </summary>
    public class Pregunta
    {
        int IdPregunta { get; set; }
        string Titulo { get; set; }
        string UrlImagen { get; set; }
        DateTime Fecha { get; set; }
        bool Solucionada { get; set; }
        int IdSolucion { get; set; }
        List<string> tags { get; set; }

        public usuario GetUserPregunta()
        {
        }
        public List<Respuesta> respuestas()
        {
        }
        public void AgregarRespuesta(Respuesta respuesta)
        {
        }
        public bool AdmiteRespuesta()
        {
        }
        public bool EmiteNotificacion()
        {
        }
        public void MarcarConSolucion(Respuesta solucion)
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
        public int GetMesesDesdeUltimaResp()
        {
        }
        public void SetEstado(Estado estado)
        {
        }
        public void SetSolucion(Respuesta solucion)
        {
        }
        public void OrdenarRespuestas()
        {
        }
    }
    /// <summary>
    /// 
    /// </summary>
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
            return Likes;
        }
        public void GenerarNotificacion()
        {
        }
        public Pregunta GetPregunta()
        {
        }
        public usuario GetUsuarioRespuesta()
        {
        }
    }
}
