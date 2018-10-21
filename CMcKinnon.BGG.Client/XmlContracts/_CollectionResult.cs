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
        public string CollectionId { get; set; }

        [XmlElement(ElementName = "name")]
        public _BoardgameName Name { get; set; }

        [XmlElement(ElementName = "yearpublished")]
        public int YearPublished { get; set; }

        [XmlElement(ElementName = "thumbnail")]
        public string Thumbnail { get; set; }

        [XmlElement(ElementName = "image")]
        public string Image { get; set; }

        [XmlElement(ElementName = "comment")]
        public string Comment { get; set; }

        [XmlElement(ElementName = "haspartslist")]
        public string HasPartsList { get; set; }

        [XmlElement(ElementName = "wantpartslist")]
        public string WantPartsList { get; set; }

        [XmlElement(ElementName = "numplays")]
        public uint NumberOfPlays { get; set; }

        [XmlElement(ElementName = "status")]
        public _CollectionItemStatus Status { get; set; }

        [XmlElement(ElementName = "stats")]
        public _CollectionItemStats Stats { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _CollectionItemStatus
    {
        [XmlAttribute(AttributeName = "own")]
        public string Own { get; set; }

        [XmlAttribute(AttributeName = "prevowned")]
        public string PreviouslyOwned { get; set; }

        [XmlAttribute(AttributeName = "fortrade")]
        public string ForTrade { get; set; }

        [XmlAttribute(AttributeName = "want")]
        public string Want { get; set; }
        
        [XmlAttribute(AttributeName = "wanttoplay")]
        public string WantToPlay { get; set; }

        [XmlAttribute(AttributeName = "wanttobuy")]
        public string WantToBuy { get; set; }

        [XmlAttribute(AttributeName = "wishlist")]
        public string Wishlist { get; set; }

        [XmlAttribute(AttributeName = "wishlistpriority")]
        public string WishlistPriority { get; set; }

        [XmlAttribute(AttributeName = "preordered")]
        public string Preordered { get; set; }

        [XmlAttribute(AttributeName = "lastmodified")]
        public string LastModified { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _CollectionItemStats
    {
        [XmlAttribute(AttributeName = "minplayers")]
        public int MinPlayers { get; set; }
        [XmlAttribute(AttributeName = "maxplayers")]
        public int MaxPlayers { get; set; }
        [XmlAttribute(AttributeName = "minplaytime")]
        public int MinPlayTime { get; set; }
        [XmlAttribute(AttributeName = "maxplaytime")]
        public int MaxPlayTime { get; set; }
        [XmlAttribute(AttributeName = "playingtime")]
        public int PlayingTime { get; set; }
        [XmlAttribute(AttributeName = "numowned")]
        public int NumberOwned { get; set; }

        [XmlElement(ElementName = "rating")]
        public _CollectionItemRating Rating { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _CollectionItemRating
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }

        [XmlElement(ElementName = "usersrated")]
        public _CollectionItemStat UsersRated { get; set; }

        [XmlElement(ElementName = "average")]
        public _CollectionItemStat Average { get; set; }

        [XmlElement(ElementName = "bayesaverage")]
        public _CollectionItemStat BayesAverage { get; set; }

        [XmlElement(ElementName = "stddev")]
        public _CollectionItemStat StandardDeviation { get; set; }

        [XmlElement(ElementName = "median")]
        public _CollectionItemStat Median { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _CollectionItemStat
    {
        [XmlAttribute(AttributeName = "value")]
        public decimal Value { get; set; }
    }
}
