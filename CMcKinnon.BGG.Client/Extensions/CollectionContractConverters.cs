using CMcKinnon.BGG.Client.XmlContracts;
using CMcKinnon.BGG.Contracts.Collections;
using System;
using System.Collections.Generic;

namespace CMcKinnon.BGG.Client.Extensions
{
    public static class CollectionContractConverters
    {
        public static CollectionHeader ConvertToCollectionHeader(this _CollectionResult collection)
        {
            return new CollectionHeader
            {
                TotalItems = collection.TotalItems,
                PublishedDate = DateTime.Parse(collection.PublishedDate),
                TermsOfUse = collection.TermsOfUse,
                Items = new List<CollectionItem>()
            };
        }
    }
}
