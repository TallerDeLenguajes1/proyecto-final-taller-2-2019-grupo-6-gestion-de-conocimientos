using Entidades;
using HelperArchivos;
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
    /// Lógica de interacción para VerPreguntas.xaml
    /// </summary>
    public partial class VerPreguntas : Window
    {
        Usuario usuario;
        List<Pregunta> preguntas;

        public VerPreguntas(Usuario user, List<Pregunta> pregs)
        {
            InitializeComponent();
            usuario = user;
            preguntas = pregs;
            lbx_Preguntas.ItemsSource = pregs;
            CargarInfoPregunta();
        }

        private void btn_Regresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnIrAPregunta_Click(object sender, RoutedEventArgs e)
        {
            if (lbx_Preguntas.SelectedIndex != -1)
            {
                // Pregunta seleccionada
                Pregunta preguntaSelec = (Pregunta)lbx_Preguntas.SelectedItem;
                VistaPregunta vistaPregunta = new VistaPregunta(usuario, preguntaSelec);
                vistaPregunta.ShowDialog();
                CargarInfoPregunta();
            }
        }

        private void Lbx_Preguntas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CargarInfoPregunta();
        }

        private void Brd_border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CargarInfoPregunta()
        {
            if (lbx_Preguntas.Items.Count == 0)
            {
                lblInfoPregunta.Content = "No hay preguntas";
                lblEstado.Content = string.Empty;
                btnIrAPregunta.IsEnabled = false;
            }
            else
            {
                if (lbx_Preguntas.SelectedIndex == -1)
                {
                    lblInfoPregunta.Content = "Seleccione una pregunta";
                    lblEstado.Content = string.Empty;
                    btnIrAPregunta.IsEnabled = false;
                }
                else
                {
                    Pregunta preguntaSelec = (Pregunta)lbx_Preguntas.SelectedItem;

                    lblInfoPregunta.Content = preguntaSelec.ToLongString();
                    lblEstado.Content = "Estado: " + preguntaSelec.Estado;
                    btnIrAPregunta.IsEnabled = true;
                }
            }
        }

        private void btnReporte_Click(object sender, RoutedEventArgs e)
        {
            string rutaArchivo = HelperReportes.GenerarReportePreguntas(this.preguntas);

            if (string.IsNullOrEmpty(rutaArchivo))
            {
                MessageBox.Show("No se pudo generar el reporte", "Reporte preguntas", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Reporte generado exitosamente en " + rutaArchivo , "Reporte preguntas", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
