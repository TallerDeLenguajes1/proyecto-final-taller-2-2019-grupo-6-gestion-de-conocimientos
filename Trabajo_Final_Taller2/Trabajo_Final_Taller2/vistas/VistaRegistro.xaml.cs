using AccesoADatos;
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
    /// Interaction logic for VistaRegistro.xaml
    /// </summary>
    public partial class VistaRegistro : Window
    {
        public VistaRegistro()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (DatosValidos())
            {
                RegistrarUsuario();
                MessageBox.Show("Registro exitoso");
                this.Close();
            }
        }

        private bool DatosValidos()
        {
            // Verificacion de que cada campo tenga contenido
            if (string.IsNullOrWhiteSpace(txbNombre.Text))
            {
                MessageBox.Show("No completo el campo Nombre");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txbApellido.Text))
            {
                MessageBox.Show("No completo el campo Apellido");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txbPais.Text))
            {
                MessageBox.Show("No completo el campo Pais");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txbEmail.Text))
            {
                MessageBox.Show("No completo el campo Email");
                return false;
            }
            if (string.IsNullOrWhiteSpace(pwbPassword.Password))
            {
                MessageBox.Show("No completo el campo Password");
                return false;
            }

            // Verificacion de que los campos no superen la longitud maxima
            if (txbNombre.Text.Length > 45)
            {
                MessageBox.Show("No se permite nombre mayor a 45 caracteres");
                return false;
            }
            if (txbApellido.Text.Length > 45)
            {
                MessageBox.Show("No se permite apellido mayor a 45 caracteres");
                return false;
            }
            if (txbPais.Text.Length > 45)
            {
                MessageBox.Show("No se permite pais mayor a 45 caracteres");
                return false;
            }
            if (txbEmail.Text.Length > 45)
            {
                MessageBox.Show("No se permite email mayor a 45 caracteres");
                return false;
            }
            if (pwbPassword.Password.Length > 45)
            {
                MessageBox.Show("No se permite contraseña mayor a 45 caracteres");
                return false;
            }

            // Verificar que el email tenga el formato valido
            if (ControlDatos.Verificaremail(txbEmail.Text) == false)
            {
                MessageBox.Show("El email no tiene un formato valido");
                return false;
            }

            // Verificacion de que el email no sea uno ya existente en la base de datos
            if (ABMUsuario.ExisteUser(txbEmail.Text))
            {
                MessageBox.Show("Ya existe un usuario registrado con este email");
                return false;
            }

            // Si pasa todas las verificaciones retorna true
            return true;
        }

        private void RegistrarUsuario()
        {
            string nombre = txbNombre.Text;
            string apellido = txbApellido.Text;
            string pais = txbPais.Text;
            string email = txbEmail.Text;
            string password = pwbPassword.Password;

            ABMUsuario.AltaUsuario(nombre, apellido, pais, email, password);
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Brd_border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
