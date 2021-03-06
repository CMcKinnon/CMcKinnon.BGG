﻿namespace CMcKinnon.BGG.Client.Contracts.V2
{
    public class Player
    {
        public string Username { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string StartPosition { get; set; }
        public string Color { get; set; }
        public string Score { get; set; }
        public bool New { get; set; }
        public string Rating { get; set; }
        public bool Win { get; set; }
    }
}