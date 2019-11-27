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
        string url; 
        public VistaImagen(string imgUrl)
        {

            InitializeComponent();

            try
            {
                if (File.Exists(imgUrl))
                {
                    url = imgUrl;
                    var ruta = new Uri(AppDomain.CurrentDomain.BaseDirectory +url, UriKind.Absolute);
                    img_imagen.Source = new BitmapImage(ruta);
                }
                else
                {
                    CargarImagenDefault();
                }
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                CargarImagenDefault();
            }
            catch (System.IO.FileNotFoundException)
            {
                CargarImagenDefault();
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
        
        private void CargarImagenDefault()
        {
            url = @"img\ImageNotFound.jpg";
            var ruta = new Uri(AppDomain.CurrentDomain.BaseDirectory + url, UriKind.Absolute);
            img_imagen.Source = new BitmapImage(ruta);
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
