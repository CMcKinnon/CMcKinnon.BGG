using CMcKinnon.BGG.Client.XmlContracts.V2;
using CMcKinnon.BGG.Contracts.V2;
using System;
using System.Linq;
using System.Net;

namespace CMcKinnon.BGG.Client.Extensions.V2
{
    public static class ItemContractConverters
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

        public static HotItemResult ConvertToHotItemResult(this _ItemsResult items)
        {
            return new HotItemResult
            {
                StatusCode = (int)HttpStatusCode.OK,
                Items = items.Items?.Select(i => new Item
                {
                    Id = i.Id,
                    Name = i.Name?.Name ?? "",
                    YearPublished = i.YearPublished?.YearPublished ?? 0,
                    Rank = i.Rank,
                    Thumbnail = i.Thumbnail.Url
                }).ToList()
            };
        }
    }
}
