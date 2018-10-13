using CMcKinnon.BGG.Contracts.Search;
using CMcKinnon.BGG.XmlContracts;
using System.Collections.Generic;
using System.Linq;

namespace CMcKinnon.BGG.Client.Extensions
{
    public static class ContractConverters
    {
        public static IList<Boardgame> ConvertToBoardgameList(this BoardgameSearchResult boardgames)
        {
            return boardgames.Boardgames?.Select(b => new Boardgame
            {
                Name = b.name.Value,
                IsPrimaryName = b.name.primarySpecified ? b.name.IsPrimaryName : true,
                ObjectId = b.ObjectId,
                YearPublished = b.YearPublished
            })
            .ToList() ?? new List<Boardgame>();
        }
    }
}
