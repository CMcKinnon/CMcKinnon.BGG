﻿namespace CMcKinnon.BGG.Contracts.Search
{
    public class Boardgame
    {
        public uint ObjectId { get; set; }
        public string PrimaryName { get; set; }
        public string[] OtherNames { get; set; }
        public int YearPublished { get; set; }
    }
}
