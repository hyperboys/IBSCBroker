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
                 A.UPDATE_USER, A.INSURE_CAR_STATUS, C.CAR_CODE,C.CAR_NAME,C.CAR_MODEL,C.CAR_ENGINE,C.CAR_IMAGE ,I.COMPANY_FULLNAME
                FROM MA_INSURE_CAR A INNER JOIN MA_CAR C ON A.CAR_ID = C.CAR_ID INNER JOIN MA_INSURE_COMPANY I ON A.COMPANY_CODE = I.COMPANY_CODE";
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

        public DataTable GetAllCondition(string carYear, string carName, string carModel)
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
                 A.UPDATE_USER, A.INSURE_CAR_STATUS, C.CAR_CODE,C.CAR_NAME,C.CAR_MODEL,C.CAR_ENGINE,C.CAR_IMAGE ,I.COMPANY_FULLNAME, I.COMPANY_CODE, I.COMPANY_PATH_PIC 
                FROM MA_INSURE_CAR A INNER JOIN MA_CAR C ON A.CAR_ID = C.CAR_ID INNER JOIN MA_INSURE_COMPANY I ON A.COMPANY_CODE = I.COMPANY_CODE
               WHERE A.INSURE_CAR_STATUS = 'A' AND A.CAR_YEAR ='" + carYear + "' AND C.CAR_NAME = '" + carName + "' AND C.CAR_MODEL = '" + carModel + "' "
                + " ORDER BY I.COMPANY_CODE ";

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
                 A.UPDATE_USER, A.INSURE_CAR_STATUS, C.CAR_CODE,C.CAR_NAME,C.CAR_MODEL,C.CAR_ENGINE ,I.COMPANY_FULLNAME
                FROM MA_INSURE_CAR A INNER JOIN MA_CAR C ON A.CAR_ID = C.CAR_ID INNER JOIN MA_INSURE_COMPANY I ON A.COMPANY_CODE = I.COMPANY_CODE
                WHERE INSURE_CAR_CODE = '" + code + "'";

                SqlCommand cmd = new SqlCommand(sql, DBbase.con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    InsureCarData item = new InsureCarData();
                    item.ASSET_TIME = Convert.ToDecimal(reader["ASSET_TIME"].ToString());
                    item.CAPITAL_INSURANCE = Convert.ToDecimal(reader["CAPITAL_INSURANCE"].ToString());
                    item.CAR_ID = Convert.ToInt32(reader["CAR_ID"].ToString());
                    item.CAR_CODE = reader["CAR_CODE"].ToString();
                    item.CAR_MODEL = reader["CAR_MODEL"].ToString();
                    item.CAR_NAME = reader["CAR_NAME"].ToString();
                    item.CAR_ENGINE = reader["CAR_ENGINE"].ToString();
                    item.CAR_YEAR = reader["CAR_YEAR"].ToString();
                    item.COMPANY_CODE = reader["COMPANY_CODE"].ToString();
                    item.COMPANY_FULLNAME = reader["COMPANY_FULLNAME"].ToString();
                    item.CONFIDENTIAL_STATUS = reader["CONFIDENTIAL_STATUS"].ToString();
                    item.DAMAGE_TO_VEHICLE = Convert.ToDecimal(reader["DAMAGE_TO_VEHICLE"].ToString());
                    item.DRIVER_INSURANCE_AMT = Convert.ToDecimal(reader["DRIVER_INSURANCE_AMT"].ToString());
                    item.EFFECTIVE_DATE = Convert.ToDateTime(reader["EFFECTIVE_DATE"].ToString());
                    item.EXPIRE_DATE = Convert.ToDateTime(reader["EXPIRE_DATE"].ToString());
                    item.FIRST_DAMAGE_PRICE = Convert.ToDecimal(reader["FIRST_DAMAGE_PRICE"].ToString());
                    item.INSURE_CAR_CODE = reader["INSURE_CAR_CODE"].ToString();
                    item.INSURE_CAR_STATUS = reader["INSURE_CAR_STATUS"].ToString();
                    item.INSURE_CATEGORY = reader["INSURE_CATEGORY"].ToString();
                    item.INSURE_TYPE_REPAIR = reader["INSURE_TYPE_REPAIR"].ToString();
                    item.LIVE_COVERAGE_PEOPLE = Convert.ToDecimal(reader["LIVE_COVERAGE_PEOPLE"].ToString());
                    item.LIVE_COVERAGE_TIME = Convert.ToDecimal(reader["LIVE_COVERAGE_TIME"].ToString());
                    item.MEDICAL_FEE_AMT = Convert.ToDecimal(reader["MEDICAL_FEE_AMT"].ToString());
                    item.MEDICAL_FEE_PEOPLE = Convert.ToInt32(reader["MEDICAL_FEE_PEOPLE"].ToString());
                    item.MISSING_FIRE_CAR = Convert.ToDecimal(reader["MISSING_FIRE_CAR"].ToString());
                    item.NET_PRICE = Convert.ToDecimal(reader["NET_PRICE"].ToString());
                    item.PACKAGE_NAME = reader["PACKAGE_NAME"].ToString();
                    item.PERSONAL_ACCIDENT_AMT = Convert.ToDecimal(reader["PERSONAL_ACCIDENT_AMT"].ToString());
                    item.PERSONAL_ACCIDENT_PEOPLE = Convert.ToInt32(reader["PERSONAL_ACCIDENT_PEOPLE"].ToString());
                    item.PRICE_ROUND = Convert.ToDecimal(reader["PRICE_ROUND"].ToString());
                    item.TOTAL_PRICE = Convert.ToDecimal(reader["TOTAL_PRICE"].ToString());
                    item.COMPANY_CODE = reader["COMPANY_CODE"].ToString();
                    item.INSURE_PRIORITY = Convert.ToInt32(reader["INSURE_PRIORITY"].ToString());
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

        public void Insert(InsureCarData item)
        {
            try
            {
                MemberData member = (MemberData)DataCommon.Get("DATA.MEMBER");

                DBbase.Connect();
                StringBuilder sql = new StringBuilder();
                sql.Append(@"INSERT INTO MA_INSURE_CAR (INSURE_CAR_CODE, COMPANY_CODE, PACKAGE_NAME, CAR_ID, INSURE_CATEGORY,INSURE_TYPE_REPAIR,CAR_YEAR,LIVE_COVERAGE_PEOPLE,
                LIVE_COVERAGE_TIME,ASSET_TIME,DAMAGE_TO_VEHICLE,MISSING_FIRE_CAR,FIRST_DAMAGE_PRICE,PERSONAL_ACCIDENT_AMT,PERSONAL_ACCIDENT_PEOPLE,MEDICAL_FEE_AMT,
                MEDICAL_FEE_PEOPLE,DRIVER_INSURANCE_AMT,NET_PRICE,TOTAL_PRICE,PRICE_ROUND,CAPITAL_INSURANCE,INSURE_PRIORITY,EFFECTIVE_DATE,EXPIRE_DATE,CONFIDENTIAL_STATUS,
                INSURE_CAR_STATUS,CREATE_DATE,CREATE_USER,UPDATE_DATE,UPDATE_USER)  VALUES (");

                string INSURE_CAR_CODE = DateTime.Now.ToString("yyyyMMdd") + "-" + item.COMPANY_CODE.ToUpper() + "-" + item.PACKAGE_NAME;
                INSURE_CAR_CODE += "-" + item.CAR_ID + "-" + item.INSURE_CATEGORY;
                INSURE_CAR_CODE += item.INSURE_TYPE_REPAIR == "ศูนย์" ? "C" : "G";

                sql.Append(" '" + INSURE_CAR_CODE + "',");
                sql.Append(" '" + item.COMPANY_CODE.ToUpper() + "',");
                sql.Append(" '" + item.PACKAGE_NAME + "',");
                sql.Append(" '" + item.CAR_ID + "',");
                sql.Append(" '" + item.INSURE_CATEGORY + "',");
                sql.Append(" '" + item.INSURE_TYPE_REPAIR + "',");

                sql.Append(" '" + item.CAR_YEAR + "',");
                sql.Append(" '" + item.LIVE_COVERAGE_PEOPLE + "',");
                sql.Append(" '" + item.LIVE_COVERAGE_TIME + "',");
                sql.Append(" '" + item.ASSET_TIME + "',");
                sql.Append(" '" + item.DAMAGE_TO_VEHICLE + "',");

                sql.Append(" '" + item.MISSING_FIRE_CAR + "',");
                sql.Append(" '" + item.FIRST_DAMAGE_PRICE + "',");
                sql.Append(" '" + item.PERSONAL_ACCIDENT_AMT + "',");
                sql.Append(" '" + item.PERSONAL_ACCIDENT_PEOPLE + "',");
                sql.Append(" '" + item.MEDICAL_FEE_AMT + "',");

                sql.Append(" '" + item.MEDICAL_FEE_PEOPLE + "',");
                sql.Append(" '" + item.DRIVER_INSURANCE_AMT + "',");
                sql.Append(" '" + item.NET_PRICE + "',");
                sql.Append(" '" + item.TOTAL_PRICE + "',");
                sql.Append(" '" + item.PRICE_ROUND + "',");

                sql.Append(" '" + item.CAPITAL_INSURANCE + "',");
                sql.Append(" '" + item.INSURE_PRIORITY + "',");
                sql.Append(" '" + ConvertCommon.ConvertDateTime(item.EFFECTIVE_DATE) + "',");
                sql.Append(" '" + ConvertCommon.ConvertDateTime(item.EXPIRE_DATE) + "',");
                sql.Append(" '" + item.CONFIDENTIAL_STATUS + "',");

                sql.Append(" '" + item.INSURE_CAR_STATUS + "',");
                sql.Append(" '" + ConvertCommon.ConvertDateTime(DateTime.Now) + "',");
                sql.Append(" '" + member.MEMBER_USER + "',");
                sql.Append(" '" + ConvertCommon.ConvertDateTime(DateTime.Now) + "',");
                sql.Append(" '" + member.MEMBER_USER + "')");

                SqlCommand cmd = new SqlCommand(sql.ToString(), DBbase.con);
                cmd.ExecuteNonQuery();
                DBbase.DisConnect();
            }
            catch (SqlException exception)
            {
                if (exception.Number == 1062) // Cannot insert duplicate key row in object error
                {

                }
                else
                    throw exception; // throw exception if this exception is unexpected
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertList(List<InsureCarData> listItem)
        {
            try
            {
                MemberData member = (MemberData)DataCommon.Get("DATA.MEMBER");
                int row = 1;

                SqlCommand cmd;
                string query = "";

                StringBuilder sql;
                foreach (InsureCarData item in listItem)
                {
                    DBbase.Connect();
                    sql = new StringBuilder();
                    sql.Append(@"INSERT INTO MA_INSURE_CAR (INSURE_CAR_CODE, COMPANY_CODE, PACKAGE_NAME, CAR_ID, INSURE_CATEGORY,INSURE_TYPE_REPAIR,CAR_YEAR,LIVE_COVERAGE_PEOPLE,
                LIVE_COVERAGE_TIME,ASSET_TIME,DAMAGE_TO_VEHICLE,MISSING_FIRE_CAR,FIRST_DAMAGE_PRICE,PERSONAL_ACCIDENT_AMT,PERSONAL_ACCIDENT_PEOPLE,MEDICAL_FEE_AMT,
                MEDICAL_FEE_PEOPLE,DRIVER_INSURANCE_AMT,NET_PRICE,TOTAL_PRICE,PRICE_ROUND,CAPITAL_INSURANCE,INSURE_PRIORITY,EFFECTIVE_DATE,EXPIRE_DATE,CONFIDENTIAL_STATUS,
                INSURE_CAR_STATUS,CREATE_DATE,CREATE_USER,UPDATE_DATE,UPDATE_USER)  VALUES ");
                    string INSURE_CAR_CODE = DateTime.Now.ToString("yyyyMMdd") + "-" + item.COMPANY_CODE.ToUpper() + "-" + item.PACKAGE_NAME;
                    INSURE_CAR_CODE += "-" + item.CAR_ID + "-" + item.INSURE_CATEGORY;
                    INSURE_CAR_CODE += (item.INSURE_TYPE_REPAIR == "ศูนย์") ? "C" : "G" + "-" + item.CAR_YEAR;

                    sql.Append("( '" + INSURE_CAR_CODE + "',");
                    sql.Append(" '" + item.COMPANY_CODE.ToUpper() + "',");
                    sql.Append(" '" + item.PACKAGE_NAME + "',");
                    sql.Append(" '" + item.CAR_ID + "',");
                    sql.Append(" '" + item.INSURE_CATEGORY + "',");
                    sql.Append(" '" + item.INSURE_TYPE_REPAIR + "',");

                    sql.Append(" '" + item.CAR_YEAR + "',");
                    sql.Append(" '" + item.LIVE_COVERAGE_PEOPLE + "',");
                    sql.Append(" '" + item.LIVE_COVERAGE_TIME + "',");
                    sql.Append(" '" + item.ASSET_TIME + "',");
                    sql.Append(" '" + item.DAMAGE_TO_VEHICLE + "',");

                    sql.Append(" '" + item.MISSING_FIRE_CAR + "',");
                    sql.Append(" '" + item.FIRST_DAMAGE_PRICE + "',");
                    sql.Append(" '" + item.PERSONAL_ACCIDENT_AMT + "',");
                    sql.Append(" '" + item.PERSONAL_ACCIDENT_PEOPLE + "',");
                    sql.Append(" '" + item.MEDICAL_FEE_AMT + "',");

                    sql.Append(" '" + item.MEDICAL_FEE_PEOPLE + "',");
                    sql.Append(" '" + item.DRIVER_INSURANCE_AMT + "',");
                    sql.Append(" '" + item.NET_PRICE + "',");
                    sql.Append(" '" + item.TOTAL_PRICE + "',");
                    sql.Append(" '" + item.PRICE_ROUND + "',");

                    sql.Append(" '" + item.CAPITAL_INSURANCE + "',");
                    sql.Append(" '" + item.INSURE_PRIORITY + "',");
                    sql.Append(" '" + ConvertCommon.ConvertDateTime(item.EFFECTIVE_DATE) + "',");
                    sql.Append(" '" + ConvertCommon.ConvertDateTime(item.EXPIRE_DATE) + "',");
                    sql.Append(" '" + item.CONFIDENTIAL_STATUS + "',");

                    sql.Append(" '" + item.INSURE_CAR_STATUS + "',");
                    sql.Append(" '" + ConvertCommon.ConvertDateTime(DateTime.Now) + "',");
                    sql.Append(" '" + member.MEMBER_USER + "',");
                    sql.Append(" '" + ConvertCommon.ConvertDateTime(DateTime.Now) + "',");
                    sql.Append(" '" + member.MEMBER_USER + "') ");

                    row++;

                    try
                    {
                        query = sql.ToString();
                        cmd = new SqlCommand(query.Remove(query.Length - 1), DBbase.con);
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException exception)
                    {
                        if (exception.Number == 1062) // Cannot insert duplicate key row in object error
                        {

                        }
                        else
                            throw exception; // throw exception if this exception is unexpected
                    }
                    DBbase.DisConnect();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(InsureCarData oldItem, InsureCarData newItem)
        {
            try
            {
                MemberData member = (MemberData)DataCommon.Get("DATA.MEMBER");
                DBbase.Connect();
                StringBuilder sql = new StringBuilder();

                string INSURE_CAR_CODE = DateTime.Now.ToString("yyyyMMdd") + "_" + newItem.COMPANY_CODE + "_" + newItem.PACKAGE_NAME;
                INSURE_CAR_CODE += "_" + newItem.CAR_CODE + "_" + newItem.CAR_NAME + "_" + newItem.CAR_MODEL + "_" + newItem.CAR_ENGINE + "_" + newItem.INSURE_CATEGORY;
                INSURE_CAR_CODE += "_" + newItem.INSURE_TYPE_REPAIR;

                sql.Append("UPDATE MA_INSURE_CAR SET INSURE_CAR_CODE = '" + INSURE_CAR_CODE + "',");
                sql.Append(" COMPANY_CODE = '" + newItem.COMPANY_CODE + "',");
                sql.Append(" PACKAGE_NAME = '" + newItem.PACKAGE_NAME + "',");
                sql.Append(" CAR_ID = '" + newItem.CAR_ID + "',");
                sql.Append(" INSURE_CATEGORY = '" + newItem.INSURE_CATEGORY + "',");
                sql.Append(" INSURE_TYPE_REPAIR = '" + newItem.INSURE_TYPE_REPAIR + "',");
                sql.Append(" CAR_YEAR = '" + newItem.CAR_YEAR + "',");
                sql.Append(" LIVE_COVERAGE_PEOPLE = '" + newItem.LIVE_COVERAGE_PEOPLE + "',");
                sql.Append(" LIVE_COVERAGE_TIME = '" + newItem.LIVE_COVERAGE_TIME + "',");
                sql.Append(" ASSET_TIME = '" + newItem.ASSET_TIME + "',");
                sql.Append(" INSURE_TYPE_REPAIR = '" + newItem.INSURE_TYPE_REPAIR + "',");
                sql.Append(" DAMAGE_TO_VEHICLE = '" + newItem.DAMAGE_TO_VEHICLE + "',");
                sql.Append(" MISSING_FIRE_CAR = '" + newItem.MISSING_FIRE_CAR + "',");
                sql.Append(" FIRST_DAMAGE_PRICE = '" + newItem.FIRST_DAMAGE_PRICE + "',");
                sql.Append(" PERSONAL_ACCIDENT_AMT = '" + newItem.PERSONAL_ACCIDENT_AMT + "',");
                sql.Append(" PERSONAL_ACCIDENT_PEOPLE = '" + newItem.PERSONAL_ACCIDENT_PEOPLE + "',");
                sql.Append(" MEDICAL_FEE_AMT = '" + newItem.MEDICAL_FEE_AMT + "',");
                sql.Append(" MEDICAL_FEE_PEOPLE = '" + newItem.MEDICAL_FEE_PEOPLE + "',");
                sql.Append(" DRIVER_INSURANCE_AMT = '" + newItem.DRIVER_INSURANCE_AMT + "',");
                sql.Append(" NET_PRICE = '" + newItem.NET_PRICE + "',");
                sql.Append(" TOTAL_PRICE = '" + newItem.TOTAL_PRICE + "',");
                sql.Append(" PRICE_ROUND = '" + newItem.PRICE_ROUND + "',");
                sql.Append(" CAPITAL_INSURANCE = '" + newItem.CAPITAL_INSURANCE + "',");
                sql.Append(" INSURE_PRIORITY = '" + newItem.INSURE_PRIORITY + "',");
                sql.Append(" EFFECTIVE_DATE = '" + ConvertCommon.ConvertDateTime(newItem.EFFECTIVE_DATE) + "',");
                sql.Append(" EXPIRE_DATE = '" + ConvertCommon.ConvertDateTime(newItem.EXPIRE_DATE) + "',");
                sql.Append(" CONFIDENTIAL_STATUS = '" + newItem.CONFIDENTIAL_STATUS + "',");
                sql.Append(" UPDATE_DATE = '" + ConvertCommon.ConvertDateTime(DateTime.Now) + "',");
                sql.Append(" UPDATE_USER = '" + member.MEMBER_USER + "'");
                sql.Append(" WHERE INSURE_CAR_CODE = '" + oldItem.INSURE_CAR_CODE + "'");
                SqlCommand cmd = new SqlCommand(sql.ToString(), DBbase.con);
                cmd.ExecuteNonQuery();
                DBbase.DisConnect();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateOnExcel(InsureCarData newItem)
        {
            try
            {
                MemberData member = (MemberData)DataCommon.Get("DATA.MEMBER");
                DBbase.Connect();
                StringBuilder sql = new StringBuilder();

                sql.Append("UPDATE MA_INSURE_CAR SET ");
                sql.Append(" COMPANY_CODE = '" + newItem.COMPANY_CODE + "',");
                sql.Append(" PACKAGE_NAME = '" + newItem.PACKAGE_NAME + "',");
                sql.Append(" CAR_ID = '" + newItem.CAR_ID + "',");
                sql.Append(" INSURE_CATEGORY = '" + newItem.INSURE_CATEGORY + "',");
                //sql.Append(" INSURE_TYPE_REPAIR = '" + newItem.INSURE_TYPE_REPAIR + "',");
                sql.Append(" CAR_YEAR = '" + newItem.CAR_YEAR + "',");
                sql.Append(" LIVE_COVERAGE_PEOPLE = '" + newItem.LIVE_COVERAGE_PEOPLE + "',");
                sql.Append(" LIVE_COVERAGE_TIME = '" + newItem.LIVE_COVERAGE_TIME + "',");
                sql.Append(" ASSET_TIME = '" + newItem.ASSET_TIME + "',");
                sql.Append(" INSURE_TYPE_REPAIR = '" + newItem.INSURE_TYPE_REPAIR + "',");
                sql.Append(" DAMAGE_TO_VEHICLE = '" + newItem.DAMAGE_TO_VEHICLE + "',");
                sql.Append(" MISSING_FIRE_CAR = '" + newItem.MISSING_FIRE_CAR + "',");
                sql.Append(" FIRST_DAMAGE_PRICE = '" + newItem.FIRST_DAMAGE_PRICE + "',");
                sql.Append(" PERSONAL_ACCIDENT_AMT = '" + newItem.PERSONAL_ACCIDENT_AMT + "',");
                sql.Append(" PERSONAL_ACCIDENT_PEOPLE = '" + newItem.PERSONAL_ACCIDENT_PEOPLE + "',");
                sql.Append(" MEDICAL_FEE_AMT = '" + newItem.MEDICAL_FEE_AMT + "',");
                sql.Append(" MEDICAL_FEE_PEOPLE = '" + newItem.MEDICAL_FEE_PEOPLE + "',");
                sql.Append(" DRIVER_INSURANCE_AMT = '" + newItem.DRIVER_INSURANCE_AMT + "',");
                sql.Append(" NET_PRICE = '" + newItem.NET_PRICE + "',");
                sql.Append(" TOTAL_PRICE = '" + newItem.TOTAL_PRICE + "',");
                sql.Append(" PRICE_ROUND = '" + newItem.PRICE_ROUND + "',");
                sql.Append(" CAPITAL_INSURANCE = '" + newItem.CAPITAL_INSURANCE + "',");
                sql.Append(" INSURE_PRIORITY = '" + newItem.INSURE_PRIORITY + "',");
                sql.Append(" EFFECTIVE_DATE = '" + ConvertCommon.ConvertDateTime(newItem.EFFECTIVE_DATE) + "',");
                sql.Append(" EXPIRE_DATE = '" + ConvertCommon.ConvertDateTime(newItem.EXPIRE_DATE) + "',");
                sql.Append(" CONFIDENTIAL_STATUS = '" + newItem.CONFIDENTIAL_STATUS + "',");
                sql.Append(" UPDATE_DATE = '" + ConvertCommon.ConvertDateTime(DateTime.Now) + "',");
                sql.Append(" UPDATE_USER = '" + member.MEMBER_USER + "'");
                sql.Append(" WHERE 	COMPANY_CODE = '" + newItem.COMPANY_CODE + "'");
                sql.Append(" AND 	PACKAGE_NAME = '" + newItem.PACKAGE_NAME + "'");
                sql.Append(" AND 	CAR_ID = '" + newItem.CAR_ID + "'");
                sql.Append(" AND 	INSURE_CATEGORY = '" + newItem.INSURE_CATEGORY + "'");
                sql.Append(" AND 	INSURE_TYPE_REPAIR = '" + newItem.INSURE_TYPE_REPAIR + "'");
                sql.Append(" AND 	CAR_YEAR = '" + newItem.CAR_YEAR + "'");
                sql.Append(" AND DAMAGE_TO_VEHICLE = '" + newItem.DAMAGE_TO_VEHICLE + "'");
                SqlCommand cmd = new SqlCommand(sql.ToString(), DBbase.con);
                cmd.ExecuteNonQuery();
                DBbase.DisConnect();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckItem(InsureCarData item)
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
                 A.UPDATE_USER, A.INSURE_CAR_STATUS, C.CAR_CODE,C.CAR_NAME,C.CAR_MODEL,C.CAR_ENGINE ,I.COMPANY_FULLNAME
                FROM MA_INSURE_CAR A INNER JOIN MA_CAR C ON A.CAR_ID = C.CAR_ID INNER JOIN MA_INSURE_COMPANY I ON A.COMPANY_CODE = I.COMPANY_CODE
                WHERE I.COMPANY_CODE = '" + item.COMPANY_CODE + "' AND A.PACKAGE_NAME = '" + item.PACKAGE_NAME + "' AND A.CAR_ID = '" + item.CAR_ID
                                        + "' AND A.INSURE_CATEGORY = '" + item.INSURE_CATEGORY + "' AND A.INSURE_TYPE_REPAIR = '"
                                        + item.INSURE_TYPE_REPAIR + "' AND A.CAR_YEAR = '" + item.CAR_YEAR + "'"
                                        + "AND A.CAPITAL_INSURANCE = '" + item.CAPITAL_INSURANCE + "'";

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

        public DataTable GetComboBoxCarYear()
        {
            try
            {
                DBbase.Connect();
                string sql = "SELECT DISTINCT CAR_YEAR FROM MA_INSURE_CAR WHERE INSURE_CAR_STATUS = 'A'";
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

        public DataTable GetComboBoxCarName(string carYear)
        {
            try
            {
                DBbase.Connect();
                string sql = "SELECT DISTINCT C.CAR_NAME FROM MA_INSURE_CAR I INNER JOIN MA_CAR C ON I.CAR_ID = C.CAR_ID WHERE INSURE_CAR_STATUS = 'A' AND CAR_YEAR ='" + carYear + "'";
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

        public DataTable GetComboBoxCarModel(string carYear, string carName)
        {
            try
            {
                DBbase.Connect();
                string sql = "SELECT DISTINCT C.CAR_MODEL FROM MA_INSURE_CAR I INNER JOIN MA_CAR C ON I.CAR_ID = C.CAR_ID WHERE INSURE_CAR_STATUS = 'A' AND CAR_YEAR ='" + carYear + "' AND CAR_NAME = '" + carName + "'";
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

        public DataTable GetComboBoxCarEngine(string carYear, string carName, string carModel)
        {
            try
            {
                DBbase.Connect();
                string sql = "SELECT DISTINCT C.CAR_ENGINE FROM MA_INSURE_CAR I INNER JOIN MA_CAR C ON I.CAR_ID = C.CAR_ID WHERE INSURE_CAR_STATUS = 'A' AND CAR_YEAR ='" + carYear + "' AND CAR_NAME = '" + carName + "' AND CAR_MODEL = '" + carModel + "'";
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
