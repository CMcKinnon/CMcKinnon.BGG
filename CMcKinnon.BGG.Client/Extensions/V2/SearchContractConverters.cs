using CMcKinnon.BGG.Client.XmlContracts.V2;
using CMcKinnon.BGG.Contracts.V2;
using System;
using System.Linq;
using System.Net;

namespace CMcKinnon.BGG.Client.Extensions.V2
{
    public static class SearchContractConverters
    {
        public static SearchResult ConvertToSearchResult(this _ItemsResult items)
        {
            return new SearchResult
            {
                StatusCode = (int)HttpStatusCode.OK,
                TotalItems = items.TotalItems,
                Items = items.Items?.Select(i => new Item
                {
                    Id = i.Id,
                    Name = i.Name?.Name ?? "",
                    Type = (ThingType)Enum.Parse(typeof(ThingType), i.Type),
                    YearPublished = i.YearPublished?.YearPublished ?? 0
                }).ToList()
            };
        }
    }
}
