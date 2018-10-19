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

        [XmlElement(ElementName = "name")]
        public _boardgamesBoardgameName Name { get; set; }

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
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _CollectionItemStatus
    {
        [XmlAttribute(AttributeName = "own")]
        public int Own { get; set; }

        [XmlAttribute(AttributeName = "prevowned")]
        public int PreviouslyOwned { get; set; }

        [XmlAttribute(AttributeName = "fortrade")]
        public int ForTrade { get; set; }

        [XmlAttribute(AttributeName = "want")]
        public int Want { get; set; }
        
        [XmlAttribute(AttributeName = "wanttoplay")]
        public int WantToPlay { get; set; }

        [XmlAttribute(AttributeName = "wanttobuy")]
        public int WantToBuy { get; set; }

        [XmlAttribute(AttributeName = "wishlist")]
        public int Wishlist { get; set; }

        [XmlAttribute(AttributeName = "wishlistpriority")]
        public int WishlistPriority { get; set; }

        [XmlAttribute(AttributeName = "preordered")]
        public int Preordered { get; set; }

        [XmlAttribute(AttributeName = "lastmodified")]
        public string LastModified { get; set; }
    }
}
