using client.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace client.controll
{
    /// <summary>
    /// 系统全局信息
    /// </summary>
    public class CurrUserLogin
    {
        private static CurrUserLogin _instance = null;
        private ReadAllOpt _readAllOpt = null;
        /// <summary>
        /// 全局信息
        /// </summary>
        public static ReadAllOpt CurrReadAllOpt
        {
            get { return GetInstance()._readAllOpt; }
            set { GetInstance()._readAllOpt = value; }
        }
        private string _downloaddir;
        /// <summary>
        /// 下载路径
        /// </summary>
        public static string downloaddir
        {
            get { return GetInstance()._downloaddir; }
            set { GetInstance()._downloaddir = value; }
        }
        private DateTime _lastupdatetime;
        /// <summary>
        /// 上次更新时间
        /// </summary>
        public static DateTime lastupdatetime
        {
            get { return GetInstance()._lastupdatetime; }
            set { GetInstance()._lastupdatetime = value; }
        }
        private bool _isdownloading;
        public static bool isdownloading
        {
            get { return GetInstance()._isdownloading; }
            set { GetInstance()._isdownloading = value; }
        }
        private string _lastdownloaddir;
        /// <summary>
        /// 下载路径
        /// </summary>
        public static string lastdownloaddir
        {
            get { return GetInstance()._lastdownloaddir; }
            set { GetInstance()._lastdownloaddir = value; }
        }
        private string _isautodownload;
        /// <summary>
        /// 是否定时下载 0 否  1 是
        /// </summary>
        public static string isautodownload
        {
            get { return GetInstance()._isautodownload; }
            set { GetInstance()._isautodownload = value; }
        }
        private string _hour;
        /// <summary>
        /// 定时下载小时
        /// </summary>
        public static string hour
        {
            get { return GetInstance()._hour; }
            set { GetInstance()._hour = value; }
        }
        private string _min;
        /// <summary>
        /// 定时下载分钟
        /// </summary>
        public static string min
        {
            get { return GetInstance()._min; }
            set { GetInstance()._min = value; }
        }
        private List<Record> _dowload;
        public static List<Record> dowload
        {
            get { return GetInstance()._dowload; }
            set { GetInstance()._dowload = value; }
        }
        /// <summary>
        /// 取得实例
        /// </summary>
        /// <returns>实例</returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static CurrUserLogin GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CurrUserLogin();
            }
            return _instance;
        }
    }
}
