using System;
using System.Xml.Serialization;

namespace client.common.SystemSettings
{
    /// <summary>
    /// POS机注册信息（缓存至内存）
    /// </summary>
    public class POSInfo
    {
        /// <summary>
        ///  
        /// </summary>
        [XmlAttribute("EnterpriseFlag")]
        public string EnterpriseFlag { get; set; }
        /// <summary>
        ///  
        /// </summary>
        [XmlAttribute("EnterpriseID")]
        public Guid EnterpriseID { get; set; }
        /// <summary>
        ///  
        /// </summary>
        [XmlAttribute("WarehouseID")]
        public Guid WarehouseID { get; set; }
        /// <summary>
        ///  
        /// </summary>
        [XmlAttribute("POSID")]
        public Guid POSID { get; set; }
        /// <summary>
        ///  
        /// </summary>
        [XmlAttribute("POSNO")]
        public string POSNO { get; set; }
       
    }
}
