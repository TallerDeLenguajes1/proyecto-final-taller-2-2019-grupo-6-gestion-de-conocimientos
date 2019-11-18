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
            CargarComponentes();
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
            }
        }

        private void CargarComponentes()
        {
            lblTitulo.Content = pregunta.Titulo;
            tbkDescripcion.Text = pregunta.Descripcion;

            if (pregunta.UrlImagen == null)
            {
                btnVerImagen.IsEnabled = false;
            }
            else
            {
                btnVerImagen.IsEnabled = true;
                // TO DO
                // Vincular boton con la imagen
            }

            lbxRespuestas.ItemsSource = pregunta.Respuestas;
        }

        private void btnResponder_Click(object sender, RoutedEventArgs e)
        {
            VistaCrearRespuesta vCrearRespuesta = new VistaCrearRespuesta(usuario, pregunta);
            vCrearRespuesta.ShowDialog();
            lbxRespuestas.ItemsSource = pregunta.Respuestas;
            lbxRespuestas.Items.Refresh();
        }
    }
}
