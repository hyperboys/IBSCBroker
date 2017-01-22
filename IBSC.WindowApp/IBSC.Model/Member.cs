using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBSC.Model
{
    public class Member
    {
        private string _memberUser;
        public string MEMBER_USER
        {
            get { return _memberUser; }
            set { _memberUser = value; }
        }

        private string _memberPassword;
        public string MEMBER_PASSWORD
        {
            get { return _memberPassword; }
            set { _memberPassword = value; }
        }

        private string _memberName;
        public string MEMBER_NAME
        {
            get { return _memberName; }
            set { _memberName = value; }
        }

        private string _memberSurename;
        public string MEMBER_SURENAME
        {
            get { return _memberSurename; }
            set { _memberSurename = value; }
        }

        private string _memberStatus;
        public string MEMBER_STATUS
        {
            get { return _memberStatus; }
            set { _memberStatus = value; }
        }
    }
}
