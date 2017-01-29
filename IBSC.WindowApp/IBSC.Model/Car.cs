using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBSC.Model
{
    public class Car
    {
        private string _item1;
        public string CAR_CODE
        {
            get { return _item1; }
            set { _item1 = value; }
        }

        private string _item2;
        public string CAR_NAME
        {
            get { return _item2; }
            set { _item2 = value; }
        }

        private string _item3;
        public string CAR_MODEL
        {
            get { return _item3; }
            set { _item3 = value; }
        }

        private string _item4;
        public string CAR_ENGINE
        {
            get { return _item4; }
            set { _item4 = value; }
        }

        private string _item5;
        public string CAR_REMARK
        {
            get { return _item5; }
            set { _item5 = value; }
        }

        private string _item6;
        public string CAR_STATUS
        {
            get { return _item6; }
            set { _item6 = value; }
        }
    }
}
