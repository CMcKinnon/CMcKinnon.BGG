using System.Collections.Generic;

namespace CMcKinnon.BGG.Client.Contracts.Boardgames
{
    public class Statistics
    {
        public string Page { get; set; }
        public int NumberOfUserRatings { get; set; }
        public decimal AverageRating { get; set; }
        public decimal BayesAverageRating { get; set; }
        public decimal StandardDeviation { get; set; }
        public decimal Median { get; set; }
        public int NumberOfUsersOwning { get; set; }
        public int NumberOfUsersWantingToTrade { get; set; }
        public int NumberOfUsersWantingInTrade { get; set; }
        public int NumberOfUsersWishing { get; set; }
        public int NumberOfComments { get; set; }
        public int NumberOfWeightVotes { get; set; }
        public decimal AverageWeight { get; set; }
        public List<Rank> Ranks { get; set; }
    }
}
