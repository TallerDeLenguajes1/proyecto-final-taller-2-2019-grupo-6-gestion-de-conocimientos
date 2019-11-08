using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public class Notificacion
    {
        public int IdUserPregunta { get; set; }
        public int IdRespuesta { get; set; }

        public Usuario GetUserPregunta()
        {
            Usuario user = new Usuario();
            //Conecto a la base de datos
            AccesoADatos.Conexion_Desconexion.Connection();
            // Select del usuario que recibe la notificacion
            string query = "SELECT * FROM Usuarios WHERE id_user = IdUserPregunta";
            SqlCommand command = new SqlCommand(query, AccesoADatos.Conexion_Desconexion.Con);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            user.Nombre = reader.GetString(1);
            user.Apellido = reader.GetString(2);
            user.PaisOrigen = reader.GetString(3);
            user.Email = reader.GetString(4);
            user.Contraseña = reader.GetString(5);
            user.FechaIngreso = reader.GetDateTime(6);
            AccesoADatos.Conexion_Desconexion.Desconnect();
            return user; // return provisorio
        }
        public Respuesta GetRespuesta()
        {
            Respuesta respuesta = new Respuesta();
            //Conecto a la base de datos
            AccesoADatos.Conexion_Desconexion.Connection();
            // Select de la respuesta recibida
            string query = "SELECT * FROM Respuestas WHERE id_respuesta = IdRespuesta";
            SqlCommand command = new SqlCommand(query, AccesoADatos.Conexion_Desconexion.Con);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            respuesta.IdUserResp = reader.GetInt16(0);
            respuesta.IdPregunta = reader.GetInt16(1);
            respuesta.IdRespuesta = reader.GetInt16(2);
            respuesta.Titulo = reader.GetString(3);
            respuesta.Descripcion = reader.GetString(4);
            respuesta.UrlImagen= reader.GetString(5);
            respuesta.Fecha = reader.GetDateTime(6);
            respuesta.Likes= reader.GetInt16(7);
            AccesoADatos.Conexion_Desconexion.Desconnect();
            return respuesta; // return provisorio
        }
    }
}
