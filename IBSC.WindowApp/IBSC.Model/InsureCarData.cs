using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBSC.Model
{
    public class InsureCarData
    {
        private string _item1;
        public string INSURE_CAR_CODE
        {
            get { return _item1; }
            set { _item1 = value; }
        }

        private string _item2;
        public string COMPANY_CODE
        {
            get { return _item2; }
            set { _item2 = value; }
        }

        private string _item3;
        public string PACKAGE_NAME
        {
            get { return _item3; }
            set { _item3 = value; }
        }

        private int _item4 = 0;
        public int CAR_ID
        {
            get { return _item4; }
            set { _item4 = value; }
        }

        private string _item5;
        public string INSURE_CATEGORY
        {
            get { return _item5; }
            set { _item5 = value; }
        }

        private string _item6;
        public string INSURE_TYPE_REPAIR
        {
            get { return _item6; }
            set { _item6 = value; }
        }

        private decimal _item7;
        public decimal LIVE_COVERAGE_PEOPLE
        {
            get { return _item7; }
            set { _item7 = value; }
        }

        private decimal _item8;
        public decimal LIVE_COVERAGE_TIME
        {
            get { return _item8; }
            set { _item8 = value; }
        }

        private decimal _item9;
        public decimal ASSET_TIME
        {
            get { return _item9; }
            set { _item9 = value; }
        }

        private decimal _item10;
        public decimal DAMAGE_TO_VEHICLE
        {
            get { return _item10; }
            set { _item10 = value; }
        }

        private decimal _item11;
        public decimal MISSING_FIRE_CAR
        {
            get { return _item11; }
            set { _item11 = value; }
        }

        private decimal _item12;
        public decimal FIRST_DAMAGE_PRICE
        {
            get { return _item12; }
            set { _item12 = value; }
        }

        private decimal _item13;
        public decimal PERSONAL_ACCIDENT_AMT
        {
            get { return _item13; }
            set { _item13 = value; }
        }

        private int _item14;
        public int PERSONAL_ACCIDENT_PEOPLE
        {
            get { return _item14; }
            set { _item14 = value; }
        }

        private decimal _item18;
        public decimal MEDICAL_FEE_AMT
        {
            get { return _item18; }
            set { _item18 = value; }
        }

        private int _item19;
        public int MEDICAL_FEE_PEOPLE
        {
            get { return _item19; }
            set { _item19 = value; }
        }

        private decimal _item20;
        public decimal DRIVER_INSURANCE_AMT
        {
            get { return _item20; }
            set { _item20 = value; }
        }

        private decimal _item21;
        public decimal NET_PRICE
        {
            get { return _item21; }
            set { _item21 = value; }
        }

        private decimal _item22;
        public decimal TOTAL_PRICE
        {
            get { return _item22; }
            set { _item22 = value; }
        }

        private decimal _item23;
        public decimal PRICE_ROUND
        {
            get { return _item23; }
            set { _item23 = value; }
        }

        private DateTime _item24;
        public DateTime EFFECTIVE_DATE
        {
            get { return _item24; }
            set { _item24 = value; }
        }

        private DateTime _item25;
        public DateTime EXPIRE_DATE
        {
            get { return _item25; }
            set { _item25 = value; }
        }

        private string _item26;
        public string CONFIDENTIAL_STATUS
        {
            get { return _item26; }
            set { _item26 = value; }
        }

        private DateTime _item27;
        public DateTime CREATE_DATE
        {
            get { return _item27; }
            set { _item27 = value; }
        }

        private string _item28;
        public string CREATE_USER
        {
            get { return _item28; }
            set { _item28 = value; }
        }

        private DateTime _item29;
        public DateTime UPDATE_DATE
        {
            get { return _item29; }
            set { _item29 = value; }
        }

        private string _item30;
        public string UPDATE_USER
        {
            get { return _item30; }
            set { _item30 = value; }
        }

        private string _item31;
        public string INSURE_CAR_STATUS
        {
            get { return _item31; }
            set { _item31 = value; }
        }

        private decimal _item32;
        public decimal CAPITAL_INSURANCE
        {
            get { return _item32; }
            set { _item32 = value; }
        }

        private string _item33;
        public string CAR_NAME
        {
            get { return _item33; }
            set { _item33 = value; }
        }

        private string _item34;
        public string CAR_MODEL
        {
            get { return _item34; }
            set { _item34 = value; }
        }

        private string _item35;
        public string CAR_ENGINE
        {
            get { return _item35; }
            set { _item35 = value; }
        }

        private string _item36;
        public string COMPANY_FULLNAME
        {
            get { return _item36; }
            set { _item36 = value; }
        }

        private int _item37;
        public int INSURE_PRIORITY
        {
            get { return _item37; }
            set { _item37 = value; }
        }

        private string _item38;
        public string CAR_YEAR
        {
            get { return _item38; }
            set { _item38 = value; }
        }

        private string _item39;
        public string CAR_CODE
        {
            get { return _item39; }
            set { _item39 = value; }
        }

        private string exception = string.Empty;
        public string EXCEPTION
        {
            get { return exception; }
            set
            {
                if (exception == "")
                {
                    exception = value;
                }
            }
        }

        private int exception_index = 0;
        public int EXCEPTION_INDEX
        {
            get { return exception_index; }
            set
            {
                if (exception_index == 0)
                {
                    exception_index = value;
                }
            }
        }

        private int index_excel = 0;
        public int INDEX_EXCEL
        {
            get { return index_excel; }
            set
            {
                if (index_excel == 0)
                {
                    index_excel = value;
                }
            }
        }
    }
}
