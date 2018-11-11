using CMcKinnon.BGG.Client.XmlContracts;
using CMcKinnon.BGG.Client.Contracts.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace CMcKinnon.BGG.Client.Extensions
{
    public static class CollectionContractConverters
    {
        public static CollectionHeader ConvertToCollectionHeader(this _CollectionResult collection)
        {
            return new CollectionHeader
            {
                StatusCode = (int)HttpStatusCode.OK,
                TotalItems = collection.TotalItems,
                PublishedDate = collection.PublishedDate.GetSafeDateTime(),
                TermsOfUse = collection.TermsOfUse,
                Items = ConvertItems(collection.Items),
                ErrorMessage = collection.ErrorMessage
            };
        }

        private static IList<CollectionItem> ConvertItems(_CollectionItem[] items)
        {
            return items?.Select(i => new CollectionItem
            {
                ObjectType = i.ObjectType,
                CollectionId = !string.IsNullOrEmpty(i.CollectionId) ? uint.Parse(i.CollectionId) : (uint?)null,
                ObjectId = i.ObjectId,
                SubType = i.SubType,
                Image = i.Image,
                Thumbnail = i.Thumbnail,
                Name = i.Name.Value,
                NumberOfPlays = i.NumberOfPlays,
                YearPublished = i.YearPublished,
                Comment = i.Comment,
                WantPartsList = i.WantPartsList,
                HasPartsList = i.HasPartsList,
                Status = ConvertStatus(i.Status),
                Stats = ConvertStats(i.Stats)
            })
            .ToList() ?? new List<CollectionItem>();
        }

        private static CollectionItemStatus ConvertStatus(_CollectionItemStatus status)
        {
            if (status == null)
            {
                return null;
            }

            return new CollectionItemStatus
            {
                Own = status.Own == "1",
                Want = status.Want == "1",
                ForTrade = status.ForTrade == "1",
                Preordered = status.Preordered == "1",
                PreviouslyOwned = status.PreviouslyOwned == "1",
                WantToBuy = status.WantToBuy == "1",
                WantToPlay = status.WantToPlay == "1",
                Wishlist = status.Wishlist == "1",
                WishlistPriority = !string.IsNullOrEmpty(status.WishlistPriority) ? int.Parse(status.WishlistPriority) : 0,
                LastModified = status.LastModified.GetSafeDateTime()
            };
        }

        private static CollectionItemStats ConvertStats(_CollectionItemStats stats)
        {
            if (stats == null)
            {
                return null;
            }

            return new CollectionItemStats
            {
                MinPlayers = stats.MinPlayers,
                MaxPlayers = stats.MaxPlayers,
                MinPlayTime = stats.MinPlayTime,
                MaxPlayTime = stats.MaxPlayTime,
                PlayingTime = stats.PlayingTime,
                NumberOwned = stats.NumberOwned,
                Rating = stats.Rating.Value,
                Average = stats.Rating?.Average?.Value ?? 0m,
                BayesAverage = stats.Rating?.BayesAverage?.Value ?? 0m,
                StandardDeviation = stats.Rating?.StandardDeviation?.Value ?? 0m,
                Median = stats.Rating?.Median?.Value ?? 0m,
                UsersRated = (int)(stats.Rating?.UsersRated?.Value ?? 0)
            };
        }
    }
}
