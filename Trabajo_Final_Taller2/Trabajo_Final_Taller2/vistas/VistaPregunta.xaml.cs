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
    /// Lógica de interacción para VistaPregunta.xaml
    /// </summary>
    public partial class VistaPregunta : Window
    {
        Usuario usuario;
        Pregunta pregunta;
        public VistaPregunta(Usuario user, Pregunta pregunta)
        {
            InitializeComponent();
            usuario = user;
            this.pregunta = pregunta;
            lbxRespuestas.ItemsSource = this.pregunta.Respuestas;
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void irARespuesta_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
