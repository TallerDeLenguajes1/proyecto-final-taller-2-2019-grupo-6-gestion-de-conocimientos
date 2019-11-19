using AccesoADatos;
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

            CargarComponentes();
        }
        private void CargarComponentes()
        {
            // Actualizar boton de like
            if (respuesta.DioLike(usuario))
            {
                btnLike.Content = "Dislike";
            }
            else
            {
                btnLike.Content = "Like";
            }

            // Verificar si el usuario logueado puede marcar como solucion a la respuesta
            Pregunta pregRespondida = respuesta.PregRespuesta;
            if (pregRespondida.EstaSolucionada() == false && pregRespondida.PerteneceAUsuario(usuario))
            {
                btnSolucion.IsEnabled = true;
            }
            else
            {
                btnSolucion.IsEnabled = false;
            }


            // Boton de ver imagen
            if (respuesta.UrlImagen == null)
            {
                btnVerImagen.IsEnabled = false;
            }
            else
            {
                btnVerImagen.IsEnabled = true;
            }

            // Cargar informacion de la respuesta
            lblTitulo.Content = respuesta.Titulo;
            lblNombre.Content = respuesta.UserRespuesta.Nombre + " " + respuesta.UserRespuesta.Apellido;
            lblFecha.Content = respuesta.Fecha.ToShortDateString();
            tbkDescripcion.Text = respuesta.Descripcion;

        }
        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLike_Click(object sender, RoutedEventArgs e)
        {
            if (respuesta.DioLike(usuario))
            {
                ControladorABM.DarDisike(usuario, respuesta);
            }
            else
            {
                ControladorABM.DarLike(usuario, respuesta);
            }
            CargarComponentes();
        }

        private void btnSolucion_Click(object sender, RoutedEventArgs e)
        {
            // Verificar si el usuario logueado puede marcar como solucion a la respuesta
            Pregunta pregRespondida = respuesta.PregRespuesta;
            if (pregRespondida.EstaSolucionada() == false && pregRespondida.PerteneceAUsuario(usuario))
            {
                ControladorABM.SolucionarPregunta(respuesta, pregRespondida);
                CargarComponentes();
            }
        }
    }
}
