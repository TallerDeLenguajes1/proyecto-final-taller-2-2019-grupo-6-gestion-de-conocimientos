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
        Usuario GetUsuario(int id_user)
        {
            Usuario user = new Usuario();

            // Consulta para obtener el usuario

            return user;
        }

        /// <summary>
        /// Obtiene las notificaciones correspondientes del usuario 
        /// </summary>
        /// <param name="id_user"></param>
        /// <returns></returns>
        List<Notificacion> GetNotificaciones(Usuario user)
        {
            List<Notificacion> notificaciones = new List<Notificacion>();

            int id_user = user.IdUsuario;

            // Realizar consulta en la tabla de notificaciones usando id_user

            return notificaciones;
        }


        /// <summary>
        /// Carga las listas de notificaciones y preguntas al objeto usuario 
        /// </summary>
        /// <param name="user"></param>
        void CargarListas(Usuario user)
        {
            user.Notificaciones = GetNotificaciones(user);
            user.Preguntas = GetPreguntas(user);
        }
    }
}
