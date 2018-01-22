using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParameterAdder.Models.Manifest
{
    [XmlRoot(ElementName = "ApplicationManifest", Namespace = "http://schemas.microsoft.com/2011/01/fabric")]
    public class ApplicationManifest
    {
        [XmlAttribute] public string ApplicationTypeName { get; set; }

        [XmlAttribute]
        public string ApplicationTypeVersion { get; set; }

        [XmlArray]
        [XmlArrayItem("Parameter")]
        public List<DefaultParameter> Parameters { get; set; }

        [XmlElement("ServiceManifestImport")]
        public List<ServiceManifestImport> ServiceManifestImports { get; set; }

        [XmlArray]
        [XmlArrayItem("Service")]
        public List<Service> DefaultServices { get; set; }
    }
}
