namespace CMcKinnon.BGG.Client.Contracts.Collections
{
    public class CollectionItem
    {
        public string ObjectType { get; set; }
        public uint ObjectId { get; set; }
        public string SubType { get; set; }
        public uint? CollectionId { get; set; }
        public string Name { get; set; }
        public int YearPublished { get; set; }
        public string Thumbnail { get; set; }
        public string Image { get; set; }
        public uint NumberOfPlays { get; set; }
        public string Comment { get; set; }
        public string HasPartsList { get; set; }
        public string WantPartsList { get; set; }
        public CollectionItemStatus Status { get; set; }
        public CollectionItemStats Stats { get; set; }
    }
}
