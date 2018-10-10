using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace CMcKinnon.BGG.Contracts
{
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class boardgames
    {

        public boardgamesBoardgame boardgame { get; set; }

        [XmlAttribute]
        public string termsofuse { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class boardgamesBoardgame
    {
        public boardgamesBoardgameName name { get; set; }

        public ushort yearpublished { get; set; }

        [XmlAttribute]
        public ushort objectid { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class boardgamesBoardgameName
    {
        [XmlAttribute]
        public bool primary { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}