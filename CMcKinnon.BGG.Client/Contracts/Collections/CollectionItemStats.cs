namespace CMcKinnon.BGG.Client.Contracts.Collections
{
    public class CollectionItemStats
    {
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int MinPlayTime { get; set; }
        public int MaxPlayTime { get; set; }
        public int PlayingTime { get; set; }
        public int NumberOwned { get; set; }
        public string Rating { get; set; }
        public int UsersRated { get; set; }
        public decimal Average { get; set; }
        public decimal BayesAverage { get; set; }
        public decimal StandardDeviation { get; set; }
        public decimal Median { get; set; }
    }
}
