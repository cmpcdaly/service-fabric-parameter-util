using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParameterAdder.Models.Manifest
{
    public class UniformInt64Partition
    {
        [XmlAttribute]
        public string PartitionCount { get; set; }

        [XmlAttribute]
        public string LowKey { get; set; }

        [XmlAttribute]
        public string HighKey { get; set; }
    }
}
