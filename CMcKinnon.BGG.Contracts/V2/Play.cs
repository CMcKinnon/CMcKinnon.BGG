using System;
using System.Collections.Generic;

namespace CMcKinnon.BGG.Contracts.V2
{
    public class Play
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public string Length { get; set; }
        public bool Incomplete { get; set; }
        public bool NoWinStats { get; set; }
        public string Location { get; set; }
        public string ItemName { get; set; }
        public PlayType? ItemType { get; set; }
        public int ItemObjectId { get; set; }
        public string Comments { get; set; }
        public List<PlaySubType> ItemSubTypes { get; set; }
        public List<Player> Players { get; set; }
    }
}