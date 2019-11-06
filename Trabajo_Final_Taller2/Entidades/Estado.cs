using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase abstracta Estado para manejar los cambios de estado de una Pregunta
    /// </summary>
    public abstract class Estado
    {
        /// <summary>
        /// Delegar el cambio de estado de la pregunta al Estado concreto
        /// </summary>
        /// <param name="preg"></param>
        abstract public void SuspenderPregunta(Pregunta preg);
        /// <summary>
        /// Delegar el cambio de estado de la pregunta al Estado concreto
        /// </summary>
        /// <param name="preg"></param>
        abstract public void ChequearEstadoSegunUltimaResp(Pregunta preg);
        /// <summary>
        /// Delegar el cambio de estado de la pregunta al Estado concreto
        /// </summary>
        /// <param name="preg"></param>
        abstract public void MarcarConSolucion(Pregunta preg);
        /// <summary>
        /// Delegar el cambio de estado de la pregunta al Estado concreto
        /// </summary>
        /// <param name="preg"></param>
        abstract public void RecibirRespuesta(Pregunta preg);
        /// <summary>
        /// Devuelve true si la pregunta emite notificacion según el estado
        /// </summary>
        /// <returns></returns>
        abstract public bool EmiteNotificacion();
        /// <summary>
        /// Devuelte true si la pregunta admite respuesta según el estado
        /// </summary>
        /// <returns></returns>
        abstract public bool AdmiteRespuesta();
        /// <summary>
        /// Devuelve el nombre del tipo de estado actual
        /// </summary>
        /// <returns></returns>
        abstract public string GetTipoEstado();
    }
}
