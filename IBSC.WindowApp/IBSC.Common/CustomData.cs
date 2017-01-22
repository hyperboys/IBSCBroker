using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBSC.Common
{
    [Serializable()]
    public class CustomData
    {
        private string innerXML = string.Empty;
        public string InnerXML
        {
            get { return innerXML; }
            set { innerXML = value; }
        }
    }
}
