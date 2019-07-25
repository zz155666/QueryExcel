namespace client.common.SystemSettings
{
    /// <summary>
    /// 系统配置信息
    /// </summary>
    public class SystemSettingsInfo
    {
        //public ServerUrl ServerUrl { get; set; }
        /// <summary>
        /// POS机注册
        /// </summary>
        public POSInfo POSInfo { get; set; }
        /// <summary>
        /// 登录
        /// </summary>
        public LoginInfo LoginInfo { get; set; }
        /// <summary>
        /// 数据同步
        /// </summary>
        public LastSynchTime LastSynchTime { get; set; }
        /// <summary>
        /// 代理
        /// </summary>
        public ProxyInfo ProxyInfo { get; set; }
    }
}
