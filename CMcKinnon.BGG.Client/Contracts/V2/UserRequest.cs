namespace CMcKinnon.BGG.Client.Contracts.V2
{
    public class UserRequest
    {
        public string Name { get; set; }
        public bool Buddies { get; set; }
        public bool Guilds { get; set; }
        public bool Hot { get; set; }
        public bool Top { get; set; }
        public Domain Domain { get; set; }
        public int Page { get; set; }
    }
}
