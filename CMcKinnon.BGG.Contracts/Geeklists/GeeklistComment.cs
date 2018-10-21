using System;

namespace CMcKinnon.BGG.Contracts.Geeklists
{
    public class GeeklistComment
    {
        public string Username { get; set; }
        public DateTime Date { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime EditDate { get; set; }
        public int Thumbs { get; set; }
        public string Body { get; set; }
    }
}
