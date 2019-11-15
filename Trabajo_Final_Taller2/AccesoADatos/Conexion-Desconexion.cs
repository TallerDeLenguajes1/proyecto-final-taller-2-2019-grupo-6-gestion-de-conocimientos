using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AccesoADatos
{
    public class Conexion_Desconexion
    {
        static readonly string DBconfigDir = @"..\..\..\AccesoADatos\DBconfig.txt";
        static string DBconfig = File.ReadAllText(DBconfigDir);    
        static readonly string connectionString = DBconfig;
        //agregar try catch?
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
