using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParameterAdder.Models.Parameters
{
    [XmlRoot(ElementName = "Application", Namespace = "http://schemas.microsoft.com/2011/01/fabric")]
    public class Application
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlArray("Parameters")]
        [XmlArrayItem("Parameter")]
        public List<Parameter> Parameters { get; set; }
    }
}
