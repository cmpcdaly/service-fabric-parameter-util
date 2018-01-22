using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParameterAdder.Models.Manifest
{
    public class DefaultParameter
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string DefaultValue { get; set; }
    }
}
