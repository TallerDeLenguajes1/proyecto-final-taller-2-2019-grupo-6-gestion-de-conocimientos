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
using Microsoft.Win32;
using Entidades;

namespace Trabajo_Final_Taller2.vistas
{
    /// <summary>
    /// Lógica de interacción para HacerPregunta.xaml
    /// </summary>
    public partial class HacerPregunta : Window
    {
        Usuario user;
        string imagenFinal = null;
        public HacerPregunta(Usuario user)
        {
            InitializeComponent();
            this.user = user;
        }
        private void btnPreguntar_Click(object sender, RoutedEventArgs e)
        {
            string titulo;
            string descripcion;

            //aun no se 100% como se va a manejar la imagen asi que por el momento lo dejo como un string...
            string imagen = imagenFinal;

            // Validacion de campos
            if (string.IsNullOrWhiteSpace(txbTitulo.Text) 
               || string.IsNullOrWhiteSpace(txbDescripcion.Text))
            {
                MessageBox.Show("Campos invalidos");
                return;
            }
            else
            {
                titulo = txbTitulo.Text;
                descripcion = txbDescripcion.Text;
            }

            if (imagen != null)
            {
                ControladorABM.HacerPregunta(user, titulo, descripcion, imagen);
            }
            else
            {
                ControladorABM.HacerPregunta(user, titulo, descripcion);
            }
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Lo que hace este metodo es, al hacer click se abre un cuadro para seleccionar imagen; se usan unos parametros para especificar 
        /// que tipo de imagenes se pueden subir
        /// despues se obtiene el nombre del archivo, la ruta + el nombre, a donde se quiere copiar el archivo y destFile que va a ser la nueva ruta + el nombre dek archivo
        /// luego se copia la imagen en la carpeta de imagenes del proyecto.
        /// </summary>
        private void btnExaminar_Click(object sender, RoutedEventArgs e)
        {
            imagenFinal = HelperImagen.GuardarImagen();
        }

        private void Brd_border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
