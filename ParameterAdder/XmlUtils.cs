using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ParameterAdder
{
    public static class XmlUtils
    {
        public static T ReadXml<T>(string path)
        {
            using (var xmlStream = new StreamReader(path, Encoding.UTF8))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(xmlStream);
            }
        }

        public static void WriteXml(string path, object @object)
        {
            var serializer = new XmlSerializer(@object.GetType());

            using (var stringWriter = new StringWriterWithEncoding(Encoding.UTF8))
            {
                using (XmlWriter writer = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true }))
                {
                    serializer.Serialize(writer, @object);
                    File.WriteAllText(path, stringWriter.ToString());
                }
            }
        }
    }
}
