using System.Collections.Generic;

namespace CMcKinnon.BGG.Client.Contracts.V2
{
    public class PlayResult
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
        public int TotalPlays { get; set; }
        public int Page { get; set; }

        public List<Play> Plays { get; set; }
    }
}
