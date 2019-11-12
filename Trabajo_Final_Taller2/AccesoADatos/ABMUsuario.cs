﻿using System;
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

            // Consulta para obtener el usuario

            string query = @"SELECT * FROM Usuarios WHERE id_user = " + idUser.ToString();

            //

            return user;
        }

        /// <summary>
        /// Elimina de la base de datos al usuario con el id especificado
        /// </summary>
        /// <param name="idUser"></param>
        static public void BajaUsuario(int idUser)
        {
            // Realizar consulta DELETE para la baja del usuario

            string query = @"DELETE FROM Usuarios WHERE id_user = " + idUser.ToString();
        }

        /// <summary>
        /// Chequea si existe un usuario dado su id
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        static public bool ExisteUser(int idUser)
        {
            string query = @"SELECT * FROM Usuarios WHERE id_user = " + idUser.ToString();

        }

        /// <summary>
        /// Chequea si existe un usuario dado su email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        static public bool ExisteUser(string email)
        {
            string query = @"SELECT * FROM Usuarios WHERE id_user = " + email;

        }

    }
}
