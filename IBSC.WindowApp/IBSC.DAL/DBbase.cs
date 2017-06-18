using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace IBSC.DAL
{
    public class DBbase
    {
        protected static SqlConnection con;
        private static string server;
        private static string database;
        private static string uid;
        private static string password;

        protected static void Connect()
        {
            try
            {
                //server = "Sql-5.5.chaiyohosting.com";
                //database = "ibscbroker";
                //uid = "ibscbroker";
                //password = "93Nuu1@z";

#if DEBUG
                server = @".\SQLEXPRESS2008R2";
                database = "ibscbroker_pro";
                uid = "sa";
                password = "Admin2000";

#else
                server = "mssql-2012.chaiyohosting.com";
                database = "ibscbroker_pro";
                uid = "msbroker";
                password = "ITibsc2@17";
#endif
                string connectionString;
                connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

                //con = new SqlConnection(connectionString);
                con = new SqlConnection(connectionString);
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
