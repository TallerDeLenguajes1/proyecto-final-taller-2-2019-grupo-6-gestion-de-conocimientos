namespace Entidades
{
    /// <summary>
    /// Clase singleton para estado de pregunta Inactiva
    /// </summary>
    public class Inactiva : Estado
    {
        private static Inactiva instancia;
        private Inactiva() { }

        /// <summary>
        /// Obtiene la instancia de estado Inactiva
        /// </summary>
        /// <returns></returns>
        public static Inactiva GetInstancia()
        {
            if (instancia == null)
            {
                // Instanciar el objeto de la clase si no existe
                instancia = new Inactiva();
            }
            return instancia;
        }

        /// <summary>
        /// Cambia el estado de Inactiva a Suspendida
        /// </summary>
        /// <param name="preg"></param>
        public override void SuspenderPregunta(Pregunta preg)
        {
            preg.SetEstado(Suspendida.GetInstancia());
        }

        /// <summary>
        /// Mantiene el estado de Inactiva
        /// </summary>
        /// <param name="preg"></param>
        public override void ChequearEstadoSegunUltimaResp(Pregunta preg)
        {

        }

        /// <summary>
        /// Cambia el estado de Inactiva a Solucionada
        /// </summary>
        /// <param name="preg"></param>
        public override void MarcarConSolucion(Pregunta preg)
        {
            preg.SetEstado(Solucionada.GetInstancia());
        }

        /// <summary>
        /// Cambia el estado de Inactiva a Activa
        /// </summary>
        /// <param name="preg"></param>
        public override void RecibirRespuesta(Pregunta preg)
        {
            preg.SetEstado(Activa.GetInstancia());
        }

        /// <summary>
        /// Retorna true por ser Inactiva
        /// </summary>
        /// <returns></returns>
        public override bool EmiteNotificacion()
        {
            return true;
        }

        /// <summary>
        /// Retorna true por ser Inactiva
        /// </summary>
        /// <returns></returns>
        public override bool AdmiteRespuesta()
        {
            return true;
        }

        /// <summary>
        /// Retorna "Inactiva"
        /// </summary>
        /// <returns></returns>
        public override string GetTipoEstado()
        {
            return "Inactiva"; 
        }
    }
}
