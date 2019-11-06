namespace Entidades
{
    /// <summary>
    /// Clase singleton para estado de pregunta Suspendida
    /// </summary>
    public class Suspendida : Estado
    {
        private static Suspendida instancia;
        private Suspendida() { }

        /// <summary>
        /// Obtiene la instancia de estado Suspendida
        /// </summary>
        /// <returns></returns>
        public static Suspendida GetInstancia()
        {
            if (instancia == null)
            {
                // Instanciar el objeto de la clase si no existe
                instancia = new Suspendida();
            }
            return instancia;
        }

        /// <summary>
        /// Mantiene el estado de Suspendida
        /// </summary>
        /// <param name="preg"></param>
        public override void SuspenderPregunta(Pregunta preg)
        {

        }

        /// <summary>
        /// Mantiene el estado de Suspendida
        /// </summary>
        /// <param name="preg"></param>
        public override void ChequearEstadoSegunUltimaResp(Pregunta preg)
        {

        }

        /// <summary>
        /// Mantiene el estado de Suspendida
        /// </summary>
        /// <param name="preg"></param>
        public override void MarcarConSolucion(Pregunta preg)
        {

        }

        /// <summary>
        /// Mantiene el estado de Suspendida
        /// </summary>
        /// <param name="preg"></param>
        public override void RecibirRespuesta(Pregunta preg)
        {

        }

        /// <summary>
        /// Retorna false por ser Suspendida
        /// </summary>
        /// <returns></returns>
        public override bool EmiteNotificacion()
        {
            return false;
        }

        /// <summary>
        /// Retorna true por ser Suspendida
        /// </summary>
        /// <returns></returns>
        public override bool AdmiteRespuesta()
        {
            return true;
        }

        /// <summary>
        /// Retorna "Suspendida"
        /// </summary>
        /// <returns></returns>
        public override string GetTipoEstado()
        {
            return "Suspendida";
        }
    }
}
