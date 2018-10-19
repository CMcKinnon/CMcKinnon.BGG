using System;
using System.Xml.Serialization;

namespace CMcKinnon.BGG.Client.XmlContracts
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "errors")]
    public class _ErrorResult
    {
        [XmlElement(ElementName = "error")]
        public _Error Error { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _Error
    {
        [XmlElement(ElementName = "message")]
        public string Message { get; set; }
    }
}
