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
    public class InsureCarDAL : DBbase
    {
        public DataTable GetAll()
        {
            try
            {
                DBbase.Connect();
                string sql = @"SELECT A.INSURE_CAR_CODE, A.COMPANY_CODE, A.PACKAGE_NAME, A.CAR_ID,
                 A.INSURE_CATEGORY, A.INSURE_TYPE_REPAIR, A.CAR_YEAR, A.LIVE_COVERAGE_PEOPLE,
                 A.LIVE_COVERAGE_TIME, A.ASSET_TIME, A.DAMAGE_TO_VEHICLE,
                 A.MISSING_FIRE_CAR, A.FIRST_DAMAGE_PRICE, A.PERSONAL_ACCIDENT_AMT,
                 A.PERSONAL_ACCIDENT_PEOPLE, A.MEDICAL_FEE_AMT, A.MEDICAL_FEE_PEOPLE, 
                 A.DRIVER_INSURANCE_AMT, A.NET_PRICE, A.TOTAL_PRICE, A.PRICE_ROUND,
                 A.CAPITAL_INSURANCE, A.INSURE_PRIORITY, A.EFFECTIVE_DATE, A.EXPIRE_DATE,
                 A.CONFIDENTIAL_STATUS, A.CREATE_DATE, A.CREATE_USER, A.UPDATE_DATE,
                 A.UPDATE_USER, A.INSURE_CAR_STATUS, C.CAR_NAME,C.CAR_MODEL,C.CAR_ENGINE ,I.COMPANY_FULLNAME
                FROM MA_INSURE_CAR A INNER JOIN MA_CAR C ON A.CAR_ID = C.CAR_ID INNER JOIN MA_INSURE_COMPANY I ON A.COMPANY_CODE = I.COMPANY_CODE";
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

        public InsureCarData GetItem(string code)
        {
            try
            {
                DBbase.Connect();
                string sql = @"SELECT A.INSURE_CAR_CODE, A.COMPANY_CODE, A.PACKAGE_NAME, A.CAR_ID,
                 A.INSURE_CATEGORY, A.INSURE_TYPE_REPAIR, A.CAR_YEAR, A.LIVE_COVERAGE_PEOPLE,
                 A.LIVE_COVERAGE_TIME, A.ASSET_TIME, A.DAMAGE_TO_VEHICLE,
                 A.MISSING_FIRE_CAR, A.FIRST_DAMAGE_PRICE, A.PERSONAL_ACCIDENT_AMT,
                 A.PERSONAL_ACCIDENT_PEOPLE, A.MEDICAL_FEE_AMT, A.MEDICAL_FEE_PEOPLE, 
                 A.DRIVER_INSURANCE_AMT, A.NET_PRICE, A.TOTAL_PRICE, A.PRICE_ROUND,
                 A.CAPITAL_INSURANCE, A.INSURE_PRIORITY, A.EFFECTIVE_DATE, A.EXPIRE_DATE,
                 A.CONFIDENTIAL_STATUS, A.CREATE_DATE, A.CREATE_USER, A.UPDATE_DATE,
                 A.UPDATE_USER, A.INSURE_CAR_STATUS, C.CAR_NAME,C.CAR_MODEL,C.CAR_ENGINE ,I.COMPANY_FULLNAME
                FROM MA_INSURE_CAR A INNER JOIN MA_CAR C ON A.CAR_ID = C.CAR_ID INNER JOIN MA_INSURE_COMPANY I ON A.COMPANY_CODE = I.COMPANY_CODE
                WHERE INSURE_CAR_CODE = '" + code + "'";

                MySqlCommand cmd = new MySqlCommand(sql, DBbase.con);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    InsureCarData item = new InsureCarData();
                    item.ASSET_TIME = Convert.ToDecimal(reader.GetString("ASSET_TIME"));
                    item.CAPITAL_INSURANCE = Convert.ToDecimal(reader.GetString("CAPITAL_INSURANCE"));
                    item.CAR_ID = Convert.ToInt32(reader.GetString("CAR_ID"));
                    item.CAR_MODEL = reader.GetString("CAR_MODEL");
                    item.CAR_NAME = reader.GetString("CAR_NAME");
                    item.COMPANY_CODE = reader.GetString("COMPANY_CODE");
                    item.COMPANY_FULLNAME = reader.GetString("COMPANY_FULLNAME");
                    item.CONFIDENTIAL_STATUS = reader.GetString("CONFIDENTIAL_STATUS");
                    item.DAMAGE_TO_VEHICLE = Convert.ToDecimal(reader.GetString("DAMAGE_TO_VEHICLE"));
                    item.DRIVER_INSURANCE_AMT = Convert.ToDecimal(reader.GetString("DRIVER_INSURANCE_AMT"));
                    item.EFFECTIVE_DATE = Convert.ToDateTime(reader.GetString("EFFECTIVE_DATE"));
                    item.EXPIRE_DATE = Convert.ToDateTime(reader.GetString("EXPIRE_DATE"));
                    item.FIRST_DAMAGE_PRICE = Convert.ToDecimal(reader.GetString("FIRST_DAMAGE_PRICE"));
                    item.INSURE_CAR_CODE = reader.GetString("INSURE_CAR_CODE");
                    item.INSURE_CAR_STATUS = reader.GetString("INSURE_CAR_STATUS");
                    item.INSURE_CATEGORY = reader.GetString("INSURE_CATEGORY");
                    item.INSURE_TYPE_REPAIR = reader.GetString("INSURE_TYPE_REPAIR");
                    item.LIVE_COVERAGE_PEOPLE = Convert.ToDecimal(reader.GetString("LIVE_COVERAGE_PEOPLE"));
                    item.LIVE_COVERAGE_TIME = Convert.ToDecimal(reader.GetString("LIVE_COVERAGE_TIME"));
                    item.MEDICAL_FEE_AMT = Convert.ToDecimal(reader.GetString("MEDICAL_FEE_AMT"));
                    item.MEDICAL_FEE_PEOPLE = Convert.ToInt32(reader.GetString("MEDICAL_FEE_PEOPLE"));
                    item.MISSING_FIRE_CAR = Convert.ToDecimal(reader.GetString("MISSING_FIRE_CAR"));
                    item.NET_PRICE = Convert.ToDecimal(reader.GetString("NET_PRICE"));
                    item.PACKAGE_NAME = reader.GetString("PACKAGE_NAME");
                    item.PERSONAL_ACCIDENT_AMT = Convert.ToDecimal(reader.GetString("PERSONAL_ACCIDENT_AMT"));
                    item.PERSONAL_ACCIDENT_PEOPLE = Convert.ToInt32(reader.GetString("PERSONAL_ACCIDENT_PEOPLE"));
                    item.PRICE_ROUND = Convert.ToDecimal(reader.GetString("PRICE_ROUND"));
                    item.TOTAL_PRICE = Convert.ToDecimal(reader.GetString("TOTAL_PRICE"));
                    item.COMPANY_CODE = reader.GetString("COMPANY_CODE");
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
    }
}
