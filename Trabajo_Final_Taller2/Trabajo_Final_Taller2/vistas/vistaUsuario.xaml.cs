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
using AccesoADatos;
using Entidades;
using HelperArchivos;
using IronXL;

namespace Trabajo_Final_Taller2.vistas
{
    /// <summary>
    /// Lógica de interacción para vistaUsuarios.xaml
    /// </summary>
    public partial class vistaUsuarios : Window
    {
        Usuario usuario;
        public vistaUsuarios(Usuario user)
        {
            InitializeComponent();
            lbl_name.Content = user.Nombre + " está en sesión.";
            usuario = user;
        }
        
        /// <summary>
        /// cada boton hace practicamente lo mismo
        /// cierra esta ventana y abre la ventana necesaria.
        /// </summary>
        private void Btn_verNotificacion_Click(object sender, RoutedEventArgs e)
        {
            var vistaNotis = new vistaNotificaciones(usuario);
            vistaNotis.ShowDialog();
        }

        private void Btn_hacerPregunta_Click(object sender, RoutedEventArgs e)
        {
            var vistaHP = new HacerPregunta(usuario);
            vistaHP.ShowDialog();
        }

        private void Btn_verMisPreguntas_Click(object sender, RoutedEventArgs e)
        {
            //las preguntas se ven en la misma ventana, habria que ver como manejar esto...
            var vistaMPreg = new VerPreguntas(usuario, usuario.Preguntas);
            vistaMPreg.ShowDialog();
        }

        private void Btn_verPreguntas_Click(object sender, RoutedEventArgs e)
        {
            // Hacer consulta para obtener las preguntas
            List<Pregunta> preguntas = ControladorABM.ObtenerTodasLasPreguntas();
            var vistaMPreg = new VerPreguntas(usuario, preguntas);
            vistaMPreg.ShowDialog();
        }
        private void salir_Click(object sender, RoutedEventArgs e)
        {
            CerrarSesion();
        }
        private void CerrarSesion()
        {
            VistaLogin vistaLogin = new VistaLogin();
            vistaLogin.Show();
            this.Close();
        }
        private void reporte_Click(object sender, RoutedEventArgs e)
        {
            HelperReportes.GenerarReporteUsuario(usuario);
        }
        private void Brd_border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_borrar_cuenta_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "¿Está seguro que quiere borrar su cuenta?", 
                "Borrar Cuenta", 
                MessageBoxButton.YesNo, 
                MessageBoxImage.Warning
                );

            if (result == MessageBoxResult.Yes)
            {
                ControladorABM.EliminarCuenta(usuario);
                CerrarSesion();
            }
        }
    }
}
