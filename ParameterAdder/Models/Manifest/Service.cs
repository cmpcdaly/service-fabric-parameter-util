using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParameterAdder.Models.Manifest
{
    public class Service
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string GeneratedIdRef { get; set; }

        [XmlElement]
        public StatelessService StatelessService { get; set; }

        [XmlElement]
        public StatefulService StatefulService { get; set; }
    }
}
