using IBSC.Common;
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
    public class CheckInsureCarDAL : DBbase
    {
        public DataTable GetAll()
        {
            try
            {
                DBbase.Connect();
                string sql = @"SELECT T.SELECT_INSURANCE_CODE,T.CUSTOMER_NAME,T.CUSTOMER_EMAIL,T.CUSTOMER_TEL,T.SELECT_INSURANCE_STATUS,
                (CASE T.SELECT_INSURANCE_STATUS WHEN '01' THEN 'ส่งเรื่อง' WHEN '02' THEN 'รับเรื่อง' WHEN '03' THEN 'ติดต่อแล้ว' WHEN '04' THEN 'ข้อมูลเท็จ' END) AS SELECT_INSURANCE_STATUS_NAME ,
                T.WINDOW_IP,T.AGENT_CODE,T.TRANSACTION_TYPE,T.UPDATE_USER,
                A.INSURE_CAR_CODE, A.COMPANY_CODE, A.PACKAGE_NAME, A.CAR_ID,
                 A.INSURE_CATEGORY, A.INSURE_TYPE_REPAIR, A.CAR_YEAR, A.LIVE_COVERAGE_PEOPLE,
                 A.LIVE_COVERAGE_TIME, A.ASSET_TIME, A.DAMAGE_TO_VEHICLE,
                 A.MISSING_FIRE_CAR, A.FIRST_DAMAGE_PRICE, A.PERSONAL_ACCIDENT_AMT,
                 A.PERSONAL_ACCIDENT_PEOPLE, A.MEDICAL_FEE_AMT, A.MEDICAL_FEE_PEOPLE, 
                 A.DRIVER_INSURANCE_AMT, A.NET_PRICE, A.TOTAL_PRICE, A.PRICE_ROUND,
                 A.CAPITAL_INSURANCE, A.INSURE_PRIORITY, A.EFFECTIVE_DATE, A.EXPIRE_DATE,
                 A.CONFIDENTIAL_STATUS, A.CREATE_DATE, A.CREATE_USER, A.UPDATE_DATE,
                 A.UPDATE_USER, A.INSURE_CAR_STATUS, C.CAR_CODE,C.CAR_NAME,C.CAR_MODEL,C.CAR_ENGINE ,I.COMPANY_FULLNAME
                FROM MA_INSURE_CAR A INNER JOIN MA_CAR C ON A.CAR_ID = C.CAR_ID INNER JOIN MA_INSURE_COMPANY I ON A.COMPANY_CODE = I.COMPANY_CODE
                INNER JOIN TA_SELECT_INSURANCE T ON A.INSURE_CAR_CODE = T.INSURE_CAR_CODE ORDER BY A.CREATE_DATE ,T.SELECT_INSURANCE_STATUS";
                MySqlCommand cmd = new MySqlCommand(sql, DBbase.con);
                MySqlDataReader reader = cmd.ExecuteReader();
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

        public DataTable GetAll(string user)
        {
            try
            {
                DBbase.Connect();
                string sql = @"SELECT T.SELECT_INSURANCE_CODE,T.CUSTOMER_NAME,T.CUSTOMER_EMAIL,T.CUSTOMER_TEL,T.SELECT_INSURANCE_STATUS,
                (CASE T.SELECT_INSURANCE_STATUS WHEN '01' THEN 'ส่งเรื่อง' WHEN '02' THEN 'รับเรื่อง' WHEN '03' THEN 'ติดต่อแล้ว' WHEN '04' THEN 'ข้อมูลเท็จ' END) AS SELECT_INSURANCE_STATUS_NAME ,
                T.WINDOW_IP,T.AGENT_CODE,T.TRANSACTION_TYPE,T.UPDATE_USER,
                A.INSURE_CAR_CODE, A.COMPANY_CODE, A.PACKAGE_NAME, A.CAR_ID,
                 A.INSURE_CATEGORY, A.INSURE_TYPE_REPAIR, A.CAR_YEAR, A.LIVE_COVERAGE_PEOPLE,
                 A.LIVE_COVERAGE_TIME, A.ASSET_TIME, A.DAMAGE_TO_VEHICLE,
                 A.MISSING_FIRE_CAR, A.FIRST_DAMAGE_PRICE, A.PERSONAL_ACCIDENT_AMT,
                 A.PERSONAL_ACCIDENT_PEOPLE, A.MEDICAL_FEE_AMT, A.MEDICAL_FEE_PEOPLE, 
                 A.DRIVER_INSURANCE_AMT, A.NET_PRICE, A.TOTAL_PRICE, A.PRICE_ROUND,
                 A.CAPITAL_INSURANCE, A.INSURE_PRIORITY, A.EFFECTIVE_DATE, A.EXPIRE_DATE,
                 A.CONFIDENTIAL_STATUS, A.CREATE_DATE, A.CREATE_USER, A.UPDATE_DATE,
                 A.UPDATE_USER, A.INSURE_CAR_STATUS, C.CAR_CODE,C.CAR_NAME,C.CAR_MODEL,C.CAR_ENGINE ,I.COMPANY_FULLNAME
                FROM MA_INSURE_CAR A INNER JOIN MA_CAR C ON A.CAR_ID = C.CAR_ID INNER JOIN MA_INSURE_COMPANY I ON A.COMPANY_CODE = I.COMPANY_CODE
                INNER JOIN TA_SELECT_INSURANCE T ON A.INSURE_CAR_CODE = T.INSURE_CAR_CODE WHERE ( T.SELECT_INSURANCE_STATUS = '01') OR (T.UPDATE_USER = '" + user + "' AND T.SELECT_INSURANCE_STATUS = '02') " +
                " ORDER BY A.CREATE_DATE ,T.SELECT_INSURANCE_STATUS";
                MySqlCommand cmd = new MySqlCommand(sql, DBbase.con);
                MySqlDataReader reader = cmd.ExecuteReader();
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

        public string CheckStatus(string code)
        {
            try
            {
                DBbase.Connect();
                string sql = @"SELECT SELECT_INSURANCE_STATUS FROM TA_SELECT_INSURANCE WHERE SELECT_INSURANCE_CODE ='" + code + "' AND SELECT_INSURANCE_STATUS = '01'";
                MySqlCommand cmd = new MySqlCommand(sql, DBbase.con);
                MySqlDataReader reader = cmd.ExecuteReader();
                string stringReturn = "";
                if (reader.Read())
                {
                    stringReturn = reader.GetString("SELECT_INSURANCE_STATUS");
                    reader.Close();
                    DBbase.DisConnect();
                    return stringReturn;
                }
                else
                {
                    reader.Close();
                    DBbase.DisConnect();
                    return stringReturn;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CheckOwner(string code, string user)
        {
            try
            {
                DBbase.Connect();
                string sql = @"SELECT SELECT_INSURANCE_STATUS FROM TA_SELECT_INSURANCE WHERE SELECT_INSURANCE_CODE ='" + code + "' AND SELECT_INSURANCE_STATUS = '02' AND UPDATE_USER = '" + user + "'";
                MySqlCommand cmd = new MySqlCommand(sql, DBbase.con);
                MySqlDataReader reader = cmd.ExecuteReader();
                string stringReturn = "";
                if (reader.Read())
                {
                    stringReturn = reader.GetString("SELECT_INSURANCE_STATUS");
                    reader.Close();
                    DBbase.DisConnect();
                    return stringReturn;
                }
                else
                {
                    reader.Close();
                    DBbase.DisConnect();
                    return stringReturn;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CheckInsureCarData GetItem(string code)
        {
            try
            {
                DBbase.Connect();
                string sql = @"SELECT SELECT_INSURANCE_CODE,CUSTOMER_NAME,CUSTOMER_EMAIL,CUSTOMER_TEL,SELECT_INSURANCE_STATUS,
                WINDOW_IP,AGENT_CODE,TRANSACTION_TYPE,INSURE_CAR_CODE,REMARK,CREATE_DATE
                FROM TA_SELECT_INSURANCE WHERE SELECT_INSURANCE_CODE = '" + code + "'";

                MySqlCommand cmd = new MySqlCommand(sql, DBbase.con);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    CheckInsureCarData item = new CheckInsureCarData();
                    item.SELECT_INSURANCE_CODE = reader.GetString("SELECT_INSURANCE_CODE");
                    item.INSURE_CAR_CODE = reader.GetString("INSURE_CAR_CODE");
                    item.CUSTOMER_NAME = reader.GetString("CUSTOMER_NAME");
                    item.CUSTOMER_EMAIL = reader.GetString("CUSTOMER_EMAIL");
                    item.CUSTOMER_TEL = reader.GetString("CUSTOMER_TEL");
                    item.SELECT_INSURANCE_STATUS = reader.GetString("SELECT_INSURANCE_STATUS");
                    item.WINDOW_IP = reader.GetString("WINDOW_IP");
                    item.AGENT_CODE = reader.GetString("AGENT_CODE");
                    item.TRANSACTION_TYPE = reader.GetString("TRANSACTION_TYPE");
                    item.REMARK = reader.GetString("REMARK");
                    item.CREATE_DATE = Convert.ToDateTime(reader.GetString("CREATE_DATE"));
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

        public CheckInsureCarData GetItemAgent(string code)
        {
            try
            {
                DBbase.Connect();
                string sql = @"SELECT T.SELECT_INSURANCE_CODE,T.SELECT_INSURANCE_STATUS,
                T.WINDOW_IP,T.AGENT_CODE,T.TRANSACTION_TYPE,T.INSURE_CAR_CODE,T.REMARK,T.CREATE_DATE,S.sm_name,S.sm_lastname,S.sm_email,S.sm_tel,S.sm_phone 
                FROM TA_SELECT_INSURANCE T INNER JOIN system_member S ON T.AGENT_CODE = S.sm_code WHERE SELECT_INSURANCE_CODE = '" + code + "'";

                MySqlCommand cmd = new MySqlCommand(sql, DBbase.con);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    CheckInsureCarData item = new CheckInsureCarData();
                    item.SELECT_INSURANCE_CODE = reader.GetString("SELECT_INSURANCE_CODE");
                    item.INSURE_CAR_CODE = reader.GetString("INSURE_CAR_CODE");
                    item.AGENT_NAME = reader.GetString("sm_name") + " " + reader.GetString("sm_lastname");
                    item.AGENT_EMAIL = reader.GetString("sm_email");
                    item.AGENT_PHONE = reader.GetString("sm_phone");
                    item.AGENT_TEL = reader.GetString("sm_tel");
                    item.SELECT_INSURANCE_STATUS = reader.GetString("SELECT_INSURANCE_STATUS");
                    item.WINDOW_IP = reader.GetString("WINDOW_IP");
                    item.AGENT_CODE = reader.GetString("AGENT_CODE");
                    item.TRANSACTION_TYPE = reader.GetString("TRANSACTION_TYPE");
                    item.REMARK = reader.GetString("REMARK");
                    item.CREATE_DATE = Convert.ToDateTime(reader.GetString("CREATE_DATE"));
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

        public void UpdateStatus(string code)
        {
            try
            {
                MemberData member = (MemberData)DataCommon.Get("DATA.MEMBER");
                DBbase.Connect();
                StringBuilder sql = new StringBuilder();
                sql.Append("UPDATE TA_SELECT_INSURANCE ");
                sql.Append("SET SELECT_INSURANCE_STATUS = '02',");
                sql.Append(" WINDOW_IP = '" + UtilityCommon.GetLocalIPAddress() + "',");
                sql.Append(" UPDATE_DATE = '" + ConvertCommon.ConvertDateTime(DateTime.Now) + "',");
                sql.Append(" UPDATE_USER = '" + member.MEMBER_USER + "'");
                sql.Append(" WHERE SELECT_INSURANCE_CODE = '" + code + "'");
                MySqlCommand cmd = new MySqlCommand(sql.ToString(), DBbase.con);
                cmd.ExecuteNonQuery();
                DBbase.DisConnect();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateComplete(CheckInsureCarData item)
        {
            try
            {
                MemberData member = (MemberData)DataCommon.Get("DATA.MEMBER");
                DBbase.Connect();
                StringBuilder sql = new StringBuilder();
                sql.Append("UPDATE TA_SELECT_INSURANCE ");
                sql.Append("SET SELECT_INSURANCE_STATUS = '" + item.SELECT_INSURANCE_STATUS + "',");
                sql.Append(" REMARK = '" + item.REMARK + "',");
                sql.Append(" WINDOW_IP = '" + UtilityCommon.GetLocalIPAddress() + "',");
                sql.Append(" UPDATE_DATE = '" + ConvertCommon.ConvertDateTime(DateTime.Now) + "',");
                sql.Append(" UPDATE_USER = '" + member.MEMBER_USER + "'");
                sql.Append(" WHERE SELECT_INSURANCE_CODE = '" + item.SELECT_INSURANCE_CODE + "'");
                MySqlCommand cmd = new MySqlCommand(sql.ToString(), DBbase.con);
                cmd.ExecuteNonQuery();
                DBbase.DisConnect();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
