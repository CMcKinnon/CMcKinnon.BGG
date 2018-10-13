using System;
using System.Xml.Serialization;

namespace CMcKinnon.BGG.Client.XmlContracts
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "boardgames")]
    public partial class BoardgameSearchResult
    {
        [XmlElement("boardgame")]
        public boardgamesBoardgame[] Boardgames { get; set; }

        [XmlAttribute()]
        public string termsofuse { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public partial class boardgamesBoardgame
    {
        [XmlElement(ElementName = "name")]
        public boardgamesBoardgameName[] names { get; set; }

        [XmlElement(ElementName = "yearpublished")]
        public int YearPublished { get; set; }

        [XmlAttribute(AttributeName = "objectid")]
        public uint ObjectId { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public partial class boardgamesBoardgameName
    {
        [XmlAttribute(AttributeName = "primary")]
        public bool IsPrimaryName { get; set; }

        [XmlIgnore]
        public bool primarySpecified { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}