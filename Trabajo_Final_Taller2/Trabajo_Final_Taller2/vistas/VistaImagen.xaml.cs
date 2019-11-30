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
using Microsoft.Win32;
using System.IO;
using NLog;

namespace Trabajo_Final_Taller2.vistas
{
    /// <summary>
    /// Interaction logic for VistaImagen.xaml
    /// </summary>
    public partial class VistaImagen : Window
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public VistaImagen(string imgUrl)
        {
            InitializeComponent();

            try
            {
                string rutaAbsolutaImg = HelperImagen.BuscarImagen(imgUrl);

                if (string.IsNullOrEmpty(rutaAbsolutaImg) == false)
                {
                    Uri ruta = new Uri(rutaAbsolutaImg, UriKind.Absolute);
                    img_imagen.Source = new BitmapImage(ruta);
                }
            }
            catch (Exception ex)
            {
                // Log del error
                string error = "Error en VistaImagen";
                error += "\n--------------------\n";
                error += ex.ToString();
                error += "\n--------------------\n";
                logger.Error(error);
                throw;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Brd_border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
