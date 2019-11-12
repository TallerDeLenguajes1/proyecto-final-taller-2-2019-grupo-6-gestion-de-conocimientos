using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace AccesoADatos
{
    public class ABMUsuario
    {
        /// <summary>
        /// Toma los datos de entrada de un nuevo usuario y los inserta a la base de datos
        /// </summary>
        void CargarUsuario()
        {
            try
            {
                //Hacer conexion a la base de datos
                Conexion_Desconexion.Connection();
                string query = @"INSERT INTO Usuarios(Nombre,Apellido,Pais,Email,Contraseña) VALUES(@nombre,@apellido,@pais,@email,@contraseña)";
                SqlCommand command = new SqlCommand(query, Conexion_Desconexion.Con);
                /*NOTA: placeholders.*/
                command.Parameters.AddWithValue("@nombre", txbnombre);
                command.Parameters.AddWithValue("@apellido",txbapellido);
                command.Parameters.AddWithValue("@pais", txbpais);
                command.Parameters.AddWithValue("@email", txbemail);
                command.Parameters.AddWithValue("@contraseña", txbcontraseña);
                command.ExecuteNonQuery();
                //Desconectar
                Conexion_Desconexion.Desconnect();
            }
            catch (Exception ex)
            {
                //Nloggear
                throw;
            }
        }

        /// <summary>
        /// Realiza una consulta a la base de datos para obtener un usuario con el id especificado
        /// </summary>
        /// <param name="id_user"></param>
        /// <returns></returns>
        static public Usuario GetUsuario(int id_user)
        {
            Usuario user = new Usuario();

            // Consulta para obtener el usuario

            return user;
        }

        /// <summary>
        /// Carga la lista de preguntas al objeto usuario 
        /// </summary>
        /// <param name="user"></param>
        static public void CargarListaPreguntas(Usuario user)
        {
            user.Preguntas = ABMPregunta.GetPreguntas(user);
        }

        /// <summary>
        /// Carga la lista de notificaciones al objeto usuario 
        /// </summary>
        /// <param name="user"></param>
        static public void CargarListaNotificaciones(Usuario user)
        {
            user.Notificaciones = ABMNotificacion.GetNotificaciones(user);
        }
    }
}
