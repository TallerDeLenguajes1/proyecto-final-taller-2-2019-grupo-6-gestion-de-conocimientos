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
    public partial class VistaLogin : Window
    {
        Usuario user;
        public VistaLogin()
        {
            InitializeComponent();
        }
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                login();
            }
        }
        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            login();
        }
        public void login()
        {
            //Verifico que el email sea correcto
            if (ControlDatos.Verificaremail(txb_email.Text) == true)
            {
                //Si el email es correcto llamo al metodo loguear usuario y verifico si el usuario que busca existe
                if (ControladorABM.LoguearUsuario(txb_email.Text, psb_pass.Password.ToString()) != null)
                {
                    //Si se devuelve un usuario lo guardo en la variable user y genero la siguiente vista que será vista usuarios
                    user = ControladorABM.LoguearUsuario(txb_email.Text, psb_pass.Password.ToString());
                    vistas.vistaUsuarios vistaUsuarios = new vistas.vistaUsuarios(user);
                    //Cierro la vista del login y muestro la vista del usuario
                    this.Close();
                    vistaUsuarios.Show();
                }
                else
                {
                    //El email no está en la Bd, o la combinacion de email y contraseña no coinciden
                    MessageBox.Show("Tus credenciales de inicio de sesión no coinciden con una cuenta en nuestro sistema.","Error");
                }
            }
            else
            {
                //El email ingresado es inválido
                MessageBox.Show("Ingrese un email válido.","Error");
            }
        }

        private void Btn_close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Brd_border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btn_registro_Click(object sender, RoutedEventArgs e)
        {
            vistas.VistaRegistro vRegistro = new vistas.VistaRegistro();
            vRegistro.ShowDialog();
        }
    }
}
