namespace CMcKinnon.BGG.Contracts.Search
{
    public class BoardgameResult
    {
        public int StatusCode { get; set; }

        public uint ObjectId { get; set; }
        public string Name { get; set; }
        public int YearPublished { get; set; }
    }
}
