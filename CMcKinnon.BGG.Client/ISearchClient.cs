using CMcKinnon.BGG.Contracts.Search;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMcKinnon.BGG.Client
{
    public interface ISearchClient
    {
        Task<IList<Boardgame>> SearchAsync(string term, bool exact);
    }
}
