using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LocationWFPApp.Models
{
    [XmlRoot(ElementName = "connection")]
    public class Connection
    {
        [XmlElement(ElementName = "path")]
        public string Path { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "listeDesConnections")]
    public class ListeDesConnections
    {
        [XmlElement(ElementName = "connection")]
        public Connection Connection { get; set; }
    }
}
