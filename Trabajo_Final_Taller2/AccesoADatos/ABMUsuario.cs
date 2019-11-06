using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AccesoADatos
{
    public class ABMUsuario
    {
        /// <summary>
        /// 
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
                command.Parameters.AddWithValue("@apellido,"txbapellido);
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
    }
}
