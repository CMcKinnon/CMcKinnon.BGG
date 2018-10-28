using System;
using System.Xml.Serialization;

namespace CMcKinnon.BGG.Client.XmlContracts
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "error")]
    public class _ErrorMessageResult
    {
        [XmlAttribute(AttributeName = "message")]
        public string Message { get; set; }
    }
}
