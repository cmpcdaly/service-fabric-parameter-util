using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParameterAdder.Models.Manifest
{
    public class ServiceManifestRef
    {
        [XmlAttribute]
        public string ServiceManifestName { get; set; }

        [XmlAttribute]
        public string ServiceManifestVersion { get; set; }
    }
}
