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

namespace Trabajo_Final_Taller2.vistas
{
    /// <summary>
    /// Lógica de interacción para vistaUsuarios.xaml
    /// </summary>
    public partial class vistaUsuarios : Window
    {
        public vistaUsuarios(Usuario user)
        {
            InitializeComponent();
            lbl_name.Content = user.Nombre + "Está en sesión.";
        }
    }
}
