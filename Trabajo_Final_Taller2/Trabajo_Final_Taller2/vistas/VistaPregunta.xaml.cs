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
            CargarInfoPregunta();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnIrARespuesta_Click(object sender, RoutedEventArgs e)
        {
            if (lbxRespuestas.SelectedIndex != -1)
            {
                Respuesta respuestaSelec = (Respuesta)lbxRespuestas.SelectedItem;
                VistaRespuesta vRespuesta = new VistaRespuesta(usuario, respuestaSelec);
                vRespuesta.ShowDialog();
                CargarInfoPregunta();
            }
        }

        private void CargarInfoPregunta()
        {
            lblInfoUserFecha.Content = pregunta.UserPregunta.ToString() + " el día " + pregunta.Fecha.ToShortDateString() + " a las " + pregunta.Fecha.ToShortTimeString() ;
            lblTitulo.Content = pregunta.Titulo;
            tbkDescripcion.Text = pregunta.Descripcion;

            if (string.IsNullOrWhiteSpace(pregunta.UrlImagen))
            {
                btnVerImagen.IsEnabled = false;
            }
            else
            {
                btnVerImagen.IsEnabled = true;
            }

            lbxRespuestas.ItemsSource = pregunta.Respuestas;

            if (pregunta.AdmiteRespuesta())
            {
                btnResponder.IsEnabled = true;
            }
            else
            {
                btnResponder.IsEnabled = false;
            }

            if (lbxRespuestas.SelectedIndex == -1)
            {
                btnIrARespuesta.IsEnabled = false;
            }
            else
            {
                btnIrARespuesta.IsEnabled = true;
            }
            pregunta.OrdenarRespuestas();
            lbxRespuestas.Items.Refresh();
        }

        private void btnResponder_Click(object sender, RoutedEventArgs e)
        {
            VistaCrearRespuesta vCrearRespuesta = new VistaCrearRespuesta(usuario, pregunta);
            vCrearRespuesta.ShowDialog();
            lbxRespuestas.ItemsSource = pregunta.Respuestas;
            lbxRespuestas.Items.Refresh();
        }

        private void verImg_Click(object sender, RoutedEventArgs e)
        {
            string imgUrl = pregunta.UrlImagen;
            var vistaImg = new VistaImagen(imgUrl);
            vistaImg.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void lbxRespuestas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.CargarInfoPregunta();
        }
    }
}
