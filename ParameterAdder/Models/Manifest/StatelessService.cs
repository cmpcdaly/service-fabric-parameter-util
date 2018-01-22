using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParameterAdder.Models.Manifest
{
    public class StatelessService
    {
        [XmlAttribute]
        public string ServiceTypeName { get; set; }

        [XmlAttribute]
        public string InstanceCount { get; set; }

        [XmlElement]
        public SingletonPartition SingletonPartition { get; set; }
    }
}
