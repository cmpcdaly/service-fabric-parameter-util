using System.Collections.Generic;
using System.Xml.Serialization;

namespace ParameterAdder.Models
{
    public class Section
    {
        [XmlAttribute]
        public string Name { get; set; }


        [XmlElement("Parameter")]
        public List<Parameter> Parameters { get; set; }
    }
}
