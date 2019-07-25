using System.Xml.Serialization;

namespace client.common.SystemSettings
{
    public class ServerUrl
    {
        [XmlAttribute("HostUrl")]
        public string HostUrl { get; set; }

        [XmlAttribute("HelpUrl")]
        public string HelpUrl { get; set; }

        [XmlAttribute("LiveUpdateUrl")]
        public string LiveUpdateUrl{ get; set; }

    }
}
