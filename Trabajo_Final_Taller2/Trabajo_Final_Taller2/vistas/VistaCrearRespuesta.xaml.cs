using AccesoADatos;
using Entidades;
using Microsoft.Win32;
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
        string rutaImagenSeleccionada = string.Empty;

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

        private void btnExaminar_Click(object sender, RoutedEventArgs e)
        {
            rutaImagenSeleccionada = HelperImagen.SeleccionarImagen();
        }

        private void btnResponder_Click(object sender, RoutedEventArgs e)
        {
            if (ValidacionDeCampos())
            {
                string titulo = txbTitulo.Text;
                string descripcion = txbDescripcion.Text;
                string nombreImagen = HelperImagen.GuardarImagen(rutaImagenSeleccionada);

                ControladorABM.ResponderPregunta(usuario, pregunta, titulo, descripcion, nombreImagen);

                this.Close();
            }
        }
        private bool ValidacionDeCampos()
        {
            if (string.IsNullOrWhiteSpace(txbTitulo.Text))
            {
                MessageBox.Show("Campo Titulo invalido");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txbDescripcion.Text))
            {
                MessageBox.Show("Campo Descripcion invalido");
                return false;
            }
            if (txbTitulo.Text.Length > 45)
            {
                MessageBox.Show("El titulo no puede superar los 45 caracteres");
                return false;
            }
            if (txbDescripcion.Text.Length > 250)
            {
                MessageBox.Show("La descripción no puede superar los 45 caracteres");
                return false;
            }

            // Si llega hasta aqui los campos son validos
            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Brd_border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
