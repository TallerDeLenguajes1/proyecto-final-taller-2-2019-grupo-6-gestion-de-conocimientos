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
    /// Lógica de interacción para vistaUsuarioConfiguracion.xaml
    /// </summary>
    public partial class vistaUsuarioConfiguracion : Window
    {
        Usuario usuario;
        public vistaUsuarioConfiguracion(Usuario user)
        {
            InitializeComponent();
            usuario = user;
        }

        private void salir_Click(object sender, RoutedEventArgs e)
        {
            ControladorABM.cambiarPass(usuario);
        }

        private void btn_borrar_cuenta_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
