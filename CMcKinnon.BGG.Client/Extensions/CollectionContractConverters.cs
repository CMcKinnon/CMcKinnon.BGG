using CMcKinnon.BGG.Client.XmlContracts;
using CMcKinnon.BGG.Contracts.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMcKinnon.BGG.Client.Extensions
{
    public static class CollectionContractConverters
    {
        public static CollectionHeader ConvertToCollectionHeader(this _CollectionResult collection)
        {
            return new CollectionHeader
            {
                TotalItems = collection.TotalItems,
                PublishedDate = !string.IsNullOrEmpty(collection.PublishedDate) ? DateTime.Parse(collection.PublishedDate) : DateTime.MinValue,
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
                CollectionId = i.CollectionId,
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
                Status = ConvertStatus(i.Status)
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
                Own = status.Own == 1,
                Want = status.Want == 1,
                ForTrade = status.ForTrade == 1,
                Preordered = status.Preordered == 1,
                PreviouslyOwned = status.PreviouslyOwned == 1,
                WantToBuy = status.WantToBuy == 1,
                WantToPlay = status.WantToPlay == 1,
                Wishlist = status.Wishlist == 1,
                WishlistPriority = status.WishlistPriority,
                LastModified = DateTime.Parse(status.LastModified)
            };
        }
    }
}
