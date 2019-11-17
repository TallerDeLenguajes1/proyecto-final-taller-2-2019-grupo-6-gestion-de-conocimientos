using Entidades;
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
    /// Interaction logic for VistaRespuesta.xaml
    /// </summary>
    public partial class VistaRespuesta : Window
    {
        Usuario usuario;
        Respuesta respuesta;
        public VistaRespuesta(Usuario usuario, Respuesta respuesta)
        {
            InitializeComponent();

            this.usuario = usuario;
            this.respuesta = respuesta;
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
