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
    /// Lógica de interacción para HacerPregunta.xaml
    /// </summary>
    public partial class HacerPregunta : Window
    {
        public HacerPregunta()
        {
            InitializeComponent();
        }

        private void preguntar_Click(object sender, RoutedEventArgs e)
        {
            //obtener id user
            int iduser = 1;
            string titulo = tituloPreg.Text;
            string descripcion = tituloPreg.Text;
            //aun no se 100% como se va a manejar la imagen asi que por el momento lo dejo como un string...
            string imagen = null;
            if (imagen)
            {
                AccesoADatos.ABMPregunta.AltaPregunta(iduser, titulo, descripcion, imagen);
            }
            else
            {
                AccesoADatos.ABMPregunta.AltaPregunta(iduser, titulo, descripcion);
            }
          
        }

        private void cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
