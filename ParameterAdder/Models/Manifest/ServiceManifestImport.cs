using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParameterAdder.Models.Manifest
{
    public class ServiceManifestImport
    {
        [XmlElement]
        public ServiceManifestRef ServiceManifestRef { get; set; }

        [XmlArray("ConfigOverrides")]
        [XmlArrayItem("ConfigOverride")]
        public List<ConfigOverride> ConfigOverrides { get; set; }
    }
}
