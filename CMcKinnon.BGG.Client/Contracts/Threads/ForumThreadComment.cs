using System;

namespace CMcKinnon.BGG.Client.Contracts.Threads
{
    public class ForumThreadComment
    {
        public string Title { get; set; }
        public string CommentText { get; set; }
        public string Link { get; set; }
        public string Guid { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Creator { get; set; }
    }
}