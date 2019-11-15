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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using AccesoADatos;
using Entidades;

namespace Trabajo_Final_Taller2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Usuario user;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            //Verifico que el email sea correcto
            if (ControlDatos.Verificaremail(txb_email.Text) == true)
            {
                //Si el email es correcto llamo al metodo loguear usuario y verifico si el usuario que busca existe
                if (HelperABM.LoguearUsuario(txb_email.Text, psb_pass.Password.ToString()) != null)
                {
                    //Si se devuelve un usuario lo guardo en la variable user y genero la siguiente vista que será vista usuarios
                    user = HelperABM.LoguearUsuario(txb_email.Text, psb_pass.Password.ToString());
                    vistas.vistaUsuarios vistaUsuarios = new vistas.vistaUsuarios(user);
                    //Cierro la vista del login y muestro la vista del usuario
                    this.Close();
                    vistaUsuarios.Show();
                }
                else
                {
                    //El email no está en la Bd, o la combinacion de email y contraseña no coinciden
                    MessageBox.Show("Tus credenciales de inicio de sesión no coinciden con una cuenta en nuestro sistema.");
                }
            }
            else
            {
                //El email ingresado es inválido
                MessageBox.Show("Ingrese un email válido.");
            }
        }
    }
}
