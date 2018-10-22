using System;
using System.Collections.Generic;

namespace CMcKinnon.BGG.Contracts.Geeklists
{
    public class Geeklist
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }

        public int Id { get; set; }
        public DateTime PostDate { get; set; }
        public long PostDateTimestamp { get; set; }
        public DateTime EditDate { get; set; }
        public long EditDateTimestamp { get; set; }
        public int Thumbs { get; set; }
        public int NumberOfItems { get; set; }
        public string Username { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public List<GeeklistItem> Items { get; set; }
        public List<GeeklistComment> Comments { get; set; }
    }
}
