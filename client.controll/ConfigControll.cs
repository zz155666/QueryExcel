using client.dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.controll
{
   public class ConfigControll
    {
        private ClientDb _basicInfor;

        public ConfigControll()
        {
            _basicInfor = CurrUserLogin.CurrReadAllOpt.basicinfor;

        }
        public void SaveAllConfig(bool isautodownload,string hour,string min,string dir)
        {
            if (isautodownload)
            {
                CurrUserLogin.isautodownload = "1";
                SaveOpt("isautodownload","1");
            }else
            {
                CurrUserLogin.isautodownload = "0";
                SaveOpt("isautodownload", "0");
            }
            CurrUserLogin.hour = hour;
            SaveOpt("hour", hour);
            CurrUserLogin.min = min;
            SaveOpt("min", min);
            CurrUserLogin.downloaddir = dir;
            SaveOpt("downloaddir", dir);
        }
        public void SaveOpt(string name, string value)
        {
            var pp = (from oo in _basicInfor.ConFig
                      where oo.Key == name
                      select oo).ToList().FirstOrDefault();
            if (pp != null)
            {
                pp.Value = value;
            }
            else
            {
                ConFig posOpt = new ConFig();
                posOpt.Key = name;
                posOpt.Value = value;
                posOpt.ID = Guid.NewGuid().ToString();
                if (_basicInfor.Connection.State == ConnectionState.Closed)
                {
                    _basicInfor.Connection.Open();
                }
                _basicInfor.ConFig.InsertOnSubmit(posOpt);
            }
            if (_basicInfor.Connection.State == ConnectionState.Closed)
            {
                _basicInfor.Connection.Open();
            }
            _basicInfor.SubmitChanges();
        }
    }
}
