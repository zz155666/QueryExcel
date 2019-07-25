using System;
using System.Xml.Serialization;

namespace client.common.SystemSettings
{
    /// <summary>
    /// 登录信息
    /// </summary>
    public class LoginInfo
    {
        /// <summary>
        ///  
        /// </summary>
        [XmlAttribute("LoginNames")]
        public string LoginNames { get; set; }
        /// <summary>
        ///  
        /// </summary>
        [XmlAttribute("LastTime")]
        public DateTime LastTime { get; set; }
        /// <summary>
        ///   <!-- 模式 1在线0离线 -->
        /// </summary>
        [XmlAttribute("OnlineMode")]
        public bool OnlineMode { get; set; }
    }
}
