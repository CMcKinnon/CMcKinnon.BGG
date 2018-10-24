using System;
using System.Xml.Serialization;

namespace CMcKinnon.BGG.Client.XmlContracts.V2
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "items")]
    public class _ItemsResult : _XmlContractBase
    {
        [XmlAttribute(AttributeName = "total")]
        public int TotalItems { get; set; }

        [XmlElement(ElementName = "item")]
        public _Item[] Items { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _Item
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "yearpublished")]
        public _ItemYear YearPublished { get; set; }

        [XmlElement(ElementName = "name")]
        public _ItemName Name { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _ItemYear
    {
        [XmlAttribute(AttributeName = "value")]
        public int YearPublished { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _ItemName
    {
        [XmlAttribute(AttributeName = "value")]
        public string Name { get; set; }
    }
}
