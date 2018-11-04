using System;
using System.Xml.Serialization;

namespace CMcKinnon.BGG.Client.XmlContracts.V2
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "div")]
    public class _PlayError
    {
        [XmlText]
        public string Message { get; set; }
    }
}
