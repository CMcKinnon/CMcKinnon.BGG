using CMcKinnon.BGG.Contracts;
using System.Threading.Tasks;

namespace CMcKinnon.BGG.Client
{
    public interface ISearchClient
    {
        Task<boardgames> SearchAsync(string term, bool exact);
    }
}
