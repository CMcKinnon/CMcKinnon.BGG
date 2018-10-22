using System;
using System.Collections.Generic;

namespace CMcKinnon.BGG.Contracts.Threads
{
    public class ForumThread
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public DateTime PublicationDate { get; set; }
        public DateTime LastBuildDate { get; set; }
        public string Link { get; set; }
        public string Webmaster { get; set; }


        public ForumThreadImage Image { get; set; }
        public List<ForumThreadComment> Comments { get; set; }
    }
}
