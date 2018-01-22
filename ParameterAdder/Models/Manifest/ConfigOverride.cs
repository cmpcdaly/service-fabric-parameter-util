using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParameterAdder.Models.Manifest
{
    public class ConfigOverride
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlArray("Settings")]
        [XmlArrayItem("Section")]
        public List<Section> Settings { get; set; }
    }
}
