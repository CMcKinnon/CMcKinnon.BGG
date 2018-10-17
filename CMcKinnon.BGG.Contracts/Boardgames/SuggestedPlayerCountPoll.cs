using System.Collections.Generic;

namespace CMcKinnon.BGG.Contracts.Boardgames
{
    public class SuggestedPlayerCountPoll
    {
        public uint TotalVotes { get; set; }

        public List<SuggestedPlayerCountResult> Results { get; set; }
    }

    public class SuggestedPlayerCountResult
    {
        public string NumberOfPlayers { get; set; }
        public uint BestVotes { get; set; }
        public uint RecommendedVotes { get; set; }
        public uint NotRecommendedVotes { get; set; }
    }
}
