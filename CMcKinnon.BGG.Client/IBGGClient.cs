using CMcKinnon.BGG.Contracts.Boardgames;
using CMcKinnon.BGG.Contracts.Collections;
using CMcKinnon.BGG.Contracts.Search;
using CMcKinnon.BGG.Contracts.Threads;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMcKinnon.BGG.Client
{
    public interface IBGGClient
    {
        Task<IList<BoardgameResult>> SearchAsync(string term, bool exact = false);
        Task<IList<Boardgame>> GetBoardgamesAsync(int[] objectIds, bool includeComments = false, int commentPage = 1, bool includeStatistics = false);
        Task<CollectionHeader> GetUserCollection(string user, CollectionQueryOption option, RetrySettings retrySettings);
        Task<ForumThread> GetForumThread(int id, int? startArticle = null, int? count = null, string username = null); 
    }
}
