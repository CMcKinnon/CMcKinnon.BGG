using CMcKinnon.BGG.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMcKinnon.BGG.Client
{
    public interface ISearchClient
    {
        Task<IEnumerable<boardgames>> SearchAsync(string term, bool exact);
    }
}
