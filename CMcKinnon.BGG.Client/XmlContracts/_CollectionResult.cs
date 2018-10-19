using System;
using System.Xml.Serialization;

namespace CMcKinnon.BGG.Client.XmlContracts
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "items")]
    public class _CollectionResult
    {
        [XmlAttribute(AttributeName = "totalitems")]
        public int TotalItems { get; set; }

        [XmlAttribute(AttributeName = "termsofuse")]
        public string TermsOfUse { get; set; }

        [XmlAttribute(AttributeName = "pubdate")]
        public string PublishedDate { get; set; }
    }
}
