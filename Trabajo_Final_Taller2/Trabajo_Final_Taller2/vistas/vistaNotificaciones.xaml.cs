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
    /// Lógica de interacción para vistaNotificaciones.xaml
    /// </summary>
    public partial class vistaNotificaciones : Window
    {
        public vistaNotificaciones()
        {
            InitializeComponent();
        }

        private void Btn_borrarNotificacion_Click(object sender, RoutedEventArgs e)
        {
            var pregunta = lbx_notificaciones.SelectedItem;
            //cambiar estado o algo
        }

        private void Btn_irAPregunta_Click(object sender, RoutedEventArgs e)
        {
            var pregunta = lbx_notificaciones.SelectedItem;
            //en teoria pregunta deberia retornar el objeto contenido en la opcion seleccionada.
            //habria que separarlo y hacer pasaje de parametros a vistaPregunta.
        }

        private void Btn_atrasNotificaciones_Click(object sender, RoutedEventArgs e)
        {
            //como se obtiene la ventana anterior?
        }
    }
}
