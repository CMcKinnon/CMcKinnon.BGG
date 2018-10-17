namespace CMcKinnon.BGG.Contracts.Boardgames
{
    public class Rank
    {
        public string Type { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string FriendlyName { get; set; }
        public int Value { get; set; }
        public decimal BayesAverage { get; set; }
    }
}
