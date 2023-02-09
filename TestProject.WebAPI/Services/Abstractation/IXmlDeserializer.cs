using System.IO;

namespace TestProject.WebAPI.Services.Abstractation
{
    public interface IXmlDeserializer
    {
        T GetObjectFromXml<T>(Stream xml);
        T GetObjectFromXml<T>(string xml);

        string Serialize<T>(T xml);
    }
}
