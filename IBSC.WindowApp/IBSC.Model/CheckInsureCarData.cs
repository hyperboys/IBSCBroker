using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBSC.Model
{
    public class CheckInsureCarData : InsureCarData
    {
        private string _item1;
        public string SELECT_INSURANCE_CODE
        {
            get { return _item1; }
            set { _item1 = value; }
        }

        private string _item2;
        public string CUSTOMER_NAME
        {
            get { return _item2; }
            set { _item2 = value; }
        }

        private string _item3;
        public string CUSTOMER_EMAIL
        {
            get { return _item3; }
            set { _item3 = value; }
        }

        private string _item4;
        public string CUSTOMER_TEL
        {
            get { return _item4; }
            set { _item4 = value; }
        }

        private string _item5;
        public string SELECT_INSURANCE_STATUS
        {
            get { return _item5; }
            set { _item5 = value; }
        }

        private string _item6;
        public string WINDOW_IP
        {
            get { return _item6; }
            set { _item6 = value; }
        }

        private string _item7;
        public string AGENT_CODE
        {
            get { return _item7; }
            set { _item7 = value; }
        }

        private string _item8;
        public string TRANSACTION_TYPE
        {
            get { return _item8; }
            set { _item8 = value; }
        }

        private string _item9;
        public string SELECT_INSURANCE_STATUS_NAME
        {
            get { return _item9; }
            set { _item9 = value; }
        }

        private string _item10;
        public string REMARK
        {
            get { return _item10; }
            set { _item10 = value; }
        }
        
    }
}
