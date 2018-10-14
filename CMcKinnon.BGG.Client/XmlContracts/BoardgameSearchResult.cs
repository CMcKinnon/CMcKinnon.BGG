using System;
using System.Xml.Serialization;

namespace CMcKinnon.BGG.Client.XmlContracts
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "boardgames")]
    public class BoardgameSearchResult
    {
        [XmlElement("boardgame")]
        public boardgamesBoardgame[] Boardgames { get; set; }

        [XmlAttribute()]
        public string termsofuse { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class boardgamesBoardgame
    {
        [XmlAttribute(AttributeName = "objectid")]
        public uint ObjectId { get; set; }

        [XmlElement(ElementName = "name")]
        public boardgamesBoardgameName[] names { get; set; }

        [XmlElement(ElementName = "yearpublished")]
        public int YearPublished { get; set; }

        [XmlElement(ElementName = "minplayers")]
        public int MinPlayers { get; set; }

        [XmlElement(ElementName = "maxplayers")]
        public int MaxPlayers { get; set; }

        [XmlElement(ElementName = "playingtime")]
        public int PlayingTime { get; set; }

        [XmlElement(ElementName = "minplaytime")]
        public int MinPlayTime { get; set; }

        [XmlElement(ElementName = "maxplaytime")]
        public int MaxPlayTime { get; set; }

        [XmlElement(ElementName = "age")]
        public int Age { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "thumbnail")]
        public string Thumbnail { get; set; }

        [XmlElement(ElementName = "image")]
        public string Image { get; set; }

        [XmlElement(ElementName = "boardgamepublisher")]
        public _LinkedObject[] Publishers { get; set; }

        [XmlElement(ElementName = "boardgameartist")]
        public _LinkedObject[] Artists { get; set; }

        [XmlElement(ElementName = "boardgamedesigner")]
        public _LinkedObject[] Designers { get; set; }

        [XmlElement(ElementName = "boardgamefamily")]
        public _LinkedObject[] Families { get; set; }

        [XmlElement(ElementName = "boardgamehonor")]
        public _LinkedObject[] Honors { get; set; }

        [XmlElement(ElementName = "boardgameimplementation")]
        public _LinkedObject[] Implementations { get; set; }

        [XmlElement(ElementName = "boardgamemechanic")]
        public _LinkedObject[] Mechanics { get; set; }

        [XmlElement(ElementName = "boardgamepodcastepisode")]
        public _LinkedObject[] PodcastEpisodes { get; set; }

        [XmlElement(ElementName = "boardgamesubdomain")]
        public _LinkedObject[] Subdomains { get; set; }

        [XmlElement(ElementName = "boardgameversion")]
        public _LinkedObject[] Versions { get; set; }

        [XmlElement(ElementName = "poll")]
        public Poll[] Polls { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class boardgamesBoardgameName
    {
        [XmlAttribute(AttributeName = "primary")]
        public bool IsPrimaryName { get; set; }

        [XmlIgnore]
        public bool primarySpecified { get; set; }

        [XmlAttribute(AttributeName = "sortindex")]
        public int SortIndex { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _LinkedObject
    {
        [XmlAttribute(AttributeName = "objectid")]
        public uint ObjectId { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class Poll
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }

        [XmlAttribute(AttributeName = "totalvotes")]
        public uint TotalVotes { get; set; }

        [XmlElement(ElementName = "results")]
        public PollResults[] Results { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class PollResults
    {
        [XmlAttribute(AttributeName = "numplayers")]
        public string NumberOfPlayers { get; set; }

        [XmlElement(ElementName = "result")]
        public PollResult[] Results { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class PollResult
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }

        [XmlAttribute(AttributeName = "level")]
        public uint Level { get; set; }

        [XmlAttribute(AttributeName = "numvotes")]
        public uint NumberOfVotes { get; set; }
    }
}