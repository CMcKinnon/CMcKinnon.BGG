using CMcKinnon.BGG.Contracts.Search;
using CMcKinnon.BGG.Client.XmlContracts;
using System.Collections.Generic;
using System.Linq;

namespace CMcKinnon.BGG.Client.Extensions
{
    public static class ContractConverters
    {
        public static IList<BoardgameResult> ConvertToBoardgameResultList(this BoardgameSearchResult boardgames)
        {
            return boardgames.Boardgames?.Select(b => new BoardgameResult
            {
                Name = b.names.FirstOrDefault()?.Value ?? "(no primary name)",
                ObjectId = b.ObjectId,
                YearPublished = b.YearPublished
            })
            .ToList() ?? new List<BoardgameResult>();
        }

        public static IList<Boardgame> ConvertToBoardgameList(this BoardgameSearchResult boardgames)
        {
            return boardgames.Boardgames?.Select(b => new Boardgame
            {
                PrimaryName = b.names.FirstOrDefault(n => n.IsPrimaryName)?.Value ?? "(no primary name)",
                OtherNames = b.names.Where(n => !n.IsPrimaryName).Select(p => p.Value).ToList(),
                ObjectId = b.ObjectId,
                YearPublished = b.YearPublished,
                Age = b.Age,
                Description = b.Description,
                Image = b.Image,
                MaxPlayers = b.MaxPlayers,
                MaxPlayTime = b.MaxPlayTime,
                MinPlayers = b.MinPlayers,
                MinPlayTime = b.MinPlayTime,
                PlayingTime = b.PlayingTime,
                Thumbnail = b.Thumbnail,
                Publishers = b.Publishers.Select(p => new LinkedObject { ObjectId = p.ObjectId, Value = p.Value}).ToList(),
                Artists = b.Artists.Select(p => new LinkedObject { ObjectId = p.ObjectId, Value = p.Value }).ToList(),
                Designers = b.Designers.Select(p => new LinkedObject { ObjectId = p.ObjectId, Value = p.Value }).ToList(),
                Families = b.Families.Select(p => new LinkedObject { ObjectId = p.ObjectId, Value = p.Value }).ToList(),
                Honors = b.Honors.Select(p => new LinkedObject { ObjectId = p.ObjectId, Value = p.Value }).ToList(),
                Implementations = b.Implementations.Select(p => new LinkedObject { ObjectId = p.ObjectId, Value = p.Value }).ToList(),
                Mechanics = b.Mechanics.Select(p => new LinkedObject { ObjectId = p.ObjectId, Value = p.Value }).ToList(),
                PodcastEpisodes = b.PodcastEpisodes.Select(p => new LinkedObject { ObjectId = p.ObjectId, Value = p.Value }).ToList(),
                Subdomains = b.Subdomains.Select(p => new LinkedObject { ObjectId = p.ObjectId, Value = p.Value }).ToList(),
                Versions = b.Versions.Select(p => new LinkedObject { ObjectId = p.ObjectId, Value = p.Value }).ToList()
            })
            .ToList() ?? new List<Boardgame>();
        }
    }
}
