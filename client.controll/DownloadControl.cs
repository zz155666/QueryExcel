using client.common;
using client.dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace client.controll
{
   public class DownloadControl
    {
        private ClientDb _basicInfor;
        public DownloadControl()
        {
            _basicInfor = CurrUserLogin.CurrReadAllOpt.basicinfor;
        }
        public void Delete(string id)
        {
            var pp = (from oo in _basicInfor.Record
                      where oo.ID == id
                      select oo).ToList().FirstOrDefault();
            if (pp!=null)
            {
                _basicInfor.Record.DeleteOnSubmit(pp);
                _basicInfor.SubmitChanges();
            }
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
                _basicInfor.ConFig.InsertOnSubmit(posOpt);
            }
            _basicInfor.SubmitChanges();
        }
        public void SaveDownloadToDB(TelRecord tel,string path)
        {
            Record record = new Record();
            record.ID = Guid.NewGuid().ToString();
            record.StartTime = tel.starttime.ToString("yyyy-MM-dd HH:mm:ss");
            record.CallTTnO = tel.calltono;
            record.URL = tel.path;
            record.Downtime = DateTime.Now;
            record.MD5 = tel.md5;
            record.Path = path;
            _basicInfor.Record.InsertOnSubmit(record);
            CurrUserLogin.dowload.Add(record);
            _basicInfor.SubmitChanges();
        }
        public void Alldown(List<TelRecord> tels)
        {
            WebClient download = new WebClient();
            DateTime endtime = DateTime.Now.AddDays(-31);
            var pp = (from oo in _basicInfor.Record
                      where oo.Downtime> endtime
                      select oo).ToList();
            foreach (var tel in tels)
            {
                var rec = pp.FindAll(p => p.CallTTnO == tel.calltono & p.StartTime == tel.starttime.ToString("yyyy-MM-dd HH:mm:ss"));
                if (rec.Count>0)
                {
                    continue;
                }
                try
                {
                    if (string.IsNullOrEmpty(tel.path))
                    {
                        continue;
                    }
                    string path = Path.Combine(CurrUserLogin.downloaddir, tel.calltono + " " + tel.starttime.ToString("yyyy-MM-dd HH：mm：ss") + ".mp3");
                    download.DownloadFile(tel.path, path);
                    Record record = new Record();
                    record.ID = Guid.NewGuid().ToString();
                    record.StartTime = tel.starttime.ToString("yyyy-MM-dd HH:mm:ss");
                    record.CallTTnO = tel.calltono;
                    record.URL = tel.path;
                    record.Downtime = DateTime.Now;
                    record.MD5 = tel.md5;
                    record.Path = path;
                    if (_basicInfor.Connection.State == ConnectionState.Closed)
                    {
                        _basicInfor.Connection.Open();
                    }
                    _basicInfor.Record.InsertOnSubmit(record);
                    CurrUserLogin.dowload.Add(record);
                }
                catch (Exception e)
                {
                    WXLog.Error("下载"+tel.path+"文件出错", e);
                }
              
            }
            CurrUserLogin.lastupdatetime = DateTime.Now;
            SaveOpt("lastupdatetime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (_basicInfor.Connection.State== ConnectionState.Closed)
            {
                _basicInfor.Connection.Open();
            }
            _basicInfor.SubmitChanges();
        }
    }
}
