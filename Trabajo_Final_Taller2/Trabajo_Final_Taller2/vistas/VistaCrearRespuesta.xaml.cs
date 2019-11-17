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
    /// Interaction logic for VistaCrearRespuesta.xaml
    /// </summary>
    public partial class VistaCrearRespuesta : Window
    {
        Usuario usuario;
        Pregunta pregunta;

        public VistaCrearRespuesta(Usuario usuario, Pregunta pregunta)
        {
            InitializeComponent();

            this.usuario = usuario;
            this.pregunta = pregunta;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
