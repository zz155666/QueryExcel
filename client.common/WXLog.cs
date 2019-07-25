using System;
using System.IO;
using System.Reflection;
using System.Text;
using log4net;
using log4net.Appender;
using log4net.Repository;

namespace client.common
{
#pragma warning disable 1591

    public static class WXLog
    {
        public static void Error(object message)
        {
            Log.Instance.Error(message);
        }
        public static void Error(object message, Exception exception)
        {
            Log.Instance.Error(message, exception);
        }
        public static void Info(object message)
        {
            Log.Instance.Info(message);
        }
        public static void Info(object message, Exception exception)
        {
            Log.Instance.Info(message, exception);
        }
        public static void Debug(object message)
        {
            Log.Instance.Debug(message);
        }
        public static void Debug(object message, Exception exception)
        {
            Log.Instance.Debug(message, exception);
        }

        public static void Warn(object message)
        {
            Log.Instance.Warn(message);
        }
        public static void Warn(object message, Exception exception)
        {
            Log.Instance.Warn(message, exception);
        }

        public static void Fatal(object message)
        {
            Log.Instance.Fatal(message);
        }
        public static void Fatal(object message, Exception exception)
        {
            Log.Instance.Fatal(message, exception);
        }
    }

    /// <summary>
    /// <para>概要：Log</para>
    /// </summary>
    public class Log
    {
        private static Log currentLog = null;


        #region Static Public Method


        #endregion

        #region Logger

        /// <summary>
        /// 设置进程所使用的Log
        /// </summary>
        /// <param name="settingName">配置名称</param>
        public static void SetLogger(string settingName)
        {
            SetLogger(settingName, "POS"+DateTime.Now.ToString("yyyyMMddHH"));
        }
        /// <summary>
        /// 设置进程所使用的Log
        /// </summary>
        /// <param name="settingName">配置名称</param>
        /// <param name="logfileName">WXMessageBox文件名（无须指定后缀）</param>
        public static void SetLogger(string settingName, string logfileName)
        {

            if (string.IsNullOrEmpty(settingName))
            {
                throw new Exception("Log4j的配置名称不存在。");
            }
            if (string.IsNullOrEmpty(logfileName))
            {
                logfileName = settingName;
            }
            ILog log = GetLogger(settingName, logfileName);
            currentLog = new Log(log);
        }

        /// <summary>
        /// 取得实例        
        /// </summary>
        /// <param name="settingName">配置名称</param>
        /// <returns>WXMessageBox实例</returns>
        protected static Log GetInstance(string settingName)
        {
            return GetInstance(settingName, settingName);
        }
        /// <summary>
        /// 取得实例
        /// </summary>
        /// <param name="settingName">配置名称</param>
        /// <param name="logfileName">WXMessageBox文件名（无须指定后缀）</param>
        /// <returns>WXMessageBox实例</returns>
        protected static Log GetInstance(string settingName, string logfileName)
        {
            if (string.IsNullOrEmpty(settingName))
            {
                throw new Exception("Log4j的配置名称不存在。");
            }
            ILog log = GetLogger(settingName, logfileName);
            return new Log(log);
        }

        /// <summary>
        /// 取得实例
        /// 在调用前需要使用SetLogger设置
        /// </summary>
        /// <returns>WXMessageBox实例</returns>
        public static Log Instance
        {
            get
            {
                if (currentLog == null)
                {
                    return GetInstance("dummy");
                }
                return currentLog;
            }
        }
        /// <summary>
        /// 取得Log4j实例
        /// </summary>
        /// <param name="settingName">配置名称</param>
        /// <param name="logfileName">WXMessageBox文件名</param>
        /// <returns>Log4j实例</returns>
        protected static ILog GetLogger(string settingName, string logfileName)
        {
            //Log文件的路径
            string path = SystemFilePath.FilePathLoggingSetting;

            log4net.Config.XmlConfigurator.Configure(new FileInfo(path));

            //Log文件名
            string logfilePath = SystemFilePath.DirLog + "\\" + logfileName + ".log";
            foreach (ILoggerRepository repository in log4net.LogManager.GetAllRepositories())
            {
                foreach (IAppender appender in repository.GetAppenders())
                {
                    if (appender.Name.IndexOf("_Template_") >= 0)
                    {
                        FileAppender fileAppender = appender as FileAppender;
                        if (fileAppender != null)
                        {
                            fileAppender.File = logfilePath;
                            fileAppender.LockingModel = new log4net.Appender.FileAppender.MinimalLock();
                            fileAppender.ActivateOptions();
                        }
                    }
                }
            }
            ILog log = log4net.LogManager.GetLogger(settingName);

            return log;
        }

        private ILog log = null;
        private Log(ILog pLog)
        {
            log = pLog;
        }

        /// <summary>
        /// 按文件名设置
        /// </summary>
        /// <returns>Log实例</returns>
        public static Log GetFileOutInstance(string pOutputFileName)
        {
            try
            {
                return new Log(pOutputFileName);
            }
            catch (Exception)
            {
                return Log.GetInstance("dummy");
            }
        }

        private bool bFileOut = false;
        private string outFileName = null;
        private Log(string pFileName)
        {
            outFileName = pFileName;
            bFileOut = true;
        }

        /// <summary>
        /// 方法开始WXMessageBox
        /// </summary>
        /// <param name="methodBase">System.Reflection.MethodBase.GetCurrentMethod()</param>
        /// <param name="paraObj">方法调用参数</param>
        public void MethodStart(MethodBase methodBase, params object[] paraObj)
        {
            try
            {
                String str = "开始 " + methodBase.ReflectedType.FullName + ".";
                if (methodBase.Name.IndexOf(".ctor") == 0)
                {
                    str += methodBase.DeclaringType.Name + "(";
                }
                else
                {
                    str += methodBase.Name + "(";
                }
                ParameterInfo[] para = methodBase.GetParameters();
                for (int cnt = 0; cnt < para.Length; cnt++)
                {
                    if (cnt > 0)
                    {
                        str += ", ";
                    }
                    str += (para[cnt].IsOut) ? "out " : "";
                    str += para[cnt].ParameterType.Name + " {";
                    str += (paraObj.Length > cnt) ? paraObj[cnt] : "null";
                    str += "}";

                }
                str += ")";
                this.Debug(str);
            }
            catch (Exception ex)
            {
                this.Info("(Method开始记录WXMessageBox)", ex);
            }
        }
        /// <summary>
        /// 方法终了WXMessageBox
        /// </summary>
        /// <param name="methodBase">System.Reflection.MethodBase.GetCurrentMethod()を渡してください。</param>
        public void MethodEnd(MethodBase methodBase)
        {
            try
            {
                String str = "終了 " + methodBase.ReflectedType.FullName + ".";
                if (methodBase.Name.IndexOf(".ctor") == 0)
                {
                    str += methodBase.DeclaringType.Name;
                }
                else
                {
                    str += methodBase.Name;
                }
                this.Debug(str);
            }
            catch (Exception ex)
            {
                this.Info("(メソッド終了ログ出力がおかしいです。)", ex);
            }
        }

        public void FileOut(object message)
        {
            try
            {
                File.AppendAllText(outFileName, message + "\r\n", Encoding.Unicode);
            }
            catch (Exception) { }
        }

        public void FileOut(object message, Exception exception)
        {
            try
            {
                File.AppendAllText(outFileName, message + "\r\n", Encoding.Unicode);
                File.AppendAllText(outFileName, exception.Message + "\r\n", Encoding.Unicode);
                File.AppendAllText(outFileName, exception.StackTrace + "\r\n", Encoding.Unicode);
            }
            catch (Exception) { }
        }

        public void FileOut(IFormatProvider provider, string format, params object[] args)
        {
            try
            {
                File.AppendAllText(outFileName, string.Format(provider, format, args) + "\r\n", Encoding.Unicode);
            }
            catch (Exception) { }
        }

        public void FileOut(string format, object arg0, object arg1, object arg2)
        {
            try
            {
                File.AppendAllText(outFileName, string.Format(format, arg0, arg1, arg2) + "\r\n", Encoding.Unicode);
            }
            catch (Exception) { }
        }

        public void FileOut(string format, object arg0, object arg1)
        {
            try
            {
                File.AppendAllText(outFileName, string.Format(format, arg0, arg1) + "\r\n", Encoding.Unicode);
            }
            catch (Exception) { }
        }

        public void FileOut(string format, object arg0)
        {
            try
            {
                File.AppendAllText(outFileName, string.Format(format, arg0) + "\r\n", Encoding.Unicode);
            }
            catch (Exception) { }
        }

        public void FileOut(string format, params object[] args)
        {
            try
            {
                File.AppendAllText(outFileName, string.Format(format, args) + "\r\n", Encoding.Unicode);
            }
            catch (Exception) { }
        }
        #endregion

        #region ILog 成员方法


        public void Debug(object message, Exception exception)
        {
            if (bFileOut)
            {
                FileOut(message, exception);
            }
            else
            {
                log.Debug(message, exception);
            }
        }

        public void Debug(object message)
        {
            if (bFileOut)
            {
                FileOut(message);
            }
            else
            {
                log.Debug(message);
            }
        }

        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (bFileOut)
            {
                FileOut(provider, format, args);
            }
            else
            {
                log.DebugFormat(provider, format, args);
            }
        }

        public void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
            if (bFileOut)
            {
                FileOut(format, arg0, arg1, arg2);
            }
            else
            {
                log.DebugFormat(format, arg0, arg1, arg2);
            }
        }

        public void DebugFormat(string format, object arg0, object arg1)
        {
            if (bFileOut)
            {
                FileOut(format, arg0, arg1);
            }
            else
            {
                log.DebugFormat(format, arg0, arg1);
            }
        }

        public void DebugFormat(string format, object arg0)
        {
            if (bFileOut)
            {
                FileOut(format, arg0);
            }
            else
            {
                log.DebugFormat(format, arg0);
            }
        }

        public void DebugFormat(string format, params object[] args)
        {
            if (bFileOut)
            {
                FileOut(format, args);
            }
            else
            {
                log.DebugFormat(format, args);
            }
        }

        public void Error(object message, Exception exception)
        {
            if (bFileOut)
            {
                FileOut(message, exception);
            }
            else
            {
                log.Error(message, exception);
            }
        }

        public void Error(object message)
        {
            if (bFileOut)
            {
                FileOut(message);
            }
            else
            {
                log.Error(message);
            }
        }

        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (bFileOut)
            {
                FileOut(provider, format, args);
            }
            else
            {
                log.ErrorFormat(provider, format, args);
            }
        }

        public void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            if (bFileOut)
            {
                FileOut(format, arg0, arg1, arg2);
            }
            else
            {
                log.ErrorFormat(format, arg0, arg1, arg2);
            }
        }

        public void ErrorFormat(string format, object arg0, object arg1)
        {
            if (bFileOut)
            {
                FileOut(format, arg0, arg1);
            }
            else
            {
                log.ErrorFormat(format, arg0, arg1);
            }
        }

        public void ErrorFormat(string format, object arg0)
        {
            if (bFileOut)
            {
                FileOut(format, arg0);
            }
            else
            {
                log.ErrorFormat(format, arg0);
            }
        }

        public void ErrorFormat(string format, params object[] args)
        {
            if (bFileOut)
            {
                FileOut(format, args);
            }
            else
            {
                log.ErrorFormat(format, args);
            }
        }

        public void Fatal(object message, Exception exception)
        {
            if (bFileOut)
            {
                FileOut(message, exception);
            }
            else
            {
                log.Fatal(message, exception);
            }
        }

        public void Fatal(object message)
        {
            if (bFileOut)
            {
                FileOut(message);
            }
            else
            {
                log.Fatal(message);
            }
        }

        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (bFileOut)
            {
                FileOut(provider, format, args);
            }
            else
            {
                log.FatalFormat(provider, format, args);
            }
        }

        public void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
            if (bFileOut)
            {
                FileOut(format, arg0, arg1, arg2);
            }
            else
            {
                log.FatalFormat(format, arg0, arg1, arg2);
            }
        }

        public void FatalFormat(string format, object arg0, object arg1)
        {
            if (bFileOut)
            {
                FileOut(format, arg0, arg1);
            }
            else
            {
                log.FatalFormat(format, arg0, arg1);
            }
        }

        public void FatalFormat(string format, object arg0)
        {
            if (bFileOut)
            {
                FileOut(format, arg0);
            }
            else
            {
                log.FatalFormat(format, arg0);
            }
        }

        public void FatalFormat(string format, params object[] args)
        {
            if (bFileOut)
            {
                FileOut(format, args);
            }
            else
            {
                log.FatalFormat(format, args);
            }
        }

        public void Info(object message, Exception exception)
        {
            if (bFileOut)
            {
                FileOut(message, exception);
            }
            else
            {
                log.Info(message, exception);
            }
        }

        public void Info(object message)
        {
            if (bFileOut)
            {
                FileOut(message);
            }
            else
            {
                log.Info(message);
            }
        }

        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (bFileOut)
            {
                FileOut(provider, format, args);
            }
            else
            {
                log.InfoFormat(provider, format, args);
            }
        }

        public void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            if (bFileOut)
            {
                FileOut(format, arg0, arg1, arg2);
            }
            else
            {
                log.InfoFormat(format, arg0, arg1, arg2);
            }
        }

        public void InfoFormat(string format, object arg0, object arg1)
        {
            if (bFileOut)
            {
                FileOut(format, arg0, arg1);
            }
            else
            {
                log.InfoFormat(format, arg0, arg1);
            }
        }

        public void InfoFormat(string format, object arg0)
        {
            if (bFileOut)
            {
                FileOut(format, arg0);
            }
            else
            {
                log.InfoFormat(format, arg0);
            }
        }

        public void InfoFormat(string format, params object[] args)
        {
            if (bFileOut)
            {
                FileOut(format, args);
            }
            else
            {
                log.InfoFormat(format, args);
            }
        }

        public bool IsDebugEnabled
        {
            get { return log.IsDebugEnabled; }
        }

        public bool IsErrorEnabled
        {
            get { return log.IsErrorEnabled; }
        }

        public bool IsFatalEnabled
        {
            get { return log.IsFatalEnabled; }
        }

        public bool IsInfoEnabled
        {
            get { return log.IsInfoEnabled; }
        }

        public bool IsWarnEnabled
        {
            get { return log.IsWarnEnabled; }
        }

        public void Warn(object message, Exception exception)
        {
            if (bFileOut)
            {
                FileOut(message, exception);
            }
            else
            {
                log.Warn(message, exception);
            }
        }

        public void Warn(object message)
        {
            if (bFileOut)
            {
                FileOut(message);
            }
            else
            {
                log.Warn(message);
            }
        }

        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            if (bFileOut)
            {
                FileOut(provider, format, args);
            }
            else
            {
                log.WarnFormat(provider, format, args);
            }
        }

        public void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
            if (bFileOut)
            {
                FileOut(format, arg0, arg1, arg2);
            }
            else
            {
                log.WarnFormat(format, arg0, arg1, arg2);
            }
        }

        public void WarnFormat(string format, object arg0, object arg1)
        {
            if (bFileOut)
            {
                FileOut(format, arg0, arg1);
            }
            else
            {
                log.WarnFormat(format, arg0, arg1);
            }
        }

        public void WarnFormat(string format, object arg0)
        {
            if (bFileOut)
            {
                FileOut(format, arg0);
            }
            else
            {
                log.WarnFormat(format, arg0);
            }
        }

        public void WarnFormat(string format, params object[] args)
        {
            if (bFileOut)
            {
                FileOut(format, args);
            }
            else
            {
                log.WarnFormat(format, args);
            }
        }

        #endregion

        #region ILoggerWrapper 方法

        public log4net.Core.ILogger Logger
        {
            get { return log.Logger; }
        }

        #endregion



    }
}
