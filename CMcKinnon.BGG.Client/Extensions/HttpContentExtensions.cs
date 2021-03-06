﻿using CMcKinnon.BGG.Client.XmlContracts;
using CMcKinnon.BGG.Client.XmlContracts.V2;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CMcKinnon.BGG.Client.Extensions
{
    public static class HttpContentExtensions
    {
        public static async Task<TXmlContract> DeserializeXml<TXmlContract>(this HttpContent content) where TXmlContract : _XmlContractBase, new()
        {
            byte[] bytes = await content.ReadAsByteArrayAsync();
            string xml = Encoding.UTF8.GetString(bytes);
            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings { CloseInput = false };

            TXmlContract result;
            using (TextReader reader = new StringReader(xml))
            {
                using (XmlReader xmlReader = XmlReader.Create(reader, xmlReaderSettings))
                {
                    DisableUndeclaredEntityCheck(xmlReader);
                    XmlSerializer errorSerializer = new XmlSerializer(typeof(_ErrorResult));
                    XmlSerializer errorMessageSerializer = new XmlSerializer(typeof(_ErrorMessageResult));
                    XmlSerializer divErrorSerializer = new XmlSerializer(typeof(_DivError));
                    if (errorSerializer.CanDeserialize(xmlReader))
                    {
                        _ErrorResult error = (_ErrorResult)errorSerializer.Deserialize(xmlReader);
                        result = new TXmlContract
                        {
                            ErrorMessage = error.Error.Message
                        };
                    }
                    else if (errorMessageSerializer.CanDeserialize(xmlReader))
                    {
                        _ErrorMessageResult error = (_ErrorMessageResult)errorMessageSerializer.Deserialize(xmlReader);
                        result = new TXmlContract
                        {
                            ErrorMessage = error.Message
                        };
                    }
                    else if (divErrorSerializer.CanDeserialize(xmlReader))
                    {
                        _DivError error = (_DivError)divErrorSerializer.Deserialize(xmlReader);
                        result = new TXmlContract
                        {
                            ErrorMessage = error.Message
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

        private static void DisableUndeclaredEntityCheck(XmlReader xmlReader)
        {
            PropertyInfo propertyInfo = xmlReader.GetType().GetProperty(
                "DisableUndeclaredEntityCheck", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            propertyInfo.SetValue(xmlReader, true);
        }
    }
}
