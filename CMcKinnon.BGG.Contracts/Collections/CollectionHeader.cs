using System;
using System.Collections.Generic;

namespace CMcKinnon.BGG.Contracts.Collections
{
    public class CollectionHeader
    {
        public int TotalItems { get; set; }
        public string TermsOfUse { get; set; }
        public DateTime PublishedDate { get; set; }
        public IList<CollectionItem> Items { get; set; }
    }
}
