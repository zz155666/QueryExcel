using client.common;
using client.common.SystemSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using static client.common.CommonOp;

namespace client.controll
{
    public   class StartingUtil
    {
        public static void InitSystemSettings()
        {
            try
            {
                ServiceLocator.SystemSettings = XMLUtil.XmlDeserialize<SystemSettingsInfo>(
                    ConfigureFile.GetXML(SystemFilePath.FilePathSystemSetting),
                    "SystemSettings");
            }
            catch (Exception ex)
            {
                WXLog.Error("读取系统参数配置文件失败", ex);
                throw new Exception(ex.Message);
            }
        }
        public bool SaveSystemSettinsConfig()
        {
            bool bReturn = false;
            try
            {
                bReturn =SaveXML(XMLUtil.XmlSerialize<SystemSettingsInfo>(ServiceLocator.SystemSettings, "SystemSettings"),
                    SystemFilePath.FilePathSystemSetting);
            }
            catch (Exception ex)
            {
                WXLog.Error("保存系统配置失败", ex);
                throw new Exception("保存系统配置失败");
            }
            return bReturn;
        }
        public static bool SaveXML(string xml, string filePath)
        {
            //todo
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            doc.Save(filePath);
            return true;
        }
        public static void CheckDbVersion()//检查数据库版本
        {
            int currentVersion = 1;
            int lastVersion = Convert.ToInt32(ServiceLocator.SystemSettings.ProxyInfo.DBVersion);
            if (lastVersion < currentVersion)
            {
                bool isSuccess = true;
            }
        }

        private static bool AddTable(string sql, string tablename)
        {
            bool isSuccess = true;
            try
            {
                int a = SQLiteHelper.ExecuteNonQuery(sql);
            }
            catch (System.Data.SQLite.SQLiteException ex)
            {
                string a = ex.Message;
                if (a.Contains("already exists"))
                {
                    isSuccess = true;
                    WXLog.Info(tablename + "已添加");
                }
                else if (a.Contains("duplicate"))
                {
                    isSuccess = true;
                    WXLog.Info(tablename + "已添加");
                }
                else
                {
                    isSuccess = false;
                    WXLog.Info("添加" + tablename + "失败,发生错误" + a);
                }
            }
            catch (Exception e)
            {
                isSuccess = false;
                WXLog.Info("添加" + tablename + "失败");
            }
            if (isSuccess)
            {
                WXLog.Info("添加" + tablename + "完成");
            }
            return isSuccess;
        }
        public static bool CheckActivte()
        {
            if (ServiceLocator.SystemSettings.ProxyInfo.DeviceCode == StringSecurity.MD5Encrypt(StringSecurity.RSAEncrypt(ServiceLocator.SystemSettings.ProxyInfo.Corpid) + "EC" + StringSecurity.RSAEncrypt(ServiceLocator.SystemSettings.ProxyInfo.CorpSrecret) + DateTime.Now.Year))
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
