using System;
using System.Collections.Generic;

namespace CMcKinnon.BGG.Contracts.Geeklists
{
    public class GeeklistItem
    {
        public int Id { get; set; }
        public string ObjectType { get; set; }
        public string SubType { get; set; }
        public int ObjectId { get; set; }
        public string ObjectName { get; set; }
        public string Username { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime EditDate { get; set; }
        public int Thumbs { get; set; }
        public int ImageId { get; set; }
        public string Body { get; set; }
        public List<GeeklistComment> Comments { get; set; }
    }
}
