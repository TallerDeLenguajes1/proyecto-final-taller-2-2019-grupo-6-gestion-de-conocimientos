using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Data.SqlClient;
using NLog;

namespace AccesoADatos
{
    public class Conexion_Desconexion
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        static readonly string DBconfigDir = @"DBconfig.txt";
        static string DBconfig = File.ReadAllText(DBconfigDir);    
        static readonly string connectionString = DBconfig;
        
        readonly static SqlConnection con = new SqlConnection(connectionString);

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
                con.Open();
                return true;
            }
            catch (Exception ex)
            {
                // Log del error
                string error = "Error en la conexion a la base de datos";
                error += "\n--------------------\n";
                error += ex.ToString();
                error += "\n--------------------\n";
                logger.Error(error);

                return false;
            }
        }
        public static bool Disconnect()
        {
            try
            {
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                // Log del error
                string error = "Error en la desconexion a la base de datos";
                error += "\n--------------------\n";
                error += ex.ToString();
                error += "\n--------------------\n";
                logger.Error(error);

                return false;
            }

        }
    }
}
