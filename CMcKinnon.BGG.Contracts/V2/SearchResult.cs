using System.Collections.Generic;

namespace CMcKinnon.BGG.Contracts.V2
{
    public class SearchResult
    {
        public int StatusCode { get; set; }
        public int TotalItems { get; set; }
        public List<Item> Items { get; set; }
    }
}
