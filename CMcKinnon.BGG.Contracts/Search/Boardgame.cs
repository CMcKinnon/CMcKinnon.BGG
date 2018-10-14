﻿using System.Collections.Generic;

namespace CMcKinnon.BGG.Contracts.Search
{
    public class Boardgame
    {
        public uint ObjectId { get; set; }
        public string PrimaryName { get; set; }
        public List<string> OtherNames { get; set; }
        public int YearPublished { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int PlayingTime { get; set; }
        public int MinPlayTime { get; set; }
        public int MaxPlayTime { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public string Image { get; set; }

        public List<LinkedObject> Publishers { get; set; }
        public List<LinkedObject> Artists { get; set; }
        public List<LinkedObject> Designers { get; set; }
        public List<LinkedObject> Families { get; set; }
        public List<LinkedObject> Honors { get; set; }
        public List<LinkedObject> Implementations { get; set; }
        public List<LinkedObject> Mechanics { get; set; }
        public List<LinkedObject> PodcastEpisodes { get; set; }
        public List<LinkedObject> Subdomains { get; set; }
        public List<LinkedObject> Versions { get; set; }
    }
}
