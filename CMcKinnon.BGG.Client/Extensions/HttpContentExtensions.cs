﻿using CMcKinnon.BGG.Client.XmlContracts;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CMcKinnon.BGG.Client.Extensions
{
    public static class HttpContentExtensions
    {
        public static async Task<TXmlContract> DeserializeXml<TXmlContract>(this HttpContent content) where TXmlContract : _ObjectBase, new()
        {
            byte[] bytes = await content.ReadAsByteArrayAsync();
            string xml = Encoding.UTF8.GetString(bytes);

            TXmlContract result;
            using (TextReader reader = new StringReader(xml))
            {
                using (XmlReader xmlReader = XmlReader.Create(reader, new XmlReaderSettings { CloseInput = false }))
                {
                    XmlSerializer errorSerializer = new XmlSerializer(typeof(_ErrorResult));
                    if (errorSerializer.CanDeserialize(xmlReader))
                    {
                        _ErrorResult error = (_ErrorResult)errorSerializer.Deserialize(xmlReader);
                        result = new TXmlContract
                        {
                            ErrorMessage = error.Error.Message
                        };
                    }
                    else
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(TXmlContract));
                        result = (TXmlContract)serializer.Deserialize(xmlReader);
                    }
                }
            }

            return result;
        }
    }
}
