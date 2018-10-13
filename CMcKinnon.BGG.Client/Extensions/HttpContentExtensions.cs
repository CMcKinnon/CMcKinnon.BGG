using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CMcKinnon.BGG.Client.Extensions
{
    public static class HttpContentExtensions
    {
        public static async Task<TXmlContract> DeserializeXml<TXmlContract>(this HttpContent content) where TXmlContract : class
        {
            byte[] bytes = await content.ReadAsByteArrayAsync();
            string xml = Encoding.UTF8.GetString(bytes);

            TXmlContract result;
            using (TextReader reader = new StringReader(xml))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TXmlContract));
                result = (TXmlContract)serializer.Deserialize(reader);
            }

            return result;
        }
    }
}
