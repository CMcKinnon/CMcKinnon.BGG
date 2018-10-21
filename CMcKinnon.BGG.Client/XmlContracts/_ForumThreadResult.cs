using System;
using System.Xml.Serialization;

namespace CMcKinnon.BGG.Client.XmlContracts
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "rss")]
    public class _ForumThreadResult : _ObjectBase
    {
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }

        [XmlElement(ElementName = "channel")]
        public _ThreadChannel Channel { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _ThreadChannel
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "language")]
        public string Language { get; set; }
        [XmlElement(ElementName = "pubDate")]
        public string PublicationDate { get; set; }
        [XmlElement(ElementName = "lastBuildDate")]
        public string LastBuildDate { get; set; }
        [XmlElement(ElementName = "link")]
        public string Link { get; set; }
        [XmlElement(ElementName = "webMaster")]
        public string Webmaster { get; set; }

        [XmlElement("image")]
        public _ThreadImage Image { get; set; }

        [XmlElement("item")]
        public _ThreadItem[] Items { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _ThreadImage
    {
        [XmlElement(ElementName = "url")]
        public string Url { get; set; }
        [XmlElement(ElementName = "link")]
        public string Link { get; set; }
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _ThreadItem
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "link")]
        public string Link { get; set; }
        [XmlElement(ElementName = "guid")]
        public string Guid { get; set; }
        [XmlElement(ElementName = "pubDate")]
        public string PublicationDate { get; set; }
        [XmlElement(ElementName = "creator", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Creator { get; set; }
    }
}
