﻿using IBSC.Common;
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
    public class CarDAL : DBbase
    {
        public CarData GetItem(string carCode, string carName, string carModel, string carEngine)
        {
            try
            {
                DBbase.Connect();
                string sql = @"SELECT CAR_ID,CAR_CODE,CAR_NAME,CAR_MODEL,CAR_ENGINE,CAR_REMARK,CAR_STATUS FROM MA_CAR WHERE
                CAR_CODE = '" + carCode + "' AND CAR_NAME = '" + carName + "' AND CAR_MODEL = '" + carModel + "' AND CAR_ENGINE = '" + carEngine + "'";
                SqlCommand cmd = new SqlCommand(sql, DBbase.con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    CarData item = new CarData();
                    item.CAR_ID = Convert.ToInt32(reader["CAR_ID"].ToString());
                    item.CAR_CODE = reader["CAR_CODE"].ToString();
                    item.CAR_NAME = reader["CAR_NAME"].ToString();;
                    item.CAR_MODEL = reader["CAR_MODEL"].ToString();;
                    item.CAR_ENGINE = reader["CAR_ENGINE"].ToString();
                    item.CAR_REMARK = reader["CAR_REMARK"].ToString();
                    item.CAR_STATUS = reader["CAR_STATUS"].ToString();
                    reader.Close();
                    DBbase.DisConnect();
                    return item;
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

        public CarData GetItem(string carName, string carModel, string carEngine)
        {
            try
            {
                DBbase.Connect();
                string sql = @"SELECT CAR_ID,CAR_CODE,CAR_NAME,CAR_MODEL,CAR_ENGINE,CAR_REMARK,CAR_STATUS FROM MA_CAR WHERE
                CAR_NAME = '" + carName + "' AND CAR_MODEL = '" + carModel + "' AND CAR_ENGINE = '" + carEngine + "'";
                SqlCommand cmd = new SqlCommand(sql, DBbase.con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    CarData item = new CarData();
                    item.CAR_ID = Convert.ToInt32(reader["CAR_ID"].ToString());
                    item.CAR_CODE = reader["CAR_CODE"].ToString();
                    item.CAR_NAME = reader["CAR_NAME"].ToString();
                    item.CAR_MODEL = reader["CAR_MODEL"].ToString();
                    item.CAR_ENGINE = reader["CAR_ENGINE"].ToString();
                    item.CAR_REMARK = reader["CAR_REMARK"].ToString();
                    item.CAR_STATUS = reader["CAR_STATUS"].ToString();
                    reader.Close();
                    DBbase.DisConnect();
                    return item;
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

        public CarData GetItemForExcel(string carCode, string carName, string carModel)
        {
            try
            {
                DBbase.Connect();
                string sql = @"SELECT CAR_ID,CAR_CODE,CAR_NAME,CAR_MODEL,CAR_ENGINE,CAR_REMARK,CAR_STATUS FROM MA_CAR WHERE
                CAR_CODE = '" + carCode + "' AND CAR_NAME = '" + carName + "' AND CAR_MODEL = '" + carModel + "' ";
                SqlCommand cmd = new SqlCommand(sql, DBbase.con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    CarData item = new CarData();
                    item.CAR_ID = Convert.ToInt32(reader["CAR_ID"].ToString());
                    item.CAR_CODE = reader["CAR_CODE"].ToString();
                    item.CAR_NAME = reader["CAR_NAME"].ToString();
                    item.CAR_MODEL = reader["CAR_MODEL"].ToString();
                    item.CAR_ENGINE = reader["CAR_ENGINE"].ToString();
                    item.CAR_REMARK = reader["CAR_REMARK"].ToString();
                    item.CAR_STATUS = reader["CAR_STATUS"].ToString();
                    reader.Close();
                    DBbase.DisConnect();
                    return item;
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

        public void Insert(CarData item)
        {
            try
            {
                MemberData member = (MemberData)DataCommon.Get("DATA.MEMBER");

                DBbase.Connect();
                StringBuilder sql = new StringBuilder();
                sql.Append("INSERT INTO MA_CAR (CAR_CODE,CAR_ENGINE,CAR_MODEL,CAR_NAME,CAR_REMARK,CAR_STATUS,CREATE_DATE,CREATE_USER,UPDATE_DATE,UPDATE_USER) VALUES (");
                sql.Append(" '" + item.CAR_CODE.ToUpper() + "',");
                sql.Append(" '" + item.CAR_ENGINE.ToUpper() + "',");
                sql.Append(" '" + item.CAR_MODEL.ToUpper() + "',");
                sql.Append(" '" + item.CAR_NAME.ToUpper() + "',");
                sql.Append(" '" + item.CAR_REMARK + "',");
                sql.Append(" '" + item.CAR_STATUS.ToUpper() + "',");
                sql.Append(" '" + DateTime.Now + "',");
                sql.Append(" '" + member.MEMBER_USER + "',");
                sql.Append(" '" + DateTime.Now + "',");
                sql.Append(" '" + member.MEMBER_USER + "')");

                SqlCommand cmd = new SqlCommand(sql.ToString(), DBbase.con);
                cmd.ExecuteNonQuery();
                DBbase.DisConnect();
            }
            catch (SqlException exception)
            {
                if (exception.Number == 2601) // Cannot insert duplicate key row in object error
                {
                    // handle duplicate key error
                    return;
                }
                else
                    throw exception; // throw exception if this exception is unexpected
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(CarData oldItem, CarData newItem)
        {
            try
            {
                MemberData member = (MemberData)DataCommon.Get("DATA.MEMBER");
                DBbase.Connect();
                StringBuilder sql = new StringBuilder();
                sql.Append("UPDATE MA_CAR SET CAR_CODE = '" + newItem.CAR_CODE + "',");
                sql.Append(" CAR_ENGINE = '" + newItem.CAR_ENGINE + "',");
                sql.Append(" CAR_MODEL = '" + newItem.CAR_MODEL + "',");
                sql.Append(" CAR_NAME = '" + newItem.CAR_NAME + "',");
                sql.Append(" CAR_REMARK = '" + newItem.CAR_REMARK + "',");
                sql.Append(" CAR_STATUS = '" + newItem.CAR_STATUS + "',");
                sql.Append(" UPDATE_DATE = '" + DateTime.Now + "',");
                sql.Append(" UPDATE_USER = '" + member.MEMBER_USER + "'");
                sql.Append(" WHERE CAR_CODE = '" + oldItem.CAR_CODE + "'");
                sql.Append(" AND CAR_ENGINE = '" + oldItem.CAR_ENGINE + "'");
                sql.Append(" AND CAR_MODEL = '" + oldItem.CAR_MODEL + "'");
                sql.Append(" AND CAR_NAME = '" + oldItem.CAR_NAME + "'");
                SqlCommand cmd = new SqlCommand(sql.ToString(), DBbase.con);
                cmd.ExecuteNonQuery();
                DBbase.DisConnect();
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
                string sql = "SELECT CAR_CODE,CAR_NAME,CAR_MODEL,CAR_ENGINE,CAR_STATUS FROM MA_CAR ORDER BY CAR_CODE";
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

        public DataTable GetComboBoxCarName()
        {
            try
            {
                DBbase.Connect();
                string sql = "SELECT DISTINCT CAR_NAME FROM MA_CAR WHERE CAR_STATUS = 'A'";
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

        public DataTable GetComboBoxCarModel(string carName)
        {
            try
            {
                DBbase.Connect();
                string sql = "SELECT DISTINCT CAR_MODEL FROM MA_CAR WHERE CAR_STATUS = 'A' AND CAR_NAME = '" + carName + "'";
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

        public DataTable GetComboBoxCarEngine(string carName, string carModel)
        {
            try
            {
                DBbase.Connect();
                string sql = "SELECT DISTINCT CAR_ENGINE FROM MA_CAR WHERE CAR_STATUS = 'A' AND CAR_NAME = '" + carName + "' AND CAR_MODEL = '" + carModel + "'";
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