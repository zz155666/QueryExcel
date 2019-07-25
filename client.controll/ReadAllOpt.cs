using client.common;
using client.dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.controll
{
    public class ReadAllOpt
    {
        public ClientDb basicinfor;
        /// <summary>
        /// 构造函数
        /// </summary>
        public ReadAllOpt()
        {
            IDbConnection db = ReadAllOpt.GetConnection();

            basicinfor = new ClientDb(db);
            ReadPosOptValue();
        }
        public void ReadPosOptValue()
        {
            var pp = (from o in basicinfor.ConFig
                      select o).ToList();
            CurrUserLogin.isautodownload = FindValue("isautodownload", "0", pp);
            CurrUserLogin.downloaddir= FindValue("downloaddir", "", pp);
            if (string.IsNullOrEmpty(CurrUserLogin.downloaddir))
            {
                CurrUserLogin.downloaddir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            }
            CurrUserLogin.lastdownloaddir = FindValue("lastdownloaddir", "", pp);
            if (string.IsNullOrEmpty(CurrUserLogin.lastdownloaddir))
            {
                CurrUserLogin.lastdownloaddir = CurrUserLogin.downloaddir;
            }
            CurrUserLogin.lastupdatetime=Convert.ToDateTime(FindValue("lastupdatetime", DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss"), pp));
            CurrUserLogin.hour = FindValue("hour", "24", pp);
            CurrUserLogin.min= FindValue("min", "00", pp);
            DateTime endtime = DateTime.Now.AddDays(-7);
            CurrUserLogin.dowload = (from oo in basicinfor.Record
                      where oo.Downtime > endtime
                      select oo).ToList();
        }
        /// <summary>
        /// 本地数据库全称
        /// </summary>
        public static string BasicFileConn
        {
            get { return string.Format("Data Source =\"{0}\";", SystemFilePath.DirBin + @"\clientdb.db"); }
        }
        /// <summary>
        /// 读取sqlite连接数据库
        /// </summary>
        /// <returns></returns>
        public static IDbConnection GetConnection()
        {
            var filename = "";
            filename = BasicFileConn;
            return new System.Data.SQLite.SQLiteConnection(filename) as IDbConnection;
        }
        public static string FindValue(string key, string defvalue, List<ConFig> p)
        {
            ConFig myPosOpt = p.ToList().FindAll(pp => pp.Key.ToUpper() == key.ToUpper()).ToList().FirstOrDefault();

            if (myPosOpt != null)
            {
                try
                {
                    return myPosOpt.Value;
                }
                catch (Exception)
                {

                    return defvalue;
                }

            }
            else
            {
                return defvalue;
            }

        }
        /// <summ
    }
}
