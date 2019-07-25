using System.IO;
using System.Reflection;

namespace client.common
{
    /// <summary>
    /// <para>概要：文件路径</para>
    /// </summary>
    public sealed class SystemFilePath
    {

        /// <summary>
        /// 私有构造
        /// </summary>
        private SystemFilePath() { }

        #region 路径名称
        /// <summary>
        /// Nunit系统路径
        /// </summary>
        public static string NUnitTest_SystemRootPath = string.Empty;

        /// <summary>
        /// 执行文件路径名称
        /// </summary>
        public const string DirNameBin = "Bin";
        /// <summary>
        /// 设定文件路径名称
        /// </summary>
        public const string DirNameConf = "Conf";
        /// <summary>
        /// 设定文件路径（发布用）名称        
        /// </summary>
        public const string DirNameConfStatic = "ConfStatic";
        /// <summary>
        /// 数据路径名称
        /// </summary>
        public const string DirNameData = "Data";
        /// <summary>
        /// 模板路径名称
        /// </summary>
        public const string DirNameTemplate = "Template";
        /// <summary>
        /// 临时路径名称
        /// </summary>
        public const string DirNameTemp = "Temp";
        /// <summary>
        /// 测试Stub路径名称
        /// </summary>
        public const string DirNameTestResponse = "TestResponse";
        /// <summary>
        /// 资源路径名称
        /// </summary>
        public const string DirNameResource = "Resource";

        /// <summary>
        /// 数据路径名称--Pictures
        /// </summary>
        public const string DirNamePictures = "Pictures";
        /// <summary>
        /// 产品图片存放路径
        /// </summary>
        public const string GoodsImage = "GoodsImg";
        /// <summary>
        /// 报表存放路径
        /// </summary>
        public const string Report = "Report";
        /// <summary>
        /// 数据路径名称--MemberPhoto
        /// </summary>
        public const string DirNameMemberPhoto = "MemberPhoto";

        /// <summary>
        /// 信息路径名称
        /// </summary>
        public const string DirNameInfo = "Info";
        /// <summary>
        /// 同步通信数据文件夹名称
        /// </summary>
        public const string DirNameSync = "Sync";
        /// <summary>
        /// 同步通信数据文件夹名称
        /// </summary>
        public const string DirNameSyncRecv = "Recv";
        /// <summary>
        /// 同步通信数据文件夹名称
        /// </summary>
        public const string DirNameSyncSend = "Send";
        /// <summary>
        /// 异步通信数据文件夹名称
        /// </summary>
        public const string DirNameASync = "ASync";
        /// <summary>
        /// 异步通信数据文件夹名称
        /// </summary>
        public const string DirNameASyncSend = "Send";
        /// <summary>
        /// 异步通信数据文件夹名称
        /// </summary>
        public const string DirNameASyncRecv = "Recv";
        /// <summary>
        /// 字典数据文件夹名称
        /// </summary>
        public const string DirNameDic = "Dic";
        /// <summary>
        ///下载数据文件夹名称
        /// </summary>
        public const string DirNameDownload = "Download";
        /// <summary>
        /// 下载的文件名称
        /// </summary>
         public const string UpdateFileDownLoadName = "WposSetUp.exe";
         /// <summary>
        ///备份数据文件夹名称
        /// </summary>
        public const string DirNameBackUp = "BackUp";
        /// <summary>
        ///错误文档文件夹名称
        /// </summary>
        public const string DirNameErrorDoc = "ErrorDoc";
       
        /// <summary>
        /// WXMessageBox路径名称
        /// </summary>
        public const string DirNameLog = "Log";
        /// <summary>
        /// Nunit测试数据路径名称
        /// </summary>
        public const string NUnitTestData = "Test\\Data";
        /// <summary>
        /// 设定文件路径
        /// </summary>
        public static string DirConf
        {
            get { return Path.Combine(DirRoot, DirNameConf); }
        }
        /// <summary>
        /// （发布用）设定文件路径
        /// </summary>
        public static string DirConfStatic
        {
            get { return Path.Combine(DirRoot, DirNameConfStatic); }
        }
        /// <summary>
        /// 执行文件路径
        /// </summary>
        public static string DirBin
        {
            //get { return Path.Combine(DirRoot, DirNameBin); }
            get { return DirRoot; }
        }
        /// <summary>
        /// 数据路径
        /// </summary>
        public static string DirData
        {
            get { return Path.Combine(DirRoot, DirNameData); }
        }
        /// <summary>
        /// 模板路径
        /// </summary>
        public static string DirTemplate
        {
            get { return Path.Combine(DirData, DirNameTemplate); }
        }
        /// <summary>
        /// 数据临时路径
        /// </summary>
        public static string DirTemp
        {
            get { return Path.Combine(DirData, DirNameTemp); }
        }
        /// <summary>
        /// 同步通信数据文件接收路径
        /// </summary>
        public static string DirSyncRecv
        {
            get { return Path.Combine(Path.Combine(DirData, DirNameSync), DirNameSyncRecv); }
        }
        /// <summary>
        /// 同步通信数据文件发送路径
        /// </summary>
        public static string DirSyncSend
        {
            get { return Path.Combine(Path.Combine(DirData, DirNameSync), DirNameSyncSend); }
        }
        /// <summary>
        /// 异步通信数据文件发送路径
        /// </summary>
        public static string DirASyncSend
        {
            get { return Path.Combine(Path.Combine(DirData, DirNameASync), DirNameASyncSend); }
        }
        /// <summary>
        /// 异步通信数据文件接收路径
        /// </summary>
        public static string DirASyncRecv
        {
            get { return Path.Combine(Path.Combine(DirData, DirNameASync), DirNameASyncRecv); }
        }
        /// <summary>
        /// 测试Stub路径
        /// </summary>
        public static string DirTestResponse
        {
            get { return Path.Combine(DirData, DirNameTestResponse); }
        }
        /// <summary>
        /// 资源路径
        /// </summary>
        public static string DirResource
        {
            get { return Path.Combine(DirData, DirNameResource); }
        }
        /// <summary>
        /// Pictures路径
        /// </summary>
        public static string DirPictures
        {
            get { return Path.Combine(DirData, DirNamePictures); }
        }
        public static string GoodsPictures
        {
            get { return Path.Combine(DirData, GoodsImage); }
        }
        public static string PosReport
        {
            get { return Path.Combine(DirData, Report); }
        }
        /// <summary>
        /// MemberPhoto路径
        /// </summary>
        public static string DirMemberPhoto
        {
            get { return Path.Combine(DirData, DirNameMemberPhoto); }
        }
        /// <summary>
        ///下载路径
        /// </summary>
        public static string DirDownload
        {
            get { return Path.Combine(DirRoot, DirNameDownload); }
        }
        /// <summary>
        /// 下载下来的文件存放路径
        /// </summary>
          public static string UpdateFileName
        {
            get { return Path.Combine(DirDownload, UpdateFileDownLoadName); }
        }
        public static string DirBackUp
        {
            get { return Path.Combine(DirRoot, DirNameBackUp); }
        }
        /// <summary>
        /// 错误文档路径
        /// </summary>
        public static string DirErrorDoc
        {
            get { return Path.Combine(DirRoot, DirNameErrorDoc); }
        }

        /// <summary>
        /// WXMessageBox路径
        /// </summary>
        public static string DirLog
        {
            get { return Path.Combine(DirRoot, DirNameLog); }
        }
        /// <summary>
        /// Nunit测试路径
        /// </summary>
        public static string NUnit_DirTestData
        {
            get { return Path.Combine(DirRoot, NUnitTestData); }
        }
        private static string currentRoot = string.Empty;
        /// <summary>
        /// Client端的安装程序根目录（通常C:\Program Files\RP Tools\）
        /// </summary>
        public static string DirRoot
        {
            get
            {
                try
                {
                    /*
                    if (!string.IsNullOrEmpty(currentRoot)) 
                        return currentRoot;

                    currentRoot = SysRegistry.GeApplicationtRoot();
                    if (string.IsNullOrEmpty(currentRoot))
                    {
                        currentRoot = Path.GetDirectoryName(
                            Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
                        return currentRoot;
                        
                    }
                    else
                    {
                        return currentRoot;
                    }*/
                    return System.IO.Directory.GetCurrentDirectory();
                }
                catch
                {
                    //return @"C:\YunJiPos\Bin";
                    return @".";
                }
            }
        }

        /// <summary>
        /// 前缀
        /// </summary>
        public static string Prefix
        {
            get
            {
                if (string.IsNullOrEmpty(NUnitTest_SystemRootPath))
                {
                    return Path.GetDirectoryName(
                        Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)
                        ).Replace('\\', '￥');
                }
                else
                {
                    return NUnitTest_SystemRootPath.Replace('\\', '￥');
                }
            }
        }
        #endregion

        #region 文件路径
        /// <summary>
        /// POS进程文件名
        /// </summary>
        public static string FilePathExePOS
        {
            get { return Path.Combine(DirBin, ExeNamePOS); }
        }

        /// <summary>
        /// 通信进程文件名
        /// </summary>
        public static string FilePathExeTransition
        {
            get { return Path.Combine(DirRoot, ExeNameTransition); }
        }


        /// <summary>
        /// 更新进程文件名
        /// </summary>
        public static string FilePathExeRefresh
        {
            get { return Path.Combine(DirBin, ExeNameRefresh); }
        }


        /// <summary>
        /// 数据库文件名Debug
        /// </summary>
        public static string FilePathSqliteDBDebug
        {
            get { return Path.Combine(DirBin, SqliteDBDebug); }
        }

        /// <summary>
        /// 数据库文件名
        /// </summary>
        public static string FilePathSqliteDB
        {
            get { return Path.Combine(DirBin, SqliteDB); }
        }
        
        /// <summary>
        /// Liveupdate进程文件名
        /// </summary>
        public static string FilePathExeLiveUpdate
        {
            get { return Path.Combine(DirBin, ExeNameLiveUpdate); }
        }
        
        /// <summary>
        /// Log设定路径文件
        /// </summary>
        public static string FilePathLoggingSetting
        {
            get { return Path.Combine(DirConfStatic, FileLogging); }
        }

        /// <summary>
        ///  Message配置路径文件
        /// </summary>
        public static string FilePathMessageSetting
        {
            get { return Path.Combine(DirConfStatic, FileMessageSetting); }
        }
        
        /// <summary>
        ///  SystemConfig配置路径文件
        /// </summary>
        public static string FilePathSystemConfigSetting
        {
            get { return Path.Combine(DirConfStatic, FileSystemConfigSetting); }
        }

        /// <summary>
        ///  Common配置路径文件
        /// </summary>
        public static string FilePathCommonConfigSetting
        {
            get { return Path.Combine(DirConfStatic, FileCommonConfigSetting); }
        }

        /// <summary>
        ///  系统配置路径文件
        /// </summary>
        public static string FilePathSystemSetting
        {
            get { return Path.Combine(DirConf, FileSystemSetting); }
        }
        /// <summary>
        ///  快捷键配置路径文件
        /// </summary>
        public static string FilePathShortcutkeysConfigSetting
        {
            get { return Path.Combine(DirConf, FileShortcutkeysConfigSetting); }
        }

        /// <summary>
        ///  本机配置路径文件
        /// </summary>
        public static string FilePathMachineConfigSetting
        {
            get { return Path.Combine(DirConf, FileHardwareConfigSetting); }
        }
        /// <summary>
        ///  全局配置路径文件
        /// </summary>
        public static string FilePathGlobalConfigSetting
        {
            get { return Path.Combine(DirConf, FileGlobalConfigSetting); }
        }
        /// <summary>
        ///  Transition配置路径文件
        /// </summary>
        public static string FilePathTransitionConfigSetting
        {
            get { return Path.Combine(DirConfStatic, FileTransitionConfigSetting); }
        }

        /// <summary>
        ///  LiveUpdates配置路径文件
        /// </summary>
        public static string FilePathLiveUpdates
        {
            get { return Path.Combine(DirRoot, FileLiveUpdates); }
        }

        #endregion

        #region 文件名、进程名
        /// <summary>
        /// Log配置文件名
        /// </summary>
        public const string FileLogging = "logging.config";

        /// <summary>
        /// Message配置文件名
        /// </summary>
        public const string FileMessageSetting = "Message.xml";

        /// <summary>
        /// System配置文件名
        /// </summary>
        public const string FileSystemConfigSetting = "SystemConfig.xml";       

        /// <summary>
        /// Common配置文件名
        /// </summary>
        public const string FileCommonConfigSetting = "CommonConfig.xml";

        /// <summary>
        /// 系统配置文件名
        /// </summary>
        public const string FileSystemSetting = "SystemSettings.xml";

        /// <summary>
        /// 快捷键配置文件名
        /// </summary>
        public const string FileShortcutkeysConfigSetting = "Shortcutkeys.xml";

        /// <summary>
        /// 硬件配置文件名
        /// </summary>
        public const string FileHardwareConfigSetting = "MachineSetting.xml";

        /// <summary>
        /// 全局业务参数文件名
        /// </summary>
        public const string FileGlobalConfigSetting = "GlobalSetting.xml";

        /// <summary>
        /// TransitionConfig配置文件名
        /// </summary>
        public const string FileTransitionConfigSetting = "TransitionConfig.xml";

        /// <summary>
        /// TransitionConfig配置文件名
        /// </summary>
        public const string FileLiveUpdates = "LiveUpdates.xml";

        /// <summary>
        /// POS主程序进程名
        /// </summary>
        public const string ExeNamePOS = "wpos.app.pos.exe";

        /// <summary>
        /// 通信程序进程名
        /// </summary>
        public const string ExeNameTransition = "wpos.app.transition.exe";

        /// <summary>
        /// 更新程序进程名
        /// </summary>
        public const string ExeNameLiveUpdate = "wpos.app.liveupdate.exe";

        /// <summary>
        /// 刷新程序进程名
        /// </summary>
        public const string ExeNameRefresh = "wpos.app.refresh.exe";

        /// <summary>
        /// sqlitedb
        /// </summary>
        public const string SqliteDBDebug = "clientdb.db";//YunJi.UI.Debug.dll

        /// <summary>
        /// sqlitedb
        /// </summary>
        public const string SqliteDB = "clientdb.db";
        
        #endregion
    }

}
