using System;
using System.Xml.Serialization;

namespace CMcKinnon.BGG.Client.XmlContracts.V2
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "plays")]
    public class _PlayResult : _XmlContractBase
    {
        [XmlAttribute(AttributeName = "username")]
        public string Username { get; set; }
        [XmlAttribute(AttributeName = "userid")]
        public int UserId { get; set; }
        [XmlAttribute(AttributeName = "total")]
        public int TotalPlays { get; set; }
        [XmlAttribute(AttributeName = "page")]
        public int Page { get; set; }

        [XmlElement(ElementName = "play")]
        public _Play[] Plays { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _Play
    {
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }
        [XmlAttribute(AttributeName = "quantity")]
        public int Quantity { get; set; }
        [XmlAttribute(AttributeName = "length")]
        public string Length { get; set; }
        [XmlAttribute(AttributeName = "incomplete")]
        public int Incomplete { get; set; }
        [XmlAttribute(AttributeName = "nowinstats")]
        public int NoWinStats { get; set; }
        [XmlAttribute(AttributeName = "location")]
        public string Location { get; set; }

        [XmlElement(ElementName = "item")]
        public _PlayItem Item { get; set; }
        [XmlElement(ElementName = "comments")]
        public string Comments { get; set; }
        [XmlElement(ElementName = "players")]
        public _PlayPlayers Players { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _PlayItem
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "objecttype")]
        public string ObjectType { get; set; }
        [XmlAttribute(AttributeName = "objectid")]
        public int ObjectId { get; set; }

        [XmlElement(ElementName = "subtypes")]
        public _PlaySubtypes Subtypes { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _PlaySubtypes
    {
        [XmlElement(ElementName = "subtype")]
        public _PlaySubtype[] Subtypes { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _PlaySubtype
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _PlayPlayers
    {
        [XmlElement(ElementName = "player")]
        public _PlayPlayer[] Players { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _PlayPlayer
    {
        [XmlAttribute(AttributeName = "username")]
        public string Username { get; set; }
        [XmlAttribute(AttributeName = "userid")]
        public int UserId { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "startposition")]
        public string StartPosition { get; set; }
        [XmlAttribute(AttributeName = "color")]
        public string Color { get; set; }
        [XmlAttribute(AttributeName = "score")]
        public string Score { get; set; }
        [XmlAttribute(AttributeName = "new")]
        public int New { get; set; }
        [XmlAttribute(AttributeName = "rating")]
        public string Rating { get; set; }
        [XmlAttribute(AttributeName = "win")]
        public int Win { get; set; }
    }
}
