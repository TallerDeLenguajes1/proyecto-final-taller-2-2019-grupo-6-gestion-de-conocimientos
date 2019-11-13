using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AccesoADatos
{
    class Conexion_Desconexion
    {
        static readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=nombreDB;"
     + "Integrated Security=true";
        static readonly SqlConnection con = new SqlConnection(connectionString);

        public static SqlConnection Con
        {
            get
            {
                return con;
            }
        }

        public static bool Connection()
        {
            try
            {
                Con.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Desconnect()
        {
            try
            {
                Con.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
