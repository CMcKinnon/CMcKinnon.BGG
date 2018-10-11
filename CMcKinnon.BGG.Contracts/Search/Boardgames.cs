using System;
using System.Xml.Serialization;

namespace CMcKinnon.BGG.Contracts
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public partial class boardgames
    {
        [XmlElement("boardgame")]
        public boardgamesBoardgame[] boardgame { get; set; }

        [XmlAttribute()]
        public string termsofuse { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public partial class boardgamesBoardgame
    {
        public boardgamesBoardgameName name { get; set; }

        public ushort yearpublished { get; set; }

        [XmlAttribute()]
        public uint objectid { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public partial class boardgamesBoardgameName
    {
        [XmlAttribute]
        public bool primary { get; set; }

        [XmlIgnore]
        public bool primarySpecified { get; set; }

        [XmlText]
        public string Value { get; set; }
    }


}