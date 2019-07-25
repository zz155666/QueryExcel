using System;
using System.Xml.Serialization;

namespace client.common.SystemSettings
{
    /// <summary>
    /// 
    /// </summary>
    public class LastSynchTime
    {
        /// <summary>
        ///  
        /// </summary>
        [XmlAttribute("Authority")]
        public DateTime Authority { get; set; }
        /// <summary>
        ///  
        /// </summary>
        [XmlAttribute("Base")]
        public DateTime Base { get; set; }
        /// <summary>
        ///  
        /// </summary>
        [XmlAttribute("Organization")]
        public DateTime Organization { get; set; }
        /// <summary>
        ///  
        /// </summary>
        [XmlAttribute("Product")]
        public DateTime Product { get; set; }
        /// <summary>
        ///  
        /// </summary>
        [XmlAttribute("Price")]
        public DateTime Price { get; set; }
        /// <summary>
        ///  
        /// </summary>
        [XmlAttribute("Member")]
        public DateTime Member { get; set; }
        /// <summary>
        ///  
        /// </summary>
        [XmlAttribute("Points")]
        public DateTime Points { get; set; }
        /// <summary>
        ///  
        /// </summary>
        [XmlAttribute("POS")]
        public DateTime POS { get; set; }
        /// <summary>
        ///  
        /// </summary>
        [XmlAttribute("Party")]
        public DateTime Party { get; set; }

    }
}
