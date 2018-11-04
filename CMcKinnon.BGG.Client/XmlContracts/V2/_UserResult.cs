using System;
using System.Xml.Serialization;

namespace CMcKinnon.BGG.Client.XmlContracts.V2
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "user")]
    public class _UserResult : _XmlContractBase
    {
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "firstname")]
        public _UserElement FirstName { get; set; }
        [XmlElement(ElementName = "lastname")]
        public _UserElement LastName { get; set; }
        [XmlElement(ElementName = "avatarlink")]
        public _UserElement AvatarLink { get; set; }
        [XmlElement(ElementName = "yearregistered")]
        public _UserElement YearRegistered { get; set; }
        [XmlElement(ElementName = "lastlogin")]
        public _UserElement LastLogin { get; set; }
        [XmlElement(ElementName = "stateorprovince")]
        public _UserElement StateOrProvince { get; set; }
        [XmlElement(ElementName = "country")]
        public _UserElement Country { get; set; }
        [XmlElement(ElementName = "webaddress")]
        public _UserElement WebAddress { get; set; }
        [XmlElement(ElementName = "xboxaccount")]
        public _UserElement XboxAccount { get; set; }
        [XmlElement(ElementName = "wiiaccount")]
        public _UserElement WiiAccount { get; set; }
        [XmlElement(ElementName = "psnaccount")]
        public _UserElement PsnAccount { get; set; }
        [XmlElement(ElementName = "battlenetaccount")]
        public _UserElement BattleNetAccount { get; set; }
        [XmlElement(ElementName = "steamaccount")]
        public _UserElement SteamAccount { get; set; }
        [XmlElement(ElementName = "traderating")]
        public _UserElement TradeRating { get; set; }
        [XmlElement(ElementName = "marketrating")]
        public _UserElement MarketRating { get; set; }

        [XmlElement(ElementName = "buddies")]
        public _UserBuddies Buddies { get; set; }
        [XmlElement(ElementName = "guilds")]
        public _UserGuilds Guilds { get; set; }
        [XmlElement(ElementName = "top")]
        public _UserList Top { get; set; }
        [XmlElement(ElementName = "hot")]
        public _UserList Hot { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _UserElement
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _UserBuddies
    {
        [XmlAttribute(AttributeName = "total")]
        public int Total { get; set; }
        [XmlAttribute(AttributeName = "page")]
        public int Page { get; set; }

        [XmlElement(ElementName = "buddy")]
        public _UserBuddy[] Buddies { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _UserBuddy
    {
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _UserGuilds
    {
        [XmlAttribute(AttributeName = "total")]
        public int Total { get; set; }
        [XmlAttribute(AttributeName = "page")]
        public int Page { get; set; }

        [XmlElement(ElementName = "guild")]
        public _UserGuild[] Guilds { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _UserGuild
    {
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _UserList
    {
        [XmlAttribute(AttributeName = "domain")]
        public string Domain { get; set; }

        [XmlElement(ElementName = "item")]
        public _UserItem[] Items { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class _UserItem
    {
        [XmlAttribute(AttributeName = "rank")]
        public int Rank { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }
}
