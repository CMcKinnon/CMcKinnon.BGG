using System;
using System.Xml.Serialization;

namespace CMcKinnon.BGG.Client.XmlContracts
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "geeklist")]
    public class _GeeklistResult : _XmlContractBase
    {
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }

        [XmlAttribute(AttributeName = "termsofuse")]
        public string TermsOfUse { get; set; }

        [XmlElement(ElementName = "postdate")]
        public string PostDate { get; set; }
        [XmlElement(ElementName = "postdate_timestamp")]
        public long PostDateTimestamp { get; set; }
        [XmlElement(ElementName = "editdate")]
        public string EditDate { get; set; }
        [XmlElement(ElementName = "editdate_timestamp")]
        public long EditDateTimestamp { get; set; }
        [XmlElement(ElementName = "thumbs")]
        public int Thumbs { get; set; }
        [XmlElement(ElementName = "numitems")]
        public int NumberOfItems { get; set; }
        [XmlElement(ElementName = "username")]
        public string Username { get; set; }
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "item")]
        public _GeeklistItem[] Items { get; set; }
        [XmlElement(ElementName = "comment")]
        public _GeeklistComment[] Comments { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _GeeklistItem
    {
        [XmlAttribute(AttributeName ="id")]
        public int Id { get; set; }
        [XmlAttribute(AttributeName = "objecttype")]
        public string ObjectType { get; set; }
        [XmlAttribute(AttributeName = "subtype")]
        public string SubType { get; set; }
        [XmlAttribute(AttributeName = "objectid")]
        public int ObjectId { get; set; }
        [XmlAttribute(AttributeName = "objectname")]
        public string ObjectName { get; set; }
        [XmlAttribute(AttributeName = "username")]
        public string Username { get; set; }
        [XmlAttribute(AttributeName = "postdate")]
        public string PostDate { get; set; }
        [XmlAttribute(AttributeName = "editdate")]
        public string EditDate { get; set; }
        [XmlAttribute(AttributeName = "thumbs")]
        public int Thumbs { get; set; }
        [XmlAttribute(AttributeName = "imageid")]
        public int ImageId { get; set; }

        [XmlElement(ElementName = "body")]
        [XmlText]
        public string Body { get; set; }

        [XmlElement(ElementName = "comment")]
        public _GeeklistComment[] Comments { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _GeeklistComment
    {
        [XmlAttribute(AttributeName = "username")]
        public string Username { get; set; }
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }
        [XmlAttribute(AttributeName = "postdate")]
        public string PostDate { get; set; }
        [XmlAttribute(AttributeName = "editdate")]
        public string EditDate { get; set; }
        [XmlAttribute(AttributeName = "thumbs")]
        public int Thumbs { get; set; }

        [XmlText]
        public string Body { get; set; }
    }
}
