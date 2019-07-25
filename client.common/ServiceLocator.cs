using client.common.SystemSettings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Net;
using System.Runtime.CompilerServices;

namespace client.common
{
    /// <summary>
    /// <para>概要：服务定位</para>
    /// </summary>
    public class ServiceLocator
    {
        #region 私有属性
        private static ServiceLocator instance = null;
        #endregion

        #region 公共方法、属性
        #region 公共方法
        /// <summary>
        /// 取得实例
        /// </summary>
        /// <returns>实例</returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ServiceLocator GetInstance()
        {
            if (instance == null)
            {
                instance = new ServiceLocator();
            }
            return instance;
        }
        #endregion

        private SystemSettingsInfo systemSettings;
        /// <summary>
        /// 系统配置
        /// </summary>
        public static SystemSettingsInfo SystemSettings
        {
            get { return GetInstance().systemSettings; }
            set { GetInstance().systemSettings = value; }
        }


        #endregion
    

        /// <summary>
        /// ServiceLocator构造方法
        /// </summary>
        private ServiceLocator()
        {

        }
    }
}
