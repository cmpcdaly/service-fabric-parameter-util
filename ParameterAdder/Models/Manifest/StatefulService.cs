using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParameterAdder.Models.Manifest
{
    public class StatefulService
    {
        [XmlAttribute]
        public string ServiceTypeName { get; set; }

        [XmlAttribute]
        public string TargetReplicaSetSize { get; set; }

        [XmlAttribute]
        public string MinReplicaSetSize { get; set; }
        
        [XmlElement]
        public UniformInt64Partition UniformInt64Partition { get; set; }
    }
}
