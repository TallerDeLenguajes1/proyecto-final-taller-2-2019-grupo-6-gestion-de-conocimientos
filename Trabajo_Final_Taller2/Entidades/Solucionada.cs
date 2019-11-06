namespace Entidades
{
    /// <summary>
    /// Clase singleton para estado de pregunta Solucionada
    /// </summary>
    public class Solucionada : Estado
    {
        private static Solucionada instancia;
        private Solucionada() { }

        /// <summary>
        /// Obtiene la instancia de estado Solucionada
        /// </summary>
        /// <returns></returns>
        public static Solucionada GetInstancia()
        {
            if (instancia == null)
            {
                // Instanciar el objeto de la clase si no existe
                instancia = new Solucionada();
            }
            return instancia;
        }
        /// <summary>
        /// Mantiene el estado de Solucionada
        /// </summary>
        /// <param name="preg"></param>
        public override void SuspenderPregunta(Pregunta preg)
        {

        }

        /// <summary>
        /// Mantiene el estado de Solucionada
        /// </summary>
        /// <param name="preg"></param>
        public override void ChequearEstadoSegunUltimaResp(Pregunta preg)
        {

        }

        /// <summary>
        /// Mantiene el estado de Solucionada
        /// </summary>
        /// <param name="preg"></param>
        public override void MarcarConSolucion(Pregunta preg)
        {

        }

        /// <summary>
        /// Mantiene el estado de Solucionada
        /// </summary>
        /// <param name="preg"></param>
        public override void RecibirRespuesta(Pregunta preg)
        {

        }

        /// <summary>
        /// Retorna false por ser Solucionada
        /// </summary>
        /// <returns></returns>
        public override bool EmiteNotificacion()
        {
            return false;
        }

        /// <summary>
        /// Retorna false por ser Solucionada
        /// </summary>
        /// <returns></returns>
        public override bool AdmiteRespuesta()
        {
            return false;
        }

        /// <summary>
        /// Retorna "Solucionada"
        /// </summary>
        /// <returns></returns>

        public override string GetTipoEstado()
        {
            return "Solucionada";
        }
    }
}
