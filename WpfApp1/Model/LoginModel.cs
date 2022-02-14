using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Common;

namespace WpfApp1.Model
{
    public class LoginModel : NotifyBase
    {
        private string _userName;

        public string UserName //带通知的属性UserName
        {
            get { return _userName; }
            set 
            { 
                _userName = value; 
                this.DoNotify();
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                this.DoNotify();
            }
        }

        private string _validationCode;

        public string ValidationCode
        {
            get { return _validationCode; }
            set 
            { 
                _validationCode = value;
                this.DoNotify();
            }
        }



    }
}
