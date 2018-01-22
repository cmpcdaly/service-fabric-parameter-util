using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParameterAdder.Models
{
    [XmlRoot(ElementName = "Settings", Namespace = "http://schemas.microsoft.com/2011/01/fabric")]
    public class Settings
    {
        [XmlElement("Section")]
        public List<Section> Sections { get; set; }
    }
}
