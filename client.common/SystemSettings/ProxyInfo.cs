using System.Xml.Serialization;

namespace client.common.SystemSettings
{
    /// <summary>
    /// Pos信息
    /// </summary>
    public class ProxyInfo
    {
        /// <summary>
        ///  企业号
        /// </summary>
        [XmlAttribute("Tenant")]
        public string Corpid { get; set; }
        /// <summary>
        /// 接口秘钥
        /// </summary>
        [XmlAttribute("Branch")]
        public string CorpSrecret { get; set; }
        /// <summary>
        /// POS号
        /// </summary>
        [XmlAttribute("PosCode")]
        public string PosCode { get; set; }
        /// <summary>
        /// Pos密码
        /// </summary>
        [XmlAttribute("PosPwd")]
        public string PosPwd { get; set; }
        /// <summary>
        /// 设备编号
        /// </summary>
        [XmlAttribute("DeviceCode")]
        public string DeviceCode { get; set; }
        /// <summary>
        /// 数据库版本
        /// </summary>
        [XmlAttribute("DBVersion")]
        public string DBVersion { get; set; }
    }
}
