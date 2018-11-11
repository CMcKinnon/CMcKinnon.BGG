using System.Collections.Generic;

namespace CMcKinnon.BGG.Client.Contracts.V2
{
    public class HotItemResult
    {
        public int StatusCode { get; set; }
        public List<Item> Items { get; set; }
    }
}
