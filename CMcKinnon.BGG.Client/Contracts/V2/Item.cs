namespace CMcKinnon.BGG.Client.Contracts.V2
{
    public class Item
    {
        public ThingType Type { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearPublished { get; set; }
        public string Thumbnail { get; set; }
        public int? Rank { get; set; }
    }
}
