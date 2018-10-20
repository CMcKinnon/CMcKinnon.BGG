using CMcKinnon.BGG.Client.XmlContracts;
using CMcKinnon.BGG.Contracts.Threads;

namespace CMcKinnon.BGG.Client.Extensions
{
    public static class ForumThreadContractConverters
    {
        public static ForumThread ConvertToForumThread(this _ThreadResult thread)
        {
            return new ForumThread
            {
                Title = thread.Channel?.Title,
                Description = thread.Channel?.Description
            };
        }
    }
}
