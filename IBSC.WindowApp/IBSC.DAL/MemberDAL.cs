using IBSC.Common;
using IBSC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                string sql = "SELECT * FROM MA_MEMBER WHERE MEMBER_USER = '" + user + "' AND MEMBER_PASSWORD = '" + pass + "'";
                SqlCommand cmd = new SqlCommand(sql, DBbase.con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    DBbase.DisConnect();
                    return true;
                }
                else
                {
                    DBbase.DisConnect();
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MemberData GetMember(string user)
        {
            try
            {
                DBbase.Connect();
                string sql = "SELECT MEMBER_NAME,MEMBER_SURENAME,MEMBER_USER,MEMBER_PASSWORD,MEMBER_STATUS,ROLE_CODE FROM MA_MEMBER WHERE MEMBER_USER = '" + user + "'";
                SqlCommand cmd = new SqlCommand(sql, DBbase.con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MemberData member = new MemberData();
                    member.MEMBER_NAME = reader["MEMBER_NAME"].ToString();
                    member.MEMBER_SURENAME = reader["MEMBER_SURENAME"].ToString();
                    member.MEMBER_USER = reader["MEMBER_USER"].ToString();
                    member.MEMBER_PASSWORD = reader["MEMBER_PASSWORD"].ToString();
                    member.MEMBER_STATUS = reader["MEMBER_STATUS"].ToString();
                    member.ROLE_CODE = reader["ROLE_CODE"].ToString();
                    reader.Close();
                    DBbase.DisConnect();
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

        public MemberData GetMember(string user, string pass)
        {
            try
            {
                DBbase.Connect();
                string sql = "SELECT MEMBER_NAME,MEMBER_SURENAME,MEMBER_USER,MEMBER_PASSWORD,MEMBER_STATUS,ROLE_CODE FROM MA_MEMBER WHERE MEMBER_USER = '" + user + "' AND MEMBER_PASSWORD = '" + pass + "'";
                SqlCommand cmd = new SqlCommand(sql, DBbase.con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MemberData member = new MemberData();
                    member.MEMBER_NAME = reader["MEMBER_NAME"].ToString();
                    member.MEMBER_SURENAME = reader["MEMBER_SURENAME"].ToString();
                    member.MEMBER_USER = reader["MEMBER_USER"].ToString();
                    member.MEMBER_PASSWORD = reader["MEMBER_PASSWORD"].ToString();
                    member.MEMBER_STATUS = reader["MEMBER_STATUS"].ToString();
                    member.ROLE_CODE = reader["ROLE_CODE"].ToString();
                    reader.Close();
                    DBbase.DisConnect();
                    return member;
                }
                else
                {
                    DBbase.DisConnect();
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertMember(MemberData item)
        {
            try
            {
                MemberData member = (MemberData)DataCommon.Get("DATA.MEMBER");

                DBbase.Connect();
                StringBuilder sql = new StringBuilder();
                sql.Append("INSERT INTO MA_MEMBER (MEMBER_USER,MEMBER_PASSWORD,MEMBER_NAME,MEMBER_SURENAME,MEMBER_STATUS,ROLE_CODE,CREATE_DATE,CREATE_USER,UPDATE_DATE,UPDATE_USER) VALUES (");
                sql.Append(" '" + item.MEMBER_USER + "',");
                sql.Append(" '" + item.MEMBER_PASSWORD + "',");
                sql.Append(" '" + item.MEMBER_NAME + "',");
                sql.Append(" '" + item.MEMBER_SURENAME + "',");
                sql.Append(" '" + item.MEMBER_STATUS + "',");
                sql.Append(" '" + item.ROLE_CODE.ToLower() + "',");

                sql.Append(" '" + DateTime.Now + "',");
                sql.Append(" '" + member.MEMBER_USER + "',");
                sql.Append(" '" + DateTime.Now + "',");
                sql.Append(" '" + member.MEMBER_USER + "')");
               

                SqlCommand cmd = new SqlCommand(sql.ToString(), DBbase.con);
                cmd.ExecuteNonQuery();
                DBbase.DisConnect();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateMember(MemberData item)
        {
            try
            {
                MemberData member = (MemberData)DataCommon.Get("DATA.MEMBER");
                DBbase.Connect();
                StringBuilder sql = new StringBuilder();
                sql.Append("UPDATE MA_MEMBER SET MEMBER_NAME = '" + item.MEMBER_NAME + "',");
                sql.Append(" MEMBER_SURENAME = '" + item.MEMBER_SURENAME + "',");
                sql.Append(" MEMBER_USER = '" + item.MEMBER_USER + "',");
                sql.Append(" MEMBER_PASSWORD = '" + item.MEMBER_PASSWORD + "',");
                sql.Append(" ROLE_CODE = '" + item.ROLE_CODE + "',");
                sql.Append(" MEMBER_STATUS = '" + item.MEMBER_STATUS + "',");
                sql.Append(" UPDATE_DATE = '" + DateTime.Now + "',");
                sql.Append(" UPDATE_USER = '" + member.MEMBER_USER + "'");
                sql.Append(" WHERE MEMBER_USER = '" + item.MEMBER_USER + "'");
                SqlCommand cmd = new SqlCommand(sql.ToString(), DBbase.con);
                cmd.ExecuteNonQuery();
                DBbase.DisConnect();
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
                string sql = "SELECT MEMBER_NAME,MEMBER_SURENAME,MEMBER_USER,MEMBER_STATUS,ROLE_CODE FROM MA_MEMBER ORDER BY MEMBER_USER";
                SqlCommand cmd = new SqlCommand(sql, DBbase.con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataSet ds = new DataSet();
                DataTable dataTable = new DataTable();
                ds.Tables.Add(dataTable);
                ds.EnforceConstraints = false;
                dataTable.Load(reader);
                reader.Close();
                DBbase.DisConnect();
                return dataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
