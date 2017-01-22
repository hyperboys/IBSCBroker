using IBSC.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBSC.DAL
{
    public class MemberDAL : DBbase
    {
        public bool SingOn(string user, string pass)
        {
            try
            {
                DBbase.Connect();
                string sql = "SELECT * FROM member_winapp WHERE member_user = '" + user + "' and member_password = '" + pass + "'";
                MySqlCommand cmd = new MySqlCommand(sql, DBbase.con);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Member GetMember(string user, string pass)
        {
            try
            {
                DBbase.Connect();
                string sql = "SELECT MEMBER_NAME,MEMBER_SURENAME,MEMBER_USER,MEMBER_PASSWORD,MEMBER_STATUS FROM member_winapp WHERE MEMBER_USER = '" + user + "' AND MEMBER_PASSWORD = '" + pass + "'";
                MySqlCommand cmd = new MySqlCommand(sql, DBbase.con);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Member member = new Member();
                    member.MEMBER_NAME = reader.GetString("MEMBER_NAME");
                    member.MEMBER_SURENAME = reader.GetString("MEMBER_SURENAME");
                    member.MEMBER_USER = reader.GetString("MEMBER_USER");
                    member.MEMBER_PASSWORD = reader.GetString("MEMBER_PASSWORD");
                    member.MEMBER_STATUS = reader.GetString("MEMBER_STATUS");
                    reader.Close();
                    return member;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateMember(Member item)
        {
            try
            {
                DBbase.Connect();
                StringBuilder sql = new StringBuilder();
                sql.Append("UPDATE member_winapp SET MEMBER_NAME = '" + item.MEMBER_NAME + "',");
                sql.Append(" MEMBER_SURENAME = '" + item.MEMBER_SURENAME + "',");
                sql.Append(" MEMBER_USER = '" + item.MEMBER_USER + "',");
                sql.Append(" MEMBER_PASSWORD = '" + item.MEMBER_PASSWORD + "',");
                sql.Append(" MEMBER_STATUS = '" + item.MEMBER_STATUS + "'");
                sql.Append(" WHERE MEMBER_USER = '" + item.MEMBER_USER + "'");
                MySqlCommand cmd = new MySqlCommand(sql.ToString(), DBbase.con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetAllMember()
        {
            try
            {
                DBbase.Connect();
                string sql = "SELECT MEMBER_NAME,MEMBER_SURENAME,MEMBER_USER,MEMBER_STATUS FROM member_winapp";
                MySqlCommand cmd = new MySqlCommand(sql, DBbase.con);
                MySqlDataReader reader = cmd.ExecuteReader();
                DataSet ds = new DataSet();
                DataTable dataTable = new DataTable();
                ds.Tables.Add(dataTable);
                ds.EnforceConstraints = false;
                dataTable.Load(reader);
                reader.Close();
                return dataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
