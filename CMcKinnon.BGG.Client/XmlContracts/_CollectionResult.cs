using System;
using System.Xml.Serialization;

namespace CMcKinnon.BGG.Client.XmlContracts
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "items")]
    public class _CollectionResult : _ObjectBase
    {
        [XmlAttribute(AttributeName = "totalitems")]
        public int TotalItems { get; set; }

        [XmlAttribute(AttributeName = "termsofuse")]
        public string TermsOfUse { get; set; }

        [XmlAttribute(AttributeName = "pubdate")]
        public string PublishedDate { get; set; }

        [XmlElement(ElementName = "item")]
        public _CollectionItem[] Items { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _CollectionItem
    {
        [XmlAttribute(AttributeName = "objecttype")]
        public string ObjectType { get; set; }

        [XmlAttribute(AttributeName = "objectid")]
        public uint ObjectId { get; set; }

        [XmlAttribute(AttributeName = "subtype")]
        public string SubType { get; set; }

        [XmlAttribute(AttributeName = "collid")]
        public uint CollectionId { get; set; }

    }
}
