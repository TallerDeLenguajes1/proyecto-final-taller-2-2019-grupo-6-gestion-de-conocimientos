using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Trabajo_Final_Taller2.vistas
{
    /// <summary>
    /// Lógica de interacción para vistaUsuarios.xaml
    /// </summary>
    public partial class vistaUsuarios : Window
    {

        public vistaUsuarios()
        {
            InitializeComponent();
        }
        /// <summary>
        /// cada boton hace practicamente lo mismo
        /// cierra esta ventana y abre la ventana necesaria.
        /// </summary>
        private void Btn_verNotificacion_Click(object sender, RoutedEventArgs e)
        {
            var vistaNotis = new vistaNotificaciones();
            vistaNotis.Show();
            this.Close();
        }

        private void Btn_hacerPregunta_Click(object sender, RoutedEventArgs e)
        {
            var vistaHP = new HacerPregunta();
            vistaHP.Show();
            this.Close();
        }

        private void Btn_verMisPreguntas_Click(object sender, RoutedEventArgs e)
        {
            //las preguntas se ven en la misma ventana, habria que ver como manejar esto...
            var vistaMPreg = new VistaPregunta();
            vistaMPreg.Show();
            this.Close();
        }

        private void Btn_verPreguntas_Click(object sender, RoutedEventArgs e)
        {
            //las preguntas se ven en la misma ventana, habria que ver como manejar esto...
            var vistaMPreg = new VistaPregunta();
            vistaMPreg.Show();
            this.Close();
        }
        private void salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
