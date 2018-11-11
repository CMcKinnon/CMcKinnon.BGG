using CMcKinnon.BGG.Client.Contracts;
using CMcKinnon.BGG.Client.Contracts.Boardgames;
using CMcKinnon.BGG.Client.Contracts.Collections;
using CMcKinnon.BGG.Client.Contracts.Geeklists;
using CMcKinnon.BGG.Client.Contracts.Search;
using CMcKinnon.BGG.Client.Contracts.Threads;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMcKinnon.BGG.Client
{
    public interface IBGGClient
    {
        Task<IList<BoardgameResult>> SearchAsync(string term, bool exact = false);
        Task<IList<Boardgame>> GetBoardgamesAsync(int[] objectIds, bool includeComments = false, int commentPage = 1, bool includeStatistics = false);
        Task<CollectionHeader> GetUserCollection(string user, CollectionQueryOption option, RetrySettings retrySettings);
        Task<ForumThread> GetForumThread(int id, RetrySettings retrySettings, int? startArticle = null, int? count = null, string username = null);
        Task<Geeklist> GetGeeklist(int id, RetrySettings retrySettings, bool getComments = false);
    }
}
