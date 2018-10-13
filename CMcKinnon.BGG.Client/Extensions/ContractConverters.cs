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
                Name = b.names.FirstOrDefault(n => n.IsPrimaryName)?.Value ?? "(no primary name)",
                IsPrimaryName = b.names.FirstOrDefault(n => n.IsPrimaryName)?.primarySpecified ?? false,
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
                OtherNames = b.names.Where(n => !n.IsPrimaryName).Select(p => p.Value).ToArray(),
                ObjectId = b.ObjectId,
                YearPublished = b.YearPublished
            })
            .ToList() ?? new List<Boardgame>();
        }
    }
}
