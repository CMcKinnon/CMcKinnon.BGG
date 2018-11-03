using System;

namespace CMcKinnon.BGG.Contracts.V2
{
    public class PlayRequest
    {
        public string Username { get; set; }
        public int? ObjectId { get; set; }
        public PlayType? PlayType { get; set; }
        public PlaySubType? PlaySubType { get; set; }
        public DateTime? MinDate { get; set; }
        public DateTime? MaxDate { get; set; }
        public int? Page { get; set; }
    }
}
