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
    /// Lógica de interacción para vistaNotificaciones.xaml
    /// </summary>
    public partial class vistaNotificaciones : Window
    {
        Usuario usuario;
        public vistaNotificaciones(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            lbx_notificaciones.ItemsSource = this.usuario.Notificaciones;
        }
        private void Btn_borrarNotificacion_Click(object sender, RoutedEventArgs e)
        {
            if (lbx_notificaciones.SelectedIndex != -1)
            {
                Notificacion notif = (Notificacion)lbx_notificaciones.SelectedItem;
                ControladorABM.EliminarNotificacion(notif);
                lbx_notificaciones.Items.Refresh();
            }
        }

        private void Btn_irAPregunta_Click(object sender, RoutedEventArgs e)
        {
            if (lbx_notificaciones.SelectedIndex != -1)
            {
                Pregunta pregunta = ((Notificacion)lbx_notificaciones.SelectedItem).PreguntaNotif;
                VistaPregunta vistaPregunta = new VistaPregunta(usuario, pregunta);
                vistaPregunta.ShowDialog();
            }
        }

        private void Btn_atrasNotificaciones_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Brd_border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Lbx_notificaciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Notificacion notifselec = (Notificacion)lbx_notificaciones.SelectedItem;
            lbl_usuario.Content = notifselec.UsuarioPregunta.Nombre;
            lbl_tituloPregunta.Content = notifselec.PreguntaNotif.Titulo;
            lbl_fecha.Content = notifselec.PreguntaNotif.FechaDeUltimaRespuesta().ToShortDateString();
        }
    }
}
