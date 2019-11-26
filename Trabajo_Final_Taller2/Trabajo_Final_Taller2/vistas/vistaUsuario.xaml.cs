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
            VistaLogin vistaLogin = new VistaLogin();
            vistaLogin.Show();
            this.Close();
        }

        private void reporte_Click(object sender, RoutedEventArgs e)
        {
            HacerReporte();
        }
        public void HacerReporte()
        {
            ///nombre de archivo: nombre de usuario con fecha y horario
            ///en las tablas
            ///preguntas | cantidad de respuestas de cada pregunta | estado de la pregunta
            /// y tal vez tambien de cada pregunta
            ///respuestas | fecha | nombre del user que hizo la respuesta | cantidad de likes de la respuesta |
            
            var fecha = DateTime.Now.ToString("yyyy-MM-dd / HH:mm:ss:ms");
            var fechaMod = fecha.Replace(" ", "").Replace("/", "-").Replace(":", "-").Replace("+", "");
            string fileName = usuario.Nombre + "" + usuario.Apellido + fechaMod;
            //crea el documento
            WorkBook xlsxWorkbook = WorkBook.Create(ExcelFileFormat.XLSX);
            xlsxWorkbook.Metadata.Author = "IronXL";
            //Add a blank WorkSheet
            WorkSheet xlsSheet = xlsxWorkbook.CreateWorkSheet("main_sheet");
            //Add data and styles to the new worksheet
            xlsSheet["A1"].Value = "Usuario";
            xlsSheet["B1"].Value = "Preguntas";
            xlsSheet["C1"].Value = "Cantidad de respuestas";
            xlsSheet["D1"].Value = "Estado de la pregunta";
            foreach (var preg in usuario.Preguntas)
            {
                int row = 2;
                xlsSheet["A" + row].Value = usuario.Nombre + " " + usuario.Apellido;
                xlsSheet["B" + row].Value = preg.Titulo;
                xlsSheet["C" + row].Value = preg.Respuestas.Count;
                xlsSheet["D" + row].Value = preg.Estado;
                row++;
            }
            //Save the excel file
            xlsxWorkbook.SaveAs(fileName + ".xlsx");

        }
        private void Brd_border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
