using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace IBSC.DAL
{
    public class DBbase
    {
        protected static MySqlConnection con;
        private static string server;
        private static string database;
        private static string uid;
        private static string password;

        protected static void Connect()
        {
            try
            {
                server = "mysql-5.5.chaiyohosting.com";
                database = "ibscbroker";
                uid = "ibscbroker";
                password = "93Nuu1@z";

                string connectionString;
                connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

                con = new MySqlConnection(connectionString);
                con.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected static void DisConnect()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
