using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace client.common
{
  public  class ConfigureFile
    {
        public static string GetXML(string filePath)
        {
            //todo
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            return doc.InnerXml;
        }
    }
}
