using System.IO;
using System.Text;
using System.Xml.Serialization;
using TestProject.WebAPI.Services.Abstractation;

namespace TestProject.WebAPI.Services.Implementation
{
    public class XmlDeserializer: IXmlDeserializer
    {
        public T GetObjectFromXml<T>(Stream xml)
        {
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(xml);
        }

        public T GetObjectFromXml<T>(string xml)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(xml);
            MemoryStream stream = new MemoryStream(byteArray);
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(stream);
        }


        public string Serialize<T>(T xml)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (StringWriter textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, xml);
                return textWriter.ToString();
            }
        }
    }
}
