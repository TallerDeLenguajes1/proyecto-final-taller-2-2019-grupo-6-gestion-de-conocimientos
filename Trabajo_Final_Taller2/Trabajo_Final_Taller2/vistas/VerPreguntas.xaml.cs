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
        }
     

        private void btn_Regresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
