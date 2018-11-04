using CMcKinnon.BGG.Client.XmlContracts.V2;
using CMcKinnon.BGG.Contracts.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace CMcKinnon.BGG.Client.Extensions.V2
{
    public static class PlayContractConverters
    {
        public static PlayResult ConvertToPlayResult(this _PlayResult play)
        {
            return new PlayResult
            {
                StatusCode = (int)HttpStatusCode.OK,
                ErrorMessage = play.ErrorMessage,
                Username = play.Username,
                UserId = play.UserId,
                TotalPlays = play.TotalPlays,
                Page = play.Page,
                Plays = ConvertPlays(play.Plays)
            };
        }

        private static List<Play> ConvertPlays(_Play[] plays)
        {
            return plays?.Select(p => new Play
            {
                Id = p.Id,
                Date = p.Date.GetSafeDateTime(),
                Incomplete = p.Incomplete == 1,
                NoWinStats = p.NoWinStats == 1,
                Comments = p.Comments,
                Length = p.Length,
                Location = p.Location,
                Quantity = p.Quantity,
                Players = ConvertPlayers(p.Players),
                ItemName = p.Item?.Name ?? "",
                ItemObjectId = p.Item?.ObjectId ?? 0,
                ItemType = p.Item.ObjectType != null ? (PlayType)Enum.Parse(typeof(PlayType), p.Item.ObjectType) : (PlayType?)null,
                ItemSubTypes = p.Item.Subtypes?.Subtypes?.Select(s => (PlaySubType)Enum.Parse(typeof(PlaySubType), s.Value)).ToList()
            })
            .ToList() ?? new List<Play>();
        }

        private static List<Player> ConvertPlayers(_PlayPlayers players)
        {
            return players?.Players?.Select(p => new Player
            {
                Username = p.Username,
                UserId = p.UserId,
                Color = p.Color,
                Name = p.Name,
                New = p.New == 1,
                Rating = p.Rating,
                Score = p.Score,
                StartPosition = p.StartPosition,
                Win = p.Win == 1
            })
            .ToList() ?? new List<Player>();
        }
    }
}
