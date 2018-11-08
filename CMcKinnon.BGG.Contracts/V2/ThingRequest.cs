using System.Collections.Generic;

namespace CMcKinnon.BGG.Contracts.V2
{
    public class ThingRequest
    {
        public List<int> Ids { get; set; }
        public List<ThingType> ThingTypes { get; set; }
        public bool? Versions { get; set; }
        public bool? Videos { get; set; }
        public bool? Stats { get; set; }
        public bool? Historical { get; set; }
        public bool? Marketplace { get; set; }
        public bool? Comments { get; set; }
        public bool? RatingComments { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}