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
                SubType = i.SubType
            })
            .ToList() ?? new List<CollectionItem>();
        }
    }
}
