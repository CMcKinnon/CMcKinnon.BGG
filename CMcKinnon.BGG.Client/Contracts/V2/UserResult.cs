using System;
using System.Collections.Generic;

namespace CMcKinnon.BGG.Client.Contracts.V2
{
    public class UserResult
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarLink { get; set; }
        public string YearRegistered { get; set; }
        public DateTime? LastLogin { get; set; }
        public string StateOrProvince { get; set; }
        public string Country { get; set; }
        public string WebAddress { get; set; }
        public string XboxAccount { get; set; }
        public string WiiAccount { get; set; }
        public string PsnAccount { get; set; }
        public string BattleNetAccount { get; set; }
        public string SteamAccount { get; set; }
        public string TradeRating { get; set; }
        public string MarketRating { get; set; }

        public List<Buddy> Buddies { get; set; }
        public List<Guild> Guilds { get; set; }
        public List<Item> Top { get; set; }
        public List<Item> Hot { get; set; }
    }
}
