using CMcKinnon.BGG.Client.XmlContracts.V2;
using CMcKinnon.BGG.Client.Contracts.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace CMcKinnon.BGG.Client.Extensions.V2
{
    public static class UserContractConverters
    {
        public static UserResult ConvertToUserResult(this _UserResult user)
        {
            return new UserResult
            {
                StatusCode = (int)HttpStatusCode.OK,
                ErrorMessage = user.ErrorMessage,

                Id = user.Id,
                Name = user.Name,
                FirstName = user.FirstName?.Value,
                LastName = user.LastName?.Value,
                AvatarLink = user.AvatarLink?.Value,
                YearRegistered = user.YearRegistered?.Value,
                LastLogin = user.LastLogin?.Value?.GetSafeDateTime(),
                StateOrProvince = user.StateOrProvince?.Value,
                Country = user.Country?.Value,
                WebAddress = user.WebAddress?.Value,
                XboxAccount = user.XboxAccount?.Value,
                WiiAccount = user.WiiAccount?.Value,
                PsnAccount = user.PsnAccount?.Value,
                BattleNetAccount = user.BattleNetAccount?.Value,
                SteamAccount = user.SteamAccount?.Value,
                TradeRating = user.TradeRating?.Value,
                MarketRating = user.MarketRating?.Value,

                Buddies = ConvertBuddies(user.Buddies),
                Guilds = ConvertGuilds(user.Guilds),
                Hot = ConvertItems(user.Hot),
                Top = ConvertItems(user.Top)
            };
        }

        private static List<Buddy> ConvertBuddies(_UserBuddies buddies)
        {
            return buddies?.Buddies?.Select(b => new Buddy
            {
                Id = b.Id,
                Name = b.Name
            })
            .ToList() ?? new List<Buddy>();
        }

        private static List<Guild> ConvertGuilds(_UserGuilds guilds)
        {
            return guilds?.Guilds?.Select(g => new Guild
            {
                Id = g.Id,
                Name = g.Name
            })
            .ToList() ?? new List<Guild>();
        }

        private static List<Item> ConvertItems(_UserList list)
        {
            return list?.Items?.Select(i => new Item
            {
                Id = i.Id,
                Name = i.Name,
                Rank = i.Rank
            })
            .ToList() ?? new List<Item>();
        }
    }
}
