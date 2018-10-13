namespace CMcKinnon.BGG.Contracts.Search
{
    public class Boardgame
    {
        public uint ObjectId { get; set; }
        public string Name { get; set; }
        public bool IsPrimaryName { get; set; }
        public int YearPublished { get; set; }
    }
}
