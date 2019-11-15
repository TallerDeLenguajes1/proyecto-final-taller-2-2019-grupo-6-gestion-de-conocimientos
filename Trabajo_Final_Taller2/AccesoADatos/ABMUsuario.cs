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
        static public void AltaUsuario(string nombre, string apellido, string pais, string email, string password)
        {
            try
            {
                //Hacer conexion a la base de datos
                Conexion_Desconexion.Connection();
                string query = @"INSERT INTO Usuarios(Nombre,Apellido,Pais,Email,Contraseña) VALUES(@nombre,@apellido,@pais,@email,@password)";
                SqlCommand command = new SqlCommand(query, Conexion_Desconexion.Con);
                /*NOTA: placeholders.*/
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@apellido",apellido);
                command.Parameters.AddWithValue("@pais", pais);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
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
        /// <param name="idUser"></param>
        /// <returns></returns>
        static public Usuario GetUsuario(int idUser)
        {
            Usuario user = new Usuario();
            try
            {
                //Hago la conexion a la base de datos
                Conexion_Desconexion.Connection();
                //Armo mi query para buscar un usuario especifico
                string query = @"SELECT * FROM Usuarios WHERE id_user = @idUser";
                //Armo el command con el query y la conexion
                SqlCommand command = new SqlCommand(query, Conexion_Desconexion.Con);
                //Paso como parametro codificado el id del usuario que busco
                command.Parameters.AddWithValue("@idUser", idUser);
                //Creo un reader que ejecute el query
                SqlDataReader reader = command.ExecuteReader();
                //Utilizo el reader para leer los datos del usuario y cargarlos a user
                reader.Read();
                user.IdUsuario = reader.GetInt16(0);
                user.Nombre = reader.GetString(1);
                user.Apellido = reader.GetString(2);
                user.PaisOrigen = reader.GetString(3);
                user.Email = reader.GetString(4);
                user.Password = reader.GetString(5);
                user.FechaIngreso = reader.GetDateTime(6);
                //Desconecto la base de datos
                Conexion_Desconexion.Desconnect();
            }
            catch (Exception)
            {

                throw;
            }
            //Devuelvo el alumno cargado
            return user;
        }

        /// <summary>
        /// Realiza una consulta a la base de datos para obtener un usuario con el id especificado
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        static public Usuario GetUsuario(string email)
        {
            Usuario user = new Usuario();
            try
            {
                //Hago la conexion a la base de datos
                Conexion_Desconexion.Connection();
                //Armo mi query para buscar un usuario especifico
                string query = @"SELECT * FROM Usuarios WHERE email = @email";
                //Armo el command con el query y la conexion
                SqlCommand command = new SqlCommand(query, Conexion_Desconexion.Con);
                //Paso como parametro codificado el id del usuario que busco
                command.Parameters.AddWithValue("@email", email);
                //Creo un reader que ejecute el query
                SqlDataReader reader = command.ExecuteReader();
                //Utilizo el reader para leer los datos del usuario y cargarlos a user
                reader.Read();
                user.IdUsuario = reader.GetInt32(0);
                user.Nombre = reader.GetString(1);
                user.Apellido = reader.GetString(2);
                user.PaisOrigen = reader.GetString(3);
                user.Email = reader.GetString(4);
                user.Password = reader.GetString(5);
                user.FechaIngreso = reader.GetDateTime(6);
                //Desconecto la base de datos
                Conexion_Desconexion.Desconnect();
            }
            catch (Exception)
            {

                throw;
            }
            //Devuelvo el alumno cargado
            return user;
        }

        /// <summary>
        /// Elimina de la base de datos al usuario con el id especificado
        /// </summary>
        /// <param name="idUser"></param>
        static public void BajaUsuario(int idUser)
        {
            try
            {
                //Hago la conexion a la Bd
                Conexion_Desconexion.Connection();
                //Armo el query
                string query = @"DELETE FROM Usuarios WHERE id_user = @id_user";
                //Armo el command con el query y la conexion
                SqlCommand command = new SqlCommand(query,Conexion_Desconexion.Con);
                //Paso el id del usuario como parametro
                command.Parameters.AddWithValue("@id_user",idUser);
                //Ejecuto el command
                command.ExecuteNonQuery();
                //Cierro la conexion a la Bd
                Conexion_Desconexion.Desconnect();
            }
            catch (Exception ex)
            {
                //Nloggear
                throw;
            }

        }

        /// <summary>
        /// Chequea si existe un usuario dado su id
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        static public bool ExisteUser(int idUser)
        {
           int count;
           try 
	        {
                //Armo la conexion a la base de datos
                Conexion_Desconexion.Connection();
                //Armo el query para verificar que existe el usuario segun su id
                string query = @"SELECT COUNT(*) FROM Usuarios WHERE id_user = @idUser";
                //Armo el command con el query
                SqlCommand command = new SqlCommand(query,Conexion_Desconexion.Con);
                //Paso el id por parametro codificado
                command.Parameters.AddWithValue("@idUser", idUser);
                //Verifico la cantidad de veces que aparece el id en la base de datos y lo guardo
                count = Convert.ToInt32(command.ExecuteScalar());
                //Cierro la conexion a la base de datos
                Conexion_Desconexion.Desconnect();
	        }
	        catch (Exception)
	        {
                //Nloggear
        		throw;
	        }
            //Devuelve true/false segun exista o no el user con ese id
            return count == 0;
        }

        /// <summary>
        /// Chequea si existe un usuario dado su email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        static public bool ExisteUser(string email)
        {
            int count;
            try 
	        {
                //Armo la conexion a la base de datos
                Conexion_Desconexion.Connection();
                //Armo el query para verificar que existe el usuario segun su email
                string query = @"SELECT COUNT(*) FROM Usuarios WHERE email = @email";
                //Armo el command con el query
                SqlCommand command = new SqlCommand(query,Conexion_Desconexion.Con);
                //Paso el email por parametro codificado
                command.Parameters.AddWithValue("@email", email);
                //Verifico la cantidad de veces que aparece el email en la base de datos y lo guardo
                count = Convert.ToInt32(command.ExecuteScalar());
                //Cierro la conexion a la base de datos
                Conexion_Desconexion.Desconnect();
	        }
	        catch (Exception)
	        {
                //Nloggear
        		throw;
	        }
            //Devuelve true/false segun exista o no el user con ese email
            return count == 0;
        }

    }
}
