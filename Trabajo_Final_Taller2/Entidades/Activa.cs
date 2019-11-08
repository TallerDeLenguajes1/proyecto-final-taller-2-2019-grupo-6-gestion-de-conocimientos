namespace Entidades
{
    /// <summary>
    /// Clase singleton para estado de pregunta Activa
    /// </summary>
    public class Activa : Estado
    {
        private static Activa instancia;
        private Activa() { }

        /// <summary>
        /// Obtiene la instancia de estado Activa
        /// </summary>
        /// <returns></returns>
        public static Activa GetInstancia()
        {
            if (instancia == null)
            {
                // Instanciar el objeto de la clase si no existe
                instancia = new Activa();
            }
            return instancia;
        }

        /// <summary>
        /// Cambiar el estado de Activa a Suspendida
        /// </summary>
        /// <param name="preg"></param>
        public override void SuspenderPregunta(Pregunta preg)
        {
            preg.SetEstado(Suspendida.GetInstancia());
        }

        /// <summary>
        /// Cambia el estado de Activa a Inactiva si pasaron 6 meses o más desde la ultima respuesta
        /// </summary>
        /// <param name="preg"></param>
        public override void ChequearEstadoSegunUltimaResp(Pregunta preg)
        {
            if (preg.GetMesesDesdeUltimaResp() >= 6)
            {
                preg.SetEstado(Inactiva.GetInstancia());
            }
        }

        /// <summary>
        /// Cambia el estado de Activa a Solucionada
        /// </summary>
        /// <param name="preg"></param>
        public override void MarcarConSolucion(Pregunta preg)
        {
            preg.SetEstado(Solucionada.GetInstancia());
        }

        /// <summary>
        /// Mantiene el estado de Activa
        /// </summary>
        /// <param name="preg"></param>
        public override void RecibirRespuesta(Pregunta preg)
        {

        }

        /// <summary>
        /// Retorna true por ser Activa
        /// </summary>
        /// <returns></returns>
        public override bool EmiteNotificacion()
        {
            return true;
        }

        /// <summary>
        /// Retorna true por ser Activa
        /// </summary>
        /// <returns></returns>
        public override bool AdmiteRespuesta()
        {
            return true;
        }

        /// <summary>
        /// Retorna "Activa"
        /// </summary>
        /// <returns></returns>
        public override string GetTipoEstado()
        {
            return "Activa";
        }
    }
}
