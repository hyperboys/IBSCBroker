﻿using IBSC.Common;
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
    public class InsureCompanyDAL : DBbase
    {
        public InsureCompanyData GetItem(string code)
        {
            try
            {
                DBbase.Connect();
                string sql = "SELECT COMPANAY_CODE,COMPANY_FULLNAME,COMPANY_PATH_PIC,COMPANY_REMARK,COMPANY_SHORTNAME,COMPANY_STATUS FROM MW_INSURE_COMPANY WHERE COMPANAY_CODE = '" + code + "'";
                MySqlCommand cmd = new MySqlCommand(sql, DBbase.con);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    InsureCompanyData item = new InsureCompanyData();
                    item.COMPANAY_CODE = reader.GetString("COMPANAY_CODE");
                    item.COMPANY_FULLNAME = reader.GetString("COMPANY_FULLNAME");
                    item.COMPANY_PATH_PIC = reader.GetString("COMPANY_PATH_PIC");
                    item.COMPANY_REMARK = reader.GetString("COMPANY_REMARK");
                    item.COMPANY_SHORTNAME = reader.GetString("COMPANY_SHORTNAME");
                    item.COMPANY_STATUS = reader.GetString("COMPANY_STATUS");
                    reader.Close();
                    return item;
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

        public void Insert(InsureCompanyData item)
        {
            try
            {
                MemberData member = (MemberData)DataCommon.Get("DATA.MEMBER");

                DBbase.Connect();
                StringBuilder sql = new StringBuilder();
                sql.Append("INSERT INTO MW_INSURE_COMPANY (COMPANAY_CODE,COMPANY_FULLNAME,COMPANY_PATH_PIC,COMPANY_REMARK,COMPANY_SHORTNAME,COMPANY_STATUS,CREATE_DATE,CREATE_USER,UPDATE_DATE,UPDATE_USER) VALUES (");
                sql.Append(" '" + item.COMPANAY_CODE + "',");
                sql.Append(" '" + item.COMPANY_FULLNAME + "',");
                sql.Append(" '" + item.COMPANY_PATH_PIC + "',");
                sql.Append(" '" + item.COMPANY_REMARK + "',");
                sql.Append(" '" + item.COMPANY_SHORTNAME + "',");
                sql.Append(" '" + item.COMPANY_STATUS + "',");
                sql.Append(" '" + DateTime.Now + "',");
                sql.Append(" '" + member.MEMBER_USER + "',");
                sql.Append(" '" + DateTime.Now + "',");
                sql.Append(" '" + member.MEMBER_USER + "')");
               
                MySqlCommand cmd = new MySqlCommand(sql.ToString(), DBbase.con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(InsureCompanyData item)
        {
            try
            {
                MemberData member = (MemberData)DataCommon.Get("DATA.MEMBER");
                DBbase.Connect();
                StringBuilder sql = new StringBuilder();
                sql.Append("UPDATE MW_INSURE_COMPANY SET COMPANAY_CODE = '" + item.COMPANAY_CODE + "',");
                sql.Append(" COMPANY_FULLNAME = '" + item.COMPANY_FULLNAME + "',");
                sql.Append(" COMPANY_PATH_PIC = '" + item.COMPANY_PATH_PIC + "',");
                sql.Append(" COMPANY_REMARK = '" + item.COMPANY_REMARK + "',");
                sql.Append(" COMPANY_SHORTNAME = '" + item.COMPANY_SHORTNAME + "',");
                sql.Append(" COMPANY_STATUS = '" + item.COMPANY_STATUS + "',");
                sql.Append(" UPDATE_DATE = '" + DateTime.Now + "',");
                sql.Append(" UPDATE_USER = '" + member.MEMBER_USER + "'");
                sql.Append(" WHERE COMPANAY_CODE = '" + item.COMPANAY_CODE + "'");
                MySqlCommand cmd = new MySqlCommand(sql.ToString(), DBbase.con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetAll()
        {
            try
            {
                DBbase.Connect();
                string sql = "SELECT COMPANAY_CODE,COMPANY_FULLNAME,COMPANY_STATUS FROM MW_INSURE_COMPANY ORDER BY COMPANAY_CODE";
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