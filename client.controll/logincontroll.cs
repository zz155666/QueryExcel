using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.controll
{
    public class logincontroll
    {
        public bool login(string username,string pwd)
        {
            var list = from k in CurrUserLogin.CurrReadAllOpt.basicinfor.User
                       where k.Account == username && k.PwD == pwd
                       select k.ID;
            var p = list.Count();
            if (p>0)
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
