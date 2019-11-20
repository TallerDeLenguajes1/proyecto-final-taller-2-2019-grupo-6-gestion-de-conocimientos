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

namespace Trabajo_Final_Taller2.vistas
{
    /// <summary>
    /// Interaction logic for VistaImagen.xaml
    /// </summary>
    public partial class VistaImagen : Window
    {
        string url; 
        public VistaImagen(Pregunta preg)
        {

            InitializeComponent();
            url = preg.UrlImagen;
            MessageBox.Show(url);
            img_imagen.Source = new BitmapImage(new Uri(url,UriKind.Relative));

        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
