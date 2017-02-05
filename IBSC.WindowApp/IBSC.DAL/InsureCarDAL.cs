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
    }
}
